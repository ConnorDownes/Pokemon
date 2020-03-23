using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Type = PokemonAPI.Models.PokeAPI.PokemonSpecifics.Type;

namespace PokemonAPI.ViewModels.PokemonVM
{
    public class Basic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Type> Types { get; set; }
    }
}