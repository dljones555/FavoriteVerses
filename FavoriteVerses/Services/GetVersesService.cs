using FavoriteVerses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;

namespace FavoriteVerses.Services
{
    public class GetVersesService
    {
        public HttpClient Client { get; }

        public GetVersesService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://emfservicesstage-api.azure-api.net/v1/");
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "d10161af8cf44f0c8267d571c682fda4");

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
