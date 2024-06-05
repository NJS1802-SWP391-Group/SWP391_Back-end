
using Microsoft.IdentityModel.Tokens;

namespace SWP391_Project.Dtos.Auth;

public class LoginResult
{
    public string RoleName { get; set; }
    public bool Authenticated { get; set; }
    public SecurityToken? Token { get; set; }
}