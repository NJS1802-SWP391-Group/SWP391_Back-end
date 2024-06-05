namespace SWP391_Project.Common.Responses;

public class LoginResponse
{   
    public int? customerId {  get; set; }
    public string RoleName { get; set; }
    public string AccessToken { get; set; } = null!;
}