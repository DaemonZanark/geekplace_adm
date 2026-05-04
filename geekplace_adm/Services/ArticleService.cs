using geekplace_adm.Models.Authors;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace geekplace_adm.Services
{
    public class ArticleService
    {
        private readonly HttpClient _http;

        public ArticleService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ArticleListResponse?> GetArticlesAsync(int page = 1)
        {
            return await _http.GetFromJsonAsync<ArticleListResponse>($"api/v1/articles?page={page}");
        }
        public async Task<ArticleDetailDto?> GetArticleBySlugAsync(string slug)
        {
            return await _http.GetFromJsonAsync<ArticleDetailDto>($"api/v1/articles/{slug}");
        }
        public async Task DeleteCommentAsync(int commentId)
        {
            var response = await _http.DeleteAsync($"api/v1/comments/{commentId}");
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteArticleAsync(int articleId)
        {
            var response = await _http.DeleteAsync($"api/v1/articles/{articleId}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<AuthorDto>> GetAuthorsAsync()
        {
            return await _http.GetFromJsonAsync<List<AuthorDto>>("api/v1/authors") ?? new List<AuthorDto>();
        }

        public async Task<AuthorArticlesDto?> GetAuthorArticlesAsync(int userId)
        {
            return await _http.GetFromJsonAsync<AuthorArticlesDto>($"api/v1/authors/{userId}/articles");
        }
    }

    public class ArticleListResponse
    {
        [JsonPropertyName("current_page")]
        public int Current_Page { get; set; }

        [JsonPropertyName("data")]
        public List<ArticleDto> Data { get; set; } = new();

        [JsonPropertyName("last_page")]
        public int Last_Page { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("per_page")]
        public int Per_Page { get; set; }

        [JsonPropertyName("from")]
        public int? From { get; set; }

        [JsonPropertyName("to")]
        public int? To { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; } = string.Empty;

        [JsonPropertyName("first_page_url")]
        public string First_Page_Url { get; set; } = string.Empty;

        [JsonPropertyName("last_page_url")]
        public string Last_Page_Url { get; set; } = string.Empty;

        [JsonPropertyName("next_page_url")]
        public string? Next_Page_Url { get; set; }

        [JsonPropertyName("prev_page_url")]
        public string? Prev_Page_Url { get; set; }

        [JsonPropertyName("links")]
        public List<ArticlePaginationLinkDto> Links { get; set; } = new();
    }

    public class ArticleDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("user_id")]
        public int User_Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("slug")]
        public string Slug { get; set; } = string.Empty;

        [JsonPropertyName("content")]
        public string? Content { get; set; }

        [JsonPropertyName("image")]
        public string? Image { get; set; }

        [JsonPropertyName("draft")]
        public bool Draft { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime Created_At { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime Updated_At { get; set; }

        [JsonPropertyName("views_count")]
        public int Views_Count { get; set; }

        [JsonPropertyName("user")]
        public ArticleUserDto? User { get; set; }

        [JsonPropertyName("categories")]
        public List<ArticleCategoryDto> Categories { get; set; } = new();

        [JsonPropertyName("tags")]
        public List<ArticleTagDto> Tags { get; set; } = new();
    }

    public class ArticleUserDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }

    public class ArticleCategoryDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }

    public class ArticleTagDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }

    public class ArticlePaginationLinkDto
    {
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; } = string.Empty;

        [JsonPropertyName("page")]
        public int? Page { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }
    }
    public class ArticleDetailDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("slug")]
        public string Slug { get; set; } = string.Empty;

        [JsonPropertyName("content")]
        public string? Content { get; set; }

        [JsonPropertyName("views_count")]
        public int Views_Count { get; set; }

        [JsonPropertyName("reading_time")]
        public int Reading_Time { get; set; }

        [JsonPropertyName("auteur")]
        public ArticleUserDto? Auteur { get; set; }

        [JsonPropertyName("categories")]
        public List<ArticleCategoryDto> Categories { get; set; } = new();

        [JsonPropertyName("tags")]
        public List<ArticleTagDto> Tags { get; set; } = new();

        [JsonPropertyName("commentaires")]
        public List<ArticleDetailCommentDto> Commentaires { get; set; } = new();

        [JsonPropertyName("created_at")]
        public string Created_At { get; set; } = string.Empty;

        [JsonIgnore]
        public DateTime CreatedAtDateTime =>
            DateTime.TryParse(Created_At, out var dt) ? dt : DateTime.MinValue;
    }

    public class ArticleDetailCommentDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("user_id")]
        public int? User_Id { get; set; }

        [JsonPropertyName("article_id")]
        public int? Article_Id { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;

        [JsonPropertyName("created_at")]
        public string Created_At { get; set; } = string.Empty;

        [JsonPropertyName("user")]
        public ArticleUserDto? User { get; set; }

        [JsonIgnore]
        public DateTime CreatedAtDateTime =>
            DateTime.TryParse(Created_At, out var dt) ? dt : DateTime.MinValue;
    }

}