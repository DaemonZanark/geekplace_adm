using System;
using System.Collections.Generic;
using System.Text;

namespace geekplace_adm.Models.Auth;

public class AuthUser
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int? Is_Admin { get; set; }
}