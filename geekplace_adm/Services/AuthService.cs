using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using geekplace_adm.Models.Auth;
using geekplace_adm.State;

namespace geekplace_adm.Services;

public class AuthService
{
    private readonly HttpClient _httpClient;
    private readonly AuthState _authState;

    public AuthService(HttpClient httpClient, AuthState authState)
    {
        _httpClient = httpClient;
        _authState = authState;
    }

    public async Task<(bool Success, string Message)> LoginAsync(string email, string password)
    {
        var payload = new
        {
            email,
            password
        };

        var response = await _httpClient.PostAsJsonAsync("api/v1/login", payload);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
            return (false, "Identifiants incorrects.");

        if (!response.IsSuccessStatusCode)
            return (false, $"Erreur API : {(int)response.StatusCode}");

        var result = await response.Content.ReadFromJsonAsync<LoginResponse>();

        if (result is null || result.User is null || string.IsNullOrWhiteSpace(result.Token))
            return (false, "Réponse de connexion invalide.");

        if (result.User.Is_Admin != 1)
            return (false, "Accès refusé : ce compte n'est pas administrateur.");

        _authState.SetSession(result.Token, result.User);

        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", result.Token);

        return (true, "Connexion réussie.");
    }

    public async Task LogoutAsync()
    {
        try
        {
            await _httpClient.PostAsync("api/v1/logout", null);
        }
        catch
        {
        }

        _httpClient.DefaultRequestHeaders.Authorization = null;
        _authState.Clear();
    }
}