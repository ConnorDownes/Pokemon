using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.Models.PokeAPI.PokemonSpecifics
{
    public class Move
    {
        public Result move { get; set; }
        public List<VersionGroupDetail> version_group_details
        {
            get; set;
        }
    }
}