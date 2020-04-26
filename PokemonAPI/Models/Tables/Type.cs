using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.Models.Tables
{
    public class Type
    {
        public int ID { get; set; }
        public int Slot { get; set; }
        public string TypeName { get; set; }
    }
}