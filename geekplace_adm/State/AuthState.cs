using System;
using System.Collections.Generic;
using System.Text;
using geekplace_adm.Models.Auth;

namespace geekplace_adm.State;

public class AuthState
{
    public event Action? OnChange;
    public string? Token { get; private set; }
    public AuthUser? CurrentUser { get; private set; }

    public bool IsAuthenticated => !string.IsNullOrWhiteSpace(Token) && CurrentUser is not null;
    public bool IsAdmin => CurrentUser?.Is_Admin == 1;

    public void SetSession(string token, AuthUser user)
    {
        Token = token;
        CurrentUser = user;
        NotifyStateChanged();
    }

    public void Clear()
    {
        Token = null;
        CurrentUser = null;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}

