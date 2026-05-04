using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace geekplace_adm.Models.Stats;

public class RecentStats
{
    [JsonPropertyName("articles_last_7d")]
    public int ArticlesLast7Days { get; set; }

    [JsonPropertyName("articles_last_30d")]
    public int ArticlesLast30Days { get; set; }

    [JsonPropertyName("comments_last_7d")]
    public int CommentsLast7Days { get; set; }

    [JsonPropertyName("comments_last_30d")]
    public int CommentsLast30Days { get; set; }
}