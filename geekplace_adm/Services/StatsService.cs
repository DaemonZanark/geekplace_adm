using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Json;
using geekplace_adm.Models.Stats;

namespace geekplace_adm.Services;

public class StatsService
{
    private readonly HttpClient _httpClient;

    public StatsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<DashboardStatsResponse?> GetDashboardStatsAsync()
    {
        return await _httpClient.GetFromJsonAsync<DashboardStatsResponse>("api/v1/stats");
    }
    public async Task<ActivityStatsResponse?> GetActivityStatsAsync()
    {
        return await _httpClient.GetFromJsonAsync<ActivityStatsResponse>("api/v1/stats/activity");
    }
}