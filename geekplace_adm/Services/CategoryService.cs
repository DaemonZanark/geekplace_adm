using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace geekplace_adm.Services
{
    public class CategoryService
    {
        private readonly HttpClient _http;

        public CategoryService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<CategoryDto>> GetCategoriesAsync()
        {
            return await _http.GetFromJsonAsync<List<CategoryDto>>("api/v1/category") ?? new();
        }


        public async Task DeleteCategoryAsync(int categoryId)
        {
            var response = await _http.DeleteAsync($"api/v1/category/{categoryId}");
            response.EnsureSuccessStatusCode();
        }
    }

    public class CategoryDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("articles")]
        public List<CategoryArticleDto> Articles { get; set; } = new();

        [JsonIgnore]
        public int ArticlesCount => Articles?.Count ?? 0;
    }

    public class CategoryArticleDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;
    }
}