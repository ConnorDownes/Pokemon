using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.Models.Tables
{
    public class FlavorTextEntry
    {
        public int ID { get; set; }
        public string FlavorText { get; set; }
        public int LanguageID { get; set; }
        public int VersionID { get; set; }
        public virtual Language Language { get; set; }
        public virtual Version Version { get; set; }
    }
}