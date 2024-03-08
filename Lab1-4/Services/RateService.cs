using Lab1_4.Entities;
using System.Net.Http.Json;

namespace Lab1_4.Services
{
    public class RateService : IRateService
    {
        private HttpClient _client;
        public RateService(HttpClient client) => _client = client;
        public async Task<IEnumerable<Rate>?> GetRates(DateTime date)
            => await _client.GetFromJsonAsync<IEnumerable<Rate>>($"?ondate={date:yyyy-MM-dd}&periodicity=0");
    }
}
