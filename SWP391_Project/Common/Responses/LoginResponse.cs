namespace SWP391_Project.Common.Responses;

public class LoginResponse
{
    public string RoleName { get; set; }
    public string AccessToken { get; set; } = null!;
}