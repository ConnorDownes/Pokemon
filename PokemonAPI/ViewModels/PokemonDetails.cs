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
        public RootObject Root { get; set; }
        public evolutionInfo Evolve { get; set; }
        public pokemonSpecies Species { get; set; }
        public List<RootObject> PokemonEvolutionChain { get; set; }
    }
}