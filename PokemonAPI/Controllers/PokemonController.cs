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
        private readonly IPokeApiRepository _PokeApiRepo;

        public PokemonController(HTTPClientService apiClient, DeserialiserFactory deserialiserFactory, IPokeApiRepository PokeApiRepo)
        {
            _apiClient = apiClient;
            _deserialiser = deserialiserFactory.Create(Enums.ApiResponseFormat.JSON);
            _PokeApiRepo = PokeApiRepo;
        }

        [HttpGet]
        public async Task<ActionResult> Index(int page = 1, int limit = 20)
        {
            var JsonResponse = await _apiClient.CallApiAsync($"https://pokeapi.co/api/v2/pokemon?offset={(page - 1) * limit}&limit={limit}");
            var Response = _deserialiser.Deserialise<PokemonBasic>(JsonResponse);
            return View(Response);
        }

        // POST: Pokemon
        [HttpGet]
        [Route("{name}")]
        public async Task<ActionResult> Details(string name)
        {
            //var JsonResponse = await _apiClient.CallApiAsync($"https://pokeapi.co/api/v2/pokemon-species/{name.ToLower()}");

            //if (JsonResponse == null)
            //{
            //    ModelState.AddModelError("name", $"No Pokemon named '{name}' was found!");
            //    return View();
            //}

            //pokemonSpecies Species = _deserialiser.Deserialise<pokemonSpecies>(JsonResponse);

            var Species = await _PokeApiRepo.GetByNameAsync<pokemonSpecies>(name);

            if (Species == null)
            {
                ModelState.AddModelError("name", $"No Pokemon named '{name}' was found!");
                return View();
            }

            // TODO: Refactor by moving into a service
            // Consider having a repository for basic operations, to hide the API calls

            var GetEvolutionChainFromApi = _apiClient.CallApiAsync(Species.evolution_chain.url);
            //CallAPI<evolutionInfo>(Species.evolution_chain.url);
            var GetDetailedInformationForPokemon = _apiClient.CallApiAsync($"https://pokeapi.co/api/v2/pokemon/{Species.id}");
            //CallAPI<RootObject>("https://pokeapi.co/api/v2/pokemon/" + Species.id);
            Task.WhenAll(GetEvolutionChainFromApi, GetDetailedInformationForPokemon);
            var EvolutionInfo = _deserialiser.Deserialise<evolutionInfo>(await GetEvolutionChainFromApi);
            var PokemonInfo = _deserialiser.Deserialise<RootObject>(await GetDetailedInformationForPokemon);
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
        private async Task<List<RootObject>> GetEvolutionChain(List<Chain> evolChain)
        {
            // List to contain the objects
            var PokemonList = new List<RootObject>();
            // For each object in evolution chain, get the object from the API and add it to the list
            foreach(var PokeEvolution in evolChain)
            {
                var CurrentPokemonResponse = await _apiClient.CallApiAsync($"https://pokeapi.co/api/v2/pokemon/{PokeEvolution.species.name}");
                PokemonList.Add(_deserialiser.Deserialise<RootObject>(CurrentPokemonResponse));
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