using PokemonAPI.Models;
using PokemonAPI.Models.PokemonEvolution;
using PokemonAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PokemonAPI.Helpers
{
    public class EvolutionHelper
    {
        private readonly IPokeApiRepository _Repo;
        public EvolutionHelper(IPokeApiRepository Repo)
        {
            _Repo = Repo;
        }

        // Get the evolution chain from an initial Chain class
        public async Task<List<Pokemon>> GetEvolutionChain(List<Chain> evolChain)
        {
            // List to contain the objects
            var PokemonList = new List<Pokemon>();
            // For each object in evolution chain, get the object from the API and add it to the list
            foreach (var PokeEvolution in evolChain)
            {
                var CurrentPokemonResponse = await _Repo.GetSinglePokemonAsync(PokeEvolution.species.name);
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