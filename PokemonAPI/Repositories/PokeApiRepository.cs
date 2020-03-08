using PokemonAPI.Factories.Interfaces;
using PokemonAPI.Models.PokeAPI.PokemonEvolution;
using PokemonAPI.Models.PokeAPI.PokemonSpecies;
using PokemonAPI.Models.PokeAPI.PokemonSpecifics;
using PokemonAPI.Models.PokemonBasic;
using PokemonAPI.Repositories.Interfaces;
using PokemonAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PokemonAPI.Repositories
{
    [OutputCache(Duration = 86400)]
    public class PokeApiRepository : IPokeApiRepository
    {
        private readonly IApiService _apiClient;
        private readonly IDeserialise _deserialiser;
        public PokeApiRepository(IApiService apiClient, IFactory deserialiserFactory)
        {
            _apiClient = apiClient;
            _deserialiser = deserialiserFactory.Create(Enums.ApiResponseFormat.JSON);
        }

        public async Task<PokemonBasic> GetAllPokemonAsync(int limit = 20, int offset = 0)
        {
            var Response = await _apiClient.CallApiAsync($"https://pokeapi.co/api/v2/pokemon?limit={limit}&offset={offset}");

            var Pokemon = _deserialiser.Deserialise<PokemonBasic>(Response);

            return Pokemon;
        }

        public async Task<Pokemon> GetSinglePokemonAsync(int id)
        {
            var Response = await _apiClient.CallApiAsync($"https://pokeapi.co/api/v2/pokemon/{id}");

            var Pokemon = _deserialiser.Deserialise<Pokemon>(Response);

            return Pokemon;
        }

        public async Task<Pokemon> GetSinglePokemonAsync(string name)
        {
            var Response = await _apiClient.CallApiAsync($"https://pokeapi.co/api/v2/pokemon/{name}");

            var Pokemon = _deserialiser.Deserialise<Pokemon>(Response);

            return Pokemon;
        }

        public async Task<pokemonSpecies> GetSinglePokemonSpeciesAsync(int id)
        {
            var Response = await _apiClient.CallApiAsync($"https://pokeapi.co/api/v2/pokemon-species/{id}");

            var Species = _deserialiser.Deserialise<pokemonSpecies>(Response);

            return Species;
        }

        public async Task<pokemonSpecies> GetSinglePokemonSpeciesAsync(string name)
        {
            var Response = await _apiClient.CallApiAsync($"https://pokeapi.co/api/v2/pokemon-species/{name}");

            var Species = _deserialiser.Deserialise<pokemonSpecies>(Response);

            return Species;
        }

        public async Task<EvolutionInfo> GetPokemonEvolutionInfoAsync(string evolutionURL)
        {
            var Response = await _apiClient.CallApiAsync(evolutionURL);

            var Evolution = _deserialiser.Deserialise<EvolutionInfo>(Response);

            return Evolution;
        }

        // Get the evolution chain from an initial Chain class
        public async Task<List<Pokemon>> GetEvolutionChain(List<Chain> evolChain)
        {
            // List to contain the objects
            var PokemonList = new List<Pokemon>();
            // For each object in evolution chain, get the object from the API and add it to the list
            foreach (var PokeEvolution in evolChain)
            {
                var CurrentPokemonResponse = await GetSinglePokemonAsync(PokeEvolution.species.name);
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