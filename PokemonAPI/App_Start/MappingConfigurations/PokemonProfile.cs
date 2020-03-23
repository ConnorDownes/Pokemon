using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PokemonAPI.Models.PokeAPI.PokemonSpecifics;
using PokemonAPI.ViewModels.PokemonVM;
using PokemonAPI.Extensions;
using PokemonAPI.Models.PokeAPI.PokemonSpecies;

namespace PokemonAPI.App_Start.MappingConfigurations
{
    // This profile contains the mappings related to Pokemon
    public class PokemonProfile : Profile
    {
        public PokemonProfile()
        {
            CreateMap<Pokemon, Basic>()
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.name.Capitalise()));

            CreateMap<Pokemon, BasicWithImage>()
                .IncludeBase<Pokemon, Basic>()
                .ForMember(d => d.Image, opt => opt.MapFrom(src => src.sprites.front_default));

            CreateMap<Pokemon, Detailed>()
                .IncludeBase<Pokemon, Basic>()
                .ForMember(d => d.Stats, opt => opt.MapFrom(src => new Statistics(src.base_experience, src.weight, src.height, src.stats)));

            CreateMap<pokemonSpecies, SpeciesBasic>()
                .ForMember(d => d.Description, opt => opt.MapFrom(src => src.flavor_text_entries.Where(m => m.language.name.Equals("en")).Select(m => m.flavor_text).FirstOrDefault()))
                .ForMember(d => d.Genus, opt => opt.MapFrom(src => src.genera.Where(m => m.language.name.Equals("en")).Select(m => m.genus)));
        }
    }
}