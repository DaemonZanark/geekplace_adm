using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace geekplace_adm.Models.Stats;

public class EngagementStats
{
    [JsonPropertyName("likes_total")]
    public int LikesTotal { get; set; }

    [JsonPropertyName("avg_likes_per_article")]
    public double AvgLikesPerArticle { get; set; }

    [JsonPropertyName("comments_total")]
    public int CommentsTotal { get; set; }

    [JsonPropertyName("avg_comments_per_article")]
    public double AvgCommentsPerArticle { get; set; }
}