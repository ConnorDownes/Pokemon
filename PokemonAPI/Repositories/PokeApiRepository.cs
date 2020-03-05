using PokemonAPI.Factories;
using PokemonAPI.Factories.Interfaces;
using PokemonAPI.Models;
using PokemonAPI.Models.PokemonBasic;
using PokemonAPI.Repositories.Interfaces;
using PokemonAPI.Services;
using PokemonAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PokemonAPI.Repositories
{
    public class PokeApiRepository : IPokeApiRepository
    {
        private readonly IApiService _apiClient;
        private readonly IDeserialise _deserialiser;
        public PokeApiRepository(IApiService apiClient, IFactory deserialiserFactory)
        {
            _apiClient = apiClient;
            _deserialiser = deserialiserFactory.Create(Enums.ApiResponseFormat.JSON);
        }

        public async Task<PokemonBasic> GetAllPokemonAsync(int limit = 20, int offset = 5)
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
    }
}