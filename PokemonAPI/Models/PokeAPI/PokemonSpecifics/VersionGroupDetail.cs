using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.Models.PokeAPI.PokemonSpecifics
{
    public class VersionGroupDetail
    {
        public int level_learned_at { get; set; }
        public Result move_learn_method { get; set; }
        public Result version_group { get; set; }
    }
}