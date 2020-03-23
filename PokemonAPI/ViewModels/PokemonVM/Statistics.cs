using PokemonAPI.Models.PokeAPI.PokemonSpecifics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.ViewModels.PokemonVM
{
    public class Statistics
    {
        public Statistics()
        {

        }

        public Statistics(int Experience, int Weight, int Height, List<Stat> BaseStats)
        {
            this.Experience = Experience;
            this.Weight = Weight;
            this.Height = Height;
            this.BaseStats = BaseStats;
        }

        public int Experience { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public List<Stat> BaseStats { get; set; }
    }
}