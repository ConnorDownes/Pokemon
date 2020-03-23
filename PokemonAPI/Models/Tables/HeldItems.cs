using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.Models.Tables
{
    public class HeldItems
    {
        public int ID { get; set; }
        public string ItemName { get; set; }

        public List<HeldItemDetails> HeldItemDetails { get; set; }
    }
}