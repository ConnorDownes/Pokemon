using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.Models.PokeAPI.PokemonSpecies
{
    public class PokedexNumber
    {
        public int entry_number { get; set; }
        public Result pokedex { get; set; }
    }
}