using System.Collections.Generic;

namespace PokemonAPI.Models.PokeAPI.PokemonSpecies
{
    public class pokemonSpecies
    {
        public int base_happiness { get; set; }
        public int capture_rate { get; set; }
        public Result color { get; set; }
        public List<Result> egg_groups { get; set; }
        public EvolutionChain evolution_chain { get; set; }
        public Result evolves_from_species { get; set; }
        public List<FlavorTextEntry> flavor_text_entries { get; set; }
        public List<object> form_descriptions { get; set; }
        public bool forms_switchable { get; set; }
        public int gender_rate { get; set; }
        public List<Genera> genera { get; set; }
        public Result generation { get; set; }
        public Result growth_rate { get; set; }
        public Result habitat { get; set; }
        public bool has_gender_differences { get; set; }
        public int hatch_counter { get; set; }
        public int id { get; set; }
        public bool is_baby { get; set; }
        public string name { get; set; }
        public List<Name> names { get; set; }
        public int order { get; set; }
        public List<PalParkEncounter> pal_park_encounters { get; set; }
        public List<PokedexNumber> pokedex_numbers { get; set; }
        public Result shape { get; set; }
        public List<Variety> varieties { get; set; }
    }
}