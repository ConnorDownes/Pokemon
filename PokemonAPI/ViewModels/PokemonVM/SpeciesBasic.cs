using PokemonAPI.Models.PokeAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.ViewModels.PokemonVM
{
    public class SpeciesBasic
    {
        public string Description { get; set; }
        public string Genus { get; set; }
        public List<Result> egg_groups { get; set; }
    }
}