using PokemonAPI.Enums;
using PokemonAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAPI.Factories.Interfaces
{
    // TODO: Refactor,should either be more generic or interface should be called IDeserialiseFactory
    // Could have a generic IFactory which IDeserialise inherits
    public interface IFactory
    {
        IDeserialise Create(ApiResponseFormat Format);
    }
}
