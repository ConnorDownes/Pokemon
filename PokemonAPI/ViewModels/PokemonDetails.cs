using PokemonAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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