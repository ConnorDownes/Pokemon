using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PokemonAPI.Services.Interfaces
{
    public interface IApiService
    {
        Task<string> CallApiAsync(string Endpoint, HttpMethod Method = default(HttpMethod), CancellationToken cancellationToken = default(CancellationToken));
    }
}
