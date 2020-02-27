using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.Models.PokemonSpecies
{
    public class Variety
    {
        public bool is_default { get; set; }
        public Pokemon pokemon { get; set; }
    }
}