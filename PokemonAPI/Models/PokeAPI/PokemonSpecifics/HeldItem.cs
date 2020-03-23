using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.Models.PokeAPI.PokemonSpecifics
{
    public class HeldItem
    {
        public Result item { get; set; }
        public List<VersionDetail> version_details { get; set; }
    }
}