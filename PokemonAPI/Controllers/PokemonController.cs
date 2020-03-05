using Newtonsoft.Json;
using PokemonAPI.Factories;
using PokemonAPI.Factories.Interfaces;
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
            var Response = await _pokeApiRepo.GetAllPokemonAsync();
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
                ModelState.AddModelError("name", $"No Pokemon named '{name}' was found!");
                return View();
            }

            var EvolutionInfoTask =  _pokeApiRepo.GetPokemonEvolutionInfoAsync(Species.evolution_chain.url);
            var PokemonInfoTask = _pokeApiRepo.GetSinglePokemonAsync(Species.id);
            await Task.WhenAll(EvolutionInfoTask, PokemonInfoTask);
            var EvolutionInfo = EvolutionInfoTask.Result;
            var PokemonInfo = PokemonInfoTask.Result;
            // move this method into the repository to allow it to be re-used
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

        // Get the evolution chain from an initial Chain class
        private async Task<List<Pokemon>> GetEvolutionChain(List<Chain> evolChain)
        {
            // List to contain the objects
            var PokemonList = new List<Pokemon>();
            // For each object in evolution chain, get the object from the API and add it to the list
            foreach(var PokeEvolution in evolChain)
            {
                var CurrentPokemonResponse = await _pokeApiRepo.GetSinglePokemonAsync(PokeEvolution.species.name);
                PokemonList.Add(CurrentPokemonResponse);
            }
            // Reloop through chain after all pokemon have been found above
            // TODO: Look into a better way of doing this to avoid looping twice
            foreach (var PokeEvolution in evolChain)
            {
                // If the current pokemon has an evolution, recursively run this function again to get the 
                // pokemon in the next chain
                if (PokeEvolution.evolves_to != null)
                {
                    // Add the returned pokemon to the list
                    PokemonList.AddRange(await GetEvolutionChain(PokeEvolution.evolves_to));
                }
            }
            // return the list of pokemon in the evolution chain
            return PokemonList;

        }
    }
}