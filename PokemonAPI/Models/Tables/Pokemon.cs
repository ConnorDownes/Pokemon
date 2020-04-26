using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PokemonAPI.Models.Tables
{
    public class Pokemon
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Name { get; set; }
        public int BaseExperience { get; set; }
        public int Height { get; set; }
        public string LocationEncounters { get; set; }
        public int Order { get; set; }
        public int Weight { get; set; }
        public int SpeciesID { get; set; }
        public int EvolvesFromID { get; set; }
        public virtual Species Species { get; set; }
        public virtual ICollection<Sprite> Sprites { get; set; }
        public virtual ICollection<Type> Types { get; set; }
        public virtual ICollection<Stat> Stats { get; set; }
        public virtual ICollection<Move> Moves { get; set; }
        public virtual ICollection<Ability> Abilities { get; set; }
        public virtual ICollection<Pokemon> EvolvesTo { get; set; }
        public virtual Pokemon EvolvesFrom { get; set; }
    }
}