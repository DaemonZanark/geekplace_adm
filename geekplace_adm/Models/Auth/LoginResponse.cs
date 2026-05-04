using System;
using System.Collections.Generic;
using System.Text;

namespace geekplace_adm.Models.Auth;

public class LoginResponse
{
    public string Token { get; set; } = string.Empty;
    public AuthUser? User { get; set; }
    public string Message { get; set; } = string.Empty;
}