using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace geekplace_adm.Services
{
    public class UserService
    {
        private readonly HttpClient _http;

        public UserService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<UserDto>> GetUsersAsync()
        {
            return await _http.GetFromJsonAsync<List<UserDto>>("api/v1/show_users") ?? new();
        }

        public async Task DeleteUserAsync(int userId)
        {
            var response = await _http.DeleteAsync($"api/v1/del_user/{userId}");
            response.EnsureSuccessStatusCode();
        }
    }

    public class UserDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("avatar")]
        public string? Avatar { get; set; }

        [JsonPropertyName("is_admin")]
        public int? IsAdmin { get; set; }

        [JsonIgnore]
        public bool IsAdminValue => IsAdmin == 1;
    }
}