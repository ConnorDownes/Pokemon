using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.Models.Tables
{
    public class HeldItemDetails
    {
        public int ID { get; set; }
        public int Rarity { get; set; }

        public Version Version { get; set; }
    }
}