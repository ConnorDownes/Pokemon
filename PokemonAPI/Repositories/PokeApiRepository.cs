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
        private readonly string BaseURL = "https://pokeapi.co/api/v2";
        private readonly IApiService _apiClient;
        private readonly IDeserialise _deserialiser;
        public PokeApiRepository(IApiService apiClient, IFactory deserialiserFactory)
        {
            _apiClient = apiClient;
            _deserialiser = deserialiserFactory.Create(Enums.ApiResponseFormat.JSON);
        }

        public async Task<PokemonBasic> GetAllPokemonAsync(int limit = 20, int offset = 0)
        {
            var Response = await _apiClient.CallApiAsync($"{BaseURL}/pokemon?limit={limit}&offset={offset}");

            var Pokemon = _deserialiser.Deserialise<PokemonBasic>(Response);

            return Pokemon;
        }

        public async Task<Pokemon> GetSinglePokemonAsync(int id)
        {
            var Response = await _apiClient.CallApiAsync($"{BaseURL}/pokemon/{id}");

            var Pokemon = _deserialiser.Deserialise<Pokemon>(Response);

            return Pokemon;
        }

        public async Task<Pokemon> GetSinglePokemonAsync(string name)
        {
            var Response = await _apiClient.CallApiAsync($"{BaseURL}/pokemon/{name}");

            var Pokemon = _deserialiser.Deserialise<Pokemon>(Response);

            return Pokemon;
        }

        public async Task<pokemonSpecies> GetSinglePokemonSpeciesAsync(int id)
        {
            var Response = await _apiClient.CallApiAsync($"{BaseURL}/pokemon-species/{id}");

            var Species = _deserialiser.Deserialise<pokemonSpecies>(Response);

            return Species;
        }

        public async Task<pokemonSpecies> GetSinglePokemonSpeciesAsync(string name)
        {
            var Response = await _apiClient.CallApiAsync($"{BaseURL}/pokemon-species/{name}");

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
        public async Task<List<List<Pokemon>>> GetEvolutionChain(List<Chain> initialEvolChain)
        {
            var PokemonEvolutionStageList = new List<List<Pokemon>>();

            PokemonEvolutionStageList.Add(await GetPokemonInEvolutionStage(initialEvolChain));

            foreach (var evolutionStage in initialEvolChain)
            {
                if (evolutionStage.evolves_to.Count > 0)
                {
                    PokemonEvolutionStageList.AddRange(await GetEvolutionChain(evolutionStage.evolves_to));
                }
            }

            return PokemonEvolutionStageList;
        }

        private async Task<List<Pokemon>> GetPokemonInEvolutionStage(List<Chain> evolutionStage)
        {
            var PokemonList = new List<Pokemon>();

            foreach (var PokeEvolution in evolutionStage)
            {
                var CurrentPokemonResponse = await GetSinglePokemonAsync(PokeEvolution.species.name);
                PokemonList.Add(CurrentPokemonResponse);
            }

            return PokemonList;
        }
    }
}