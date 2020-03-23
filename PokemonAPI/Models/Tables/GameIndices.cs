using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.Models.Tables
{
    public class GameIndices
    {
        public int ID { get; set; }
        public int GameIndex { get; set; }

        public Version Version { get; set; }
    }
}