using Lab1_4.Entities;
using System.Text.Json;

namespace Lab1_4.Services
{
    public class RateService(HttpClient client) : IRateService
    {
        //private HttpClient client;
        //public RateService() => client = new HttpClient();
        public async Task<IEnumerable<Rate>?> GetRates(DateTime date)
        {
            var response = await client.GetAsync(new Uri($"{date.ToString("yyyy-MM-dd")}&periodicity=0"));
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Rate>>(responseBody);
        }
    }
}
