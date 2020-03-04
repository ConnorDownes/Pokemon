using PokemonAPI.Models;
using PokemonAPI.Models.PokemonBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAPI.Services.Interfaces
{
    public interface IPokeApiService
    {
        Task<PokemonBasic> GetAllPokemonAsync(int limit = 20, int offset = 5);
        Task<pokemonSpecies> GetPokemonByNameAsync(string name);
        Task<pokemonSpecies> GetPokemonByIdAsync(int id);
    }
}
