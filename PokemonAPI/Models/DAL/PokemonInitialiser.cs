using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PokemonAPI.Models.Tables;

namespace PokemonAPI.Models.DAL
{
    public class PokemonInitialiser : System.Data.Entity.DropCreateDatabaseIfModelChanges<PokemonContext>
    {
        protected override void Seed(PokemonContext context)
        {
            var Pokemon = new Pokemon() { 
                ID = 1590,
                Name = "Example",
                Species = new Species() { ID = 1, CaptureRate = 1 },
                Weight = 50
            };

            context.Pokemon.Add(Pokemon);
            context.SaveChanges();
        }
    }
}