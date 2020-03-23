using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.Models.Tables
{
    public class Pokemon
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int BaseExperience { get; set; }
        public int Height { get; set; }
        public bool IsDefault { get; set; }
        public string LocationEncounters { get; set; }
        public int Order { get; set; }
        public string Species { get; set; }
        public int Weight { get; set; }

        public List<Sprites> sprites { get; set; }
        public List<Types> types { get; set; }
        public List<Stats> stats { get; set; }
        public List<Moves> moves { get; set; }
        public List<Forms> forms { get; set; }
        public List<HeldItems> held_items { get; set; }
        public List<GameIndices> game_indices { get; set; }
        public List<Abilities> abilities { get; set; }
    }
}