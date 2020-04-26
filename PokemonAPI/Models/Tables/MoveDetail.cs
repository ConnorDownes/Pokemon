using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.Models.Tables
{
    public class MoveDetail
    {
        public int ID { get; set; }
        public int LevelLearnedAt { get; set; }
        public string LearnMethod { get; set; }

        public Version Version { get; set; }
    }
}