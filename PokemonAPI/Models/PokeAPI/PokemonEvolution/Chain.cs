using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.Models.PokeAPI.PokemonEvolution
{
    public class Chain
    {
        public List<EvolutionDetail> evolution_details { get; set; }
        public List<Chain> evolves_to { get; set; }
        public bool is_baby { get; set; }
        public Result species { get; set; }
    }
}