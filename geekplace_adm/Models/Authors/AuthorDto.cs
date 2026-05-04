using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace geekplace_adm.Models.Authors
{
    public class AuthorDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("avatar")]
        public string? Avatar { get; set; }

        [JsonPropertyName("articles_count")]
        public int ArticlesCount { get; set; }
    }
}