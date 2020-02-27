using PokemonAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace PokemonAPI.Services
{
    public class HTTPClientService : IApiService
    {
        private readonly HttpClient _client;

        public HTTPClientService(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> CallApiAsync(string Endpoint, HttpMethod Method = default(HttpMethod), CancellationToken cancellationToken = default(CancellationToken))
        {
            //var response = await _client.GetAsync(Endpoint);
            using (var request = new HttpRequestMessage(Method ?? HttpMethod.Get, Endpoint))
            using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
            {
                var ApiResponse = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return ApiResponse;

                throw new Exception("Unsuccessful Request");
            }
        }
    }
}