using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAPI.Services.Interfaces
{
    public interface IDeserialise : IDisposable
    {
        T Deserialise<T>(string Content);
    }
}
