using PokemonAPI.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Type = PokemonAPI.Models.Tables.Type;
using Version = PokemonAPI.Models.Tables.Version;

namespace PokemonAPI.Models.DAL
{
    public class PokemonContext : DbContext
    {
        public PokemonContext() : base("PokemonContext")
        {

        }

        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<EggGroup> EggGroups { get; set; }
        public DbSet<FlavorTextEntry> FlavorTextEntries { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Generation> Generations { get; set; }
        public DbSet<GrowthRate> GrowthRates { get; set; }
        public DbSet<Habitat> Habitats { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Move> Moves { get; set; }
        public DbSet<MoveDetail> MoveDetails { get; set; }
        public DbSet<Sprite> Sprites { get; set; }
        public DbSet<Stat> Stats { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Version> Versions { get; set; }
    }
}