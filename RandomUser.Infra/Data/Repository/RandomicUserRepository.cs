using RandomUser.Domain.Entities;
using RandomUser.Domain.Interfaces;
using RandomUser.Infra.Data.Entities;
using System.Text.Json;

namespace RandomUser.Infra.Data.Repository
{
    public class RandomicUserRepository : IRandomicUserRepository
    {
        Uri baseAddress = new Uri("https://randomuser.me/api/");
        private readonly HttpClient _httpClient;

        public RandomicUserRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = baseAddress;
        }

        public async Task<RandomicUser> GetRandomUser()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress);
            response.EnsureSuccessStatusCode();

            string jsonString = await response.Content.ReadAsStringAsync();
            
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var jsonObject = JsonSerializer.Deserialize<Result>(jsonString, options);

            return jsonObject.Results.FirstOrDefault();
        }
    }
}
