using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.Models.Tables
{
    public class Move
    {
        public int ID { get; set; }
        public string MoveName { get; set; }

        public List<MoveDetail> MoveDetails { get; set; }
    }
}