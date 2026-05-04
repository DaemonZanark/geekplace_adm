using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace geekplace_adm.Models.Stats;

public class GlobalStats
{
    [JsonPropertyName("articles_total")]
    public int ArticlesTotal { get; set; }

    [JsonPropertyName("articles_draft")]
    public int ArticlesDraft { get; set; }

    [JsonPropertyName("views_total")]
    public int ViewsTotal { get; set; }

    [JsonPropertyName("views_moyenne")]
    public double ViewsMoyenne { get; set; }
}