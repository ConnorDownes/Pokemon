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
        public int Weight { get; set; }
        public int SpeciesID { get; set; }
        public Species Species { get; set; }
        public List<Sprites> Sprites { get; set; }
        public List<Types> Types { get; set; }
        public List<Stats> Stats { get; set; }
        public List<Moves> Moves { get; set; }
        public List<Forms> Forms { get; set; }
        public List<HeldItems> HeldItems { get; set; }
        public List<GameIndices> GameIndices { get; set; }
        public List<Abilities> Abilities { get; set; }
        public List<Pokemon> EvolvesTo { get; set; }
        public Pokemon EvolvesFrom { get; set; }
    }
}