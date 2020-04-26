using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.Models.Tables
{
    public class Stat
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Base { get; set; }
        public int Effort { get; set; }
    }
}