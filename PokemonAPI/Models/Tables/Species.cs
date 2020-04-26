using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.Models.Tables
{
    public class Species
    {
        public int ID { get; set; }
        public int BaseHappiness { get; set; }
        public int CaptureRate { get; set; }
        public string Genera { get; set; }
        public bool HasGenderDifferences { get; set; }
        public int HatchStepCounter { get; set; }
        public bool IsBaby { get; set; }
        public int ColourID { get; set; }
        public int GenerationIntroducedID { get; set; }
        public int GrowthRateID { get; set; }
        public int HabitatID { get; set; }
        public virtual Colour Colour { get; set; }
        public virtual ICollection<EggGroup> EggGroups { get; set; }
        public virtual ICollection<FlavorTextEntry> FlavorTextEntries { get; set; }
        public virtual Generation GenerationIntroduced { get; set; }
        public virtual GrowthRate GrowthRate { get; set; }
        public virtual Habitat Habitat { get; set; }
    }
}