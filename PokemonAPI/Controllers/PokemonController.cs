using AutoMapper;
using PokemonAPI.Factories.Interfaces;
using PokemonAPI.Models.PokeAPI.PokemonEvolution;
using PokemonAPI.Models.PokeAPI.PokemonSpecifics;
using PokemonAPI.Repositories.Interfaces;
using PokemonAPI.Services;
using PokemonAPI.Services.Interfaces;
using PokemonAPI.ViewModels;
using PokemonAPI.ViewModels.PokemonVM;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Linq;

namespace PokemonAPI.Controllers
{
    [RoutePrefix("Pokemon")]
    public class PokemonController : Controller
    {
        private readonly IPokeApiRepository _pokeApiRepo;
        private readonly IMapper _mapper;

        public PokemonController(IPokeApiRepository pokeApiRepo, IMapper mapper)
        {
            _pokeApiRepo = pokeApiRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Index(int page = 1, int limit = 2000)
        {
            var Response = await _pokeApiRepo.GetAllPokemonAsync(limit, (page - 1) * limit);

            var ResultTasks = Response.results.Take(20).Select(async m => _mapper.Map<BasicWithImage>(await _pokeApiRepo.GetSinglePokemonAsync(m.name))).ToList();
            //
            var Results = await Task.WhenAll(ResultTasks);

            return View(Results.ToList());
        }

        // POST: Pokemon
        [HttpGet]
        [Route("{name}")]
        public async Task<ActionResult> Details(string name)
        {
            var Species = await _pokeApiRepo.GetSinglePokemonSpeciesAsync(name.ToLower());

            if (Species == null)
            {
                throw new Exception($"No Pokemon named '{name}' was found!");
            }
            // TODO: Refactor to call DB repo, if item is not found, call it from the API
            var EvolutionInfoTask =  _pokeApiRepo.GetPokemonEvolutionInfoAsync(Species.evolution_chain.url);
            var PokemonInfoTask = _pokeApiRepo.GetSinglePokemonAsync(Species.id);
            await Task.WhenAll(EvolutionInfoTask, PokemonInfoTask);
            var EvolutionInfo = EvolutionInfoTask.Result;
            var PokemonInfo = _mapper.Map<Detailed>(PokemonInfoTask.Result);

            var imageList = from Pokemon in await _pokeApiRepo.GetEvolutionChain(new List<Chain>() { EvolutionInfo.chain })
                            select Pokemon.Select(m => _mapper.Map<BasicWithImage>(m));

            return View(new PokemonDetails
            {
                Pokemon = PokemonInfo,
                Species = _mapper.Map<SpeciesBasic>(Species),
                PokemonEvolutionChain = imageList.ToList()
            });
        }
    }
}