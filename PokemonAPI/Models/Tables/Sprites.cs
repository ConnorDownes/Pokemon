using PokemonAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.Models.Tables
{
    public class Sprites
    {
        public int ID { get; set; }
        public SpriteType SpriteTypes { get; set; }
        public string Url { get; set; }
    }
}