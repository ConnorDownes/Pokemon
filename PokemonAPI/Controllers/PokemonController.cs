using Newtonsoft.Json;
using PokemonAPI.Factories;
using PokemonAPI.Factories.Interfaces;
using PokemonAPI.Helpers;
using PokemonAPI.Models;
using PokemonAPI.Models.PokemonBasic;
using PokemonAPI.Models.PokemonEvolution;
using PokemonAPI.Repositories.Interfaces;
using PokemonAPI.Services;
using PokemonAPI.Services.Interfaces;
using PokemonAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PokemonAPI.Controllers
{
    [RoutePrefix("Pokemon")]
    public class PokemonController : Controller
    {
        private readonly IApiService _apiClient;
        private readonly IDeserialise _deserialiser;
        private readonly IPokeApiRepository _pokeApiRepo;

        public PokemonController(HTTPClientService apiClient, IFactory deserialiserFactory, IPokeApiRepository pokeApiRepo)
        {
            _apiClient = apiClient;
            _deserialiser = deserialiserFactory.Create(Enums.ApiResponseFormat.JSON);
            _pokeApiRepo = pokeApiRepo;
        }

        [HttpGet]
        public async Task<ActionResult> Index(int page = 1, int limit = 20)
        {
            var Response = await _pokeApiRepo.GetAllPokemonAsync(limit, (page - 1) * limit);
            return View(Response);
        }

        // POST: Pokemon
        [HttpGet]
        [Route("{name}")]
        public async Task<ActionResult> Details(string name)
        {
            var Species = await _pokeApiRepo.GetSinglePokemonSpeciesAsync(name);

            if (Species == null)
            {
                throw new Exception($"No Pokemon named '{name}' was found!");
            }
            // TODO: Refactor to call DB repo, if item is not found, call it from the API
            var EvolutionInfoTask =  _pokeApiRepo.GetPokemonEvolutionInfoAsync(Species.evolution_chain.url);
            var PokemonInfoTask = _pokeApiRepo.GetSinglePokemonAsync(Species.id);
            await Task.WhenAll(EvolutionInfoTask, PokemonInfoTask);
            var EvolutionInfo = EvolutionInfoTask.Result;
            var PokemonInfo = PokemonInfoTask.Result;
            // move this method into the repository to allow it to be re-used
            // Add a service and put this in there
            var imageList = await GetEvolutionChain(new List<Chain>() { EvolutionInfo.chain });

            return View(new PokemonDetails
            {
                name = name,
                Root = PokemonInfo,
                Evolve = EvolutionInfo,
                Species = Species,
                PokemonEvolutionChain = imageList
            });
        }
    }
}