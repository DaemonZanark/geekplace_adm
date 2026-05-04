using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace geekplace_adm.Models.Authors
{
    public class AuthorArticlesDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("articles_count")]
        public int ArticlesCount { get; set; }

        [JsonPropertyName("articles")]
        public List<AuthorArticleItemDto> Articles { get; set; } = new();
    }
}