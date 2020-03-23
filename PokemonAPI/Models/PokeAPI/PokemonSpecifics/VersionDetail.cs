using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.Models.PokeAPI.PokemonSpecifics
{
    public class VersionDetail
    {
        public int rarity { get; set; }
        public Result version { get; set; }
    }
}