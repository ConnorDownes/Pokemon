using PokemonAPI.Models.PokeAPI.PokemonEvolution;
using PokemonAPI.Models.PokeAPI.PokemonSpecies;
using Pokemon = PokemonAPI.Models.PokeAPI.PokemonSpecifics.Pokemon;
using System.Collections.Generic;
using PokemonAPI.ViewModels.PokemonVM;

namespace PokemonAPI.ViewModels
{
    public class PokemonDetails
    {
        public Detailed Pokemon { get; set; }
        public SpeciesBasic Species { get; set; }
        public List<IEnumerable<BasicWithImage>> PokemonEvolutionChain { get; set; }
    }
}