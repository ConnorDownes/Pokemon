using Newtonsoft.Json;
using PokemonAPI.Models;
using PokemonAPI.Models.PokemonEvolution;
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
    public class PokemonController : Controller
    {

        private static readonly HttpClient client = new HttpClient();

        // POST: Pokemon
        [HttpGet]
        public async Task<ActionResult> Search(string name)
        {

            if(name == null || name.Trim() == "")
            {
                ModelState.AddModelError("name", "Enter a Pokemon name here");
                return View();
            }

            pokemonSpecies Species = await CallAPI<pokemonSpecies>($"https://pokeapi.co/api/v2/pokemon-species/{name.ToLower()}");

            if (Species == null)
            {
                ModelState.AddModelError("name", $"No Pokemon named '{name}' was found!");
                return View();
            }

            evolutionInfo EvolutionInfo = await CallAPI<evolutionInfo>(Species.evolution_chain.url);
            RootObject PokemonInfo = await CallAPI<RootObject>("https://pokeapi.co/api/v2/pokemon/" + Species.id);
            List<RootObject> imageList = await GetEvolutionChain(new List<Chain>() { EvolutionInfo.chain });

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
                PokemonList.Add(await CallAPI<RootObject>("https://pokeapi.co/api/v2/pokemon/" + PokeEvolution.species.name));
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

        // TODO: Refactor this into service which can be passed into a repo
        private async Task<T> CallAPI<T>(string APIRequest)
        {
            //Handle NULL Values
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            T rootObject = default(T);
            var response = await client.GetAsync(APIRequest);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                rootObject = JsonConvert.DeserializeObject<T>(jsonResponse, settings);

            }
            return rootObject;
        }
    }
}