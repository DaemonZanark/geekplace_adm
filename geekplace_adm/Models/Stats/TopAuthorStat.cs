using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace geekplace_adm.Models.Stats;

public class TopAuthorStat
{
    [JsonPropertyName("auteur")]
    public string Auteur { get; set; } = string.Empty;

    [JsonPropertyName("followers")]
    public int Followers { get; set; }
}