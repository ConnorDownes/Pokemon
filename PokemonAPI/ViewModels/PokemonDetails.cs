using PokemonAPI.Models.PokeAPI.PokemonEvolution;
using PokemonAPI.Models.PokeAPI.PokemonSpecies;
using PokemonAPI.Models.PokeAPI.PokemonSpecifics;
using System.Collections.Generic;

namespace PokemonAPI.ViewModels
{
    public class PokemonDetails
    {
        public string name { get; set; }
        public Pokemon Root { get; set; }
        public EvolutionInfo Evolve { get; set; }
        public pokemonSpecies Species { get; set; }
        public List<Pokemon> PokemonEvolutionChain { get; set; }
    }
}