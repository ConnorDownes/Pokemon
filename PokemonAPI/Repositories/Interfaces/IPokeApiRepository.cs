using PokemonAPI.Models;
using PokemonAPI.Models.PokemonBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAPI.Repositories.Interfaces
{
    public interface IPokeApiRepository
    {
        Task<PokemonBasic> GetAllPokemonAsync(int limit = 20, int offset = 5);
        Task<Pokemon> GetSinglePokemonAsync(int id);
        Task<Pokemon> GetSinglePokemonAsync(string name);
        Task<pokemonSpecies> GetSinglePokemonSpeciesAsync(string name);
        Task<pokemonSpecies> GetSinglePokemonSpeciesAsync(int id);
        Task<EvolutionInfo> GetPokemonEvolutionInfoAsync(string evolutionURL);
    }
}
