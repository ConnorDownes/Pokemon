using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.Models.Tables
{
    public class Moves
    {
        public int ID { get; set; }
        public string Move { get; set; }

        public List<MoveDetails> MoveDetails { get; set; }
    }
}