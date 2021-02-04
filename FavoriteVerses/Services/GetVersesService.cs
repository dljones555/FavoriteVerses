using FavoriteVerses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace FavoriteVerses.Services
{
    public class GetVersesService
    {
        private readonly IConfiguration _config;
        public HttpClient Client { get; }

        public GetVersesService(HttpClient client, IConfiguration config)
        {
            _config = config;

            client.BaseAddress = new Uri(_config["GetVersesApi:BaseAddress"]);
            client.DefaultRequestHeaders.Add(_config["GetVersesApi:HeaderKey"], _config["GetVersesApi:HeaderValue"]);

            Client = client;
        }

        public async Task<VerseSearch> GetVerses(DateTime startDate, int pageSize)
        {
            var queryString = $"getversesbydate?siteId=1&startdate={startDate:MM/dd/yyyy}&PageSize={pageSize}";
            var response = await Client.GetAsync(queryString);

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<VerseSearch>(responseStream);
        }

        public Verse GetVerseById(IEnumerable<Verse> verses, string id)
        {
            var verse = verses.Where(v => v.Id == id).Single();
            return verse;
        }
    }
}
