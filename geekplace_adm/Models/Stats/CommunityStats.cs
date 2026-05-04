using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace geekplace_adm.Models.Stats;

public class CommunityStats
{
    [JsonPropertyName("users_total")]
    public int UsersTotal { get; set; }

    [JsonPropertyName("auteurs_actifs")]
    public int AuteursActifs { get; set; }

    [JsonPropertyName("subscriptions_total")]
    public int SubscriptionsTotal { get; set; }

    [JsonPropertyName("subscriptions_last_7d")]
    public int SubscriptionsLast7Days { get; set; }

    [JsonPropertyName("top_auteurs")]
    public List<TopAuthorStat> TopAuteurs { get; set; } = new();
}