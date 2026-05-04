using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace geekplace_adm.Models.Stats;

public class ActivityStatsResponse
{
    [JsonPropertyName("labels")]
    public List<JsonElement> RawLabels { get; set; } = new();

    [JsonPropertyName("articles")]
    public List<JsonElement> RawArticles { get; set; } = new();

    [JsonPropertyName("commentaires")]
    public List<JsonElement> RawCommentaires { get; set; } = new();

    [JsonPropertyName("likes")]
    public List<JsonElement> RawLikes { get; set; } = new();

    [JsonIgnore]
    public List<string> Labels => ExtractLabels();

    [JsonIgnore]
    public List<int> Articles => ExtractSeries(RawArticles);

    [JsonIgnore]
    public List<int> Commentaires => ExtractSeries(RawCommentaires);

    [JsonIgnore]
    public List<int> Likes => ExtractSeries(RawLikes);

    private List<string> ExtractLabels()
    {
        var labels = new List<string>();

        foreach (var element in RawLabels)
        {
            if (element.ValueKind == JsonValueKind.String)
                labels.Add(element.GetString() ?? string.Empty);
        }

        return labels;
    }

    private static List<int> ExtractSeries(List<JsonElement> raw)
    {
        var values = new List<int>();

        // On prend : string label, puis 3 entiers (articles / commentaires / likes)
        // Ton JSON répète ce pattern, on veut ici UNE valeur par label.
        // Là, on va prendre le premier nombre après chaque string.
        for (int i = 0; i < raw.Count;)
        {
            if (raw[i].ValueKind == JsonValueKind.String)
            {
                // premier élément après le label
                if (i + 1 < raw.Count && raw[i + 1].ValueKind == JsonValueKind.Number)
                {
                    if (raw[i + 1].TryGetInt32(out var v))
                        values.Add(v);
                    else
                        values.Add(0);
                }
                else
                {
                    values.Add(0);
                }

                i += 4; // on saute label + 3 nombres
            }
            else
            {
                i++;
            }
        }

        return values;
    }
}