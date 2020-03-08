using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.Models.PokeAPI.PokemonSpecies
{
    public class FlavorTextEntry
    {
        public string flavor_text { get; set; }
        public Result language { get; set; }
        public Version version { get; set; }
    }
}