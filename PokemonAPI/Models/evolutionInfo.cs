using PokemonAPI.Models.PokemonEvolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.Models
{
    public class evolutionInfo
    {
        public object baby_trigger_item { get; set; }
        public Chain chain { get; set; }
        public int id { get; set; }
    }
}