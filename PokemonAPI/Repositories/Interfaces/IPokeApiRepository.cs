using PokemonAPI.Models.PokeAPI.PokemonEvolution;
using PokemonAPI.Models.PokeAPI.PokemonSpecies;
using PokemonAPI.Models.PokeAPI.PokemonSpecifics;
using PokemonAPI.Models.PokemonBasic;
using System.Collections.Generic;
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
        Task<List<List<Pokemon>>> GetEvolutionChain(List<Chain> evolChain);
    }
}
