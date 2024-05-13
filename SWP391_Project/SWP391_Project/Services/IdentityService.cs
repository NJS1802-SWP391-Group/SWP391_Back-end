using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SWP391_Project.Common.Requests;
using SWP391_Project.Dtos.Auth;
using SWP391_Project.Databases.Models;
using SWP391_Project.Exceptions;
using SWP391_Project.Helpers;
using SWP391_Project.Repositories;
using SWP391_Project.Settings;
using SWP391_Project.Repositories.Interfaces;

namespace SWP391_Project.Services;

public class IdentityService
{
    private readonly JwtSettings _jwtSettings;
    private readonly IRepository<User, int> _userRepository;
    private readonly IRepository<Role, int> _roleRepository;

    public IdentityService(IOptions<JwtSettings> jwtSettingsOptions, IRepository<User, int> userRepository, IRepository<Role, int> userRoleRepository)
    {
        _userRepository = userRepository;
        _jwtSettings = jwtSettingsOptions.Value;
        _roleRepository = userRoleRepository;
    }

    public async Task<bool> Signup(SignupRequest req)
    {
        var user = _userRepository.FindByCondition(u => u.Email == req.Email).FirstOrDefault();
        if (user is not null)
        {
            throw new BadRequestException("username or email already exists");
        }

        var userAdd = await _userRepository.AddAsync(new User
        {
            Password = SecurityUtil.Hash(req.Password),
            Email = req.Email,
            FirstName = req.FirstName,
            LastName = req.LastName,
            PhoneNumber = req.PhoneNumber,
            Address = req.Address,
            CCCD = req.CCCD,
            Status = "Active",
            RoleID = "US"
        });
        var res = await _userRepository.SaveChangesAsync();

        return res > 0;
    }

    public LoginResult Login(string email, string password)
    {
        var user = _userRepository.FindByCondition(u => u.Email == email).FirstOrDefault();


        if (user is null)
        {
            return new LoginResult
            {
                Authenticated = false,
                Token = null,
            };
        }
        var userRole = _roleRepository.FindByCondition(ur => ur.Id == user.RoleID).FirstOrDefault();

        user.Role = userRole!;

        var hash = SecurityUtil.Hash(password);
        if (!user.Password.Equals(hash))
        {
            return new LoginResult
            {
                Authenticated = false,
                Token = null,
            };
        }

        return new LoginResult
        {
            Authenticated = true,
            Token = CreateJwtToken(user),
        };
    }

    private SecurityToken CreateJwtToken(User user)
    {
        var utcNow = DateTime.UtcNow;
        var userRole = _roleRepository.FindByCondition(u => u.Id == user.RoleID).FirstOrDefault();
        var authClaims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
/*            new(JwtRegisteredClaimNames.Sub, user.UserName),*/
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(ClaimTypes.Role, userRole.RoleName),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(authClaims),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
            Expires = utcNow.Add(TimeSpan.FromHours(1)),
        };

        var handler = new JwtSecurityTokenHandler();

        var token = handler.CreateToken(tokenDescriptor);

        return token;
    }

    
}