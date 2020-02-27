using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.Models.PokemonSpecies
{
    public class PalParkEncounter
    {
        public Area area { get; set; }
        public int base_score { get; set; }
        public int rate { get; set; }
    }
}