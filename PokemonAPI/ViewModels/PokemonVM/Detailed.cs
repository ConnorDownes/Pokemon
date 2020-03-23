using PokemonAPI.Models.PokeAPI.PokemonSpecifics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.ViewModels.PokemonVM
{
    public class Detailed : Basic
    {
        public Statistics Stats { get; set; }
        public Sprites Sprites { get; set; }
        public List<Move> Moves { get; set; }
        public List<Ability> Abilities { get; set; }
    }
}