using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace geekplace_adm.Models.Stats;

public class DashboardStatsResponse
{
    [JsonPropertyName("global")]
    public GlobalStats Global { get; set; } = new();

    [JsonPropertyName("engagement")]
    public EngagementStats Engagement { get; set; } = new();

    [JsonPropertyName("recent")]
    public RecentStats Recent { get; set; } = new();

    [JsonPropertyName("community")]
    public CommunityStats Community { get; set; } = new();
}