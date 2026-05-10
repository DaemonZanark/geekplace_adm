using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace geekplace_adm.Services
{
    public class TagService
    {
        private readonly HttpClient _http;

        public TagService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<TagDto>> GetTagsAsync()
        {
            return await _http.GetFromJsonAsync<List<TagDto>>("api/v1/tags") ?? new();
        }

        public async Task DeleteTagAsync(int tagId)
        {
            var response = await _http.DeleteAsync($"api/v1/tags/{tagId}");
            response.EnsureSuccessStatusCode();
        }
    }

    public class TagDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("articles")]
        public List<TagArticleDto> Articles { get; set; } = new();

        [JsonIgnore]
        public int ArticlesCount => Articles?.Count ?? 0;
    }

    public class TagArticleDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;
    }
}