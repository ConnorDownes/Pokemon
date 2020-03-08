using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.Models.PokeAPI.PokemonSpecifics
{
    public class Stat
    {
        public int base_stat { get; set; }
        public int effort { get; set; }
        public Result stat { get; set; }
    }
}