using PokemonAPI.Factories;
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
        public PokeApiRepository(HTTPClientService apiClient, DeserialiserFactory deserialiserFactory)
        {
            _apiClient = apiClient;
            _deserialiser = deserialiserFactory.Create(Enums.ApiResponseFormat.JSON);
        }

        public async Task<T> GetAllAsync<T>()
        {
            var Response = await _apiClient.CallApiAsync($"https://pokeapi.co/api/v2/pokemon");

            T Species = _deserialiser.Deserialise<T>(Response);

            return Species;
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var Response = await _apiClient.CallApiAsync($"https://pokeapi.co/api/v2/pokemon-species/{id}");

            T Species = _deserialiser.Deserialise<T>(Response);

            return Species;
        }

        public async Task<T> GetByNameAsync<T>(string name)
        {
            var Response = await _apiClient.CallApiAsync($"https://pokeapi.co/api/v2/pokemon-species/{name.ToLower()}");

            T Species = _deserialiser.Deserialise<T>(Response);

            return Species;
        }
    }
}