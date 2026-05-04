using System;
using System.Collections.Generic;
using System.Text;

namespace geekplace_adm.Models.Auth;

public class LoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string DeviceName { get; set; } = "geekplace-admin";

}