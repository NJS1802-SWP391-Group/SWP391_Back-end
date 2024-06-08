namespace SWP391_Project.Common.Requests;

public class SignupRequest
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string CCCD { get; set; }
    public DateTime Dob {  get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
}