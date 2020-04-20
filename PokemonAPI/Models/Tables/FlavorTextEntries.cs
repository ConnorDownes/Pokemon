using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.Models.Tables
{
    public class FlavorTextEntries
    {
        public int ID { get; set; }
        public string FlavorText { get; set; }
        public Languages Language { get; set; }
        public Version Version { get; set; }
    }
}