using PokemonAPI.Models.PokeAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.Models.PokeAPI.PokemonSpecifics
{
    public class Ability
    {
        public Result ability { get; set; }
        public bool is_hidden { get; set; }
        public int slot { get; set; }
    }
}