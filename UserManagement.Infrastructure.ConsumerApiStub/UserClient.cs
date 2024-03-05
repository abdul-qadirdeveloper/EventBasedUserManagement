using Newtonsoft.Json;
using System.Text;
using UserManagement.Application.ConsumerApiStub;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.ConsumerApiStub
{
    public class UserClient : IUserClient
    {
        private readonly HttpClient _httpClient;

        public UserClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateUserAsync(User user)
        {
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("User", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateUserAsync(User user)
        {
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("User", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeactivateUserAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"User/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
