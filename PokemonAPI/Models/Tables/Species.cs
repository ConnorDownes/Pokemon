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
        public Colours Colour { get; set; }
        public List<EggGroups> EggGroups { get; set; }
        public List<FlavorTextEntries> FlavorTextEntries { get; set; }
        public Generations IntroducedIn { get; set; }
        public GrowthRates GrowthRate { get; set; }
        public Habitats Habitat { get; set; }
    }
}