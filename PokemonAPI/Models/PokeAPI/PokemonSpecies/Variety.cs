using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.Models.PokeAPI.PokemonSpecies
{
    public class Variety
    {
        public bool is_default { get; set; }
        public Result pokemon { get; set; }
    }
}