using PokemonAPI.Models;
using PokemonAPI.Models.PokemonBasic;
using PokemonAPI.Repositories.Interfaces;
using PokemonAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PokemonAPI.Services
{
    public class PokeApiService : IPokeApiService
    {
        private readonly IPokeApiRepository _pokeApiRepository;
        public PokeApiService(IPokeApiRepository pokeApiRepository)
        {
            _pokeApiRepository = pokeApiRepository;
        }

        public async Task<PokemonBasic> GetAllPokemonAsync(int limit = 20, int offset = 5)
        {
            return await _pokeApiRepository.GetAllPokemonAsync(limit, offset);
        }

        public async Task<pokemonSpecies> GetPokemonByNameAsync(string name)
        {
            return await _pokeApiRepository.GetPokemonByNameAsync(name);
        }

        public async Task<pokemonSpecies> GetPokemonByIdAsync(int id)
        {
            return await _pokeApiRepository.GetPokemonByIdAsync(id);
        }
    }
}