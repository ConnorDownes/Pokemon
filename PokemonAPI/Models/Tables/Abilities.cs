using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.Models.Tables
{
    public class Abilities
    {
        public int ID { get; set; }
        public string Ability { get; set; }
        public bool IsHidden { get; set; }
        public int Slot { get; set; }
    }
}