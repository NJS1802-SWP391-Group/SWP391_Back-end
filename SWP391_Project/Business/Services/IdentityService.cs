using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SWP391_Project.Helpers;
using SWP391_Project.Settings;
using SWP391_Project.Common.Requests;
using SWP391_Project.Dtos.Auth;
using Data.Repositories;
using SWP391_Project.Domain.DiavanEntities;

namespace SWP391_Project.Services
{
    public class IdentityService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly UnitOfWork _unitOfWork;

        public IdentityService(IOptions<JwtSettings> jwtSettingsOptions)
        {
            _unitOfWork ??= new UnitOfWork();
            _jwtSettings = jwtSettingsOptions.Value;
        }

        public async Task<bool> Signup(SignupRequest req)
        {
            var user = _unitOfWork.UserRepository.GetAll().Where(u => u.UserName == req.Username).FirstOrDefault();
            if (user is not null)
            {
                throw new Exception("username or email already exists");
            }

            var account = new Account
            {
                UserName = req.Username,
                Password = SecurityUtil.Hash(req.Password),
                Status = "Active",
                RoleName = "Customer"
            };

            _unitOfWork.UserRepository.PrepareCreate(account);

            _unitOfWork.CustomerRepository.PrepareCreate(new Customer
            {
                Account = account,
                Address = req.Address,
                CCCD = req.CCCD,
                Dob = DateTimeHelper.ChangeDateToDateTime(req.Dob),
                Email = req.Email,
                FirstName = req.FirstName,
                LastName = req.LastName,
                PhoneNumber = req.PhoneNumber,
                Status = "Active"
            });
            var res = await _unitOfWork.UserRepository.SaveAsync();

            var cusRes = await _unitOfWork.CustomerRepository.SaveAsync();

            return (res > 0 && cusRes > 0);
        }

        public LoginResult Login(string userName, string password)
        {
            var user = _unitOfWork.UserRepository.GetAll().Where(u => u.UserName == userName).FirstOrDefault();

            if (user is null)
            {
                return new LoginResult
                {
                    Authenticated = false,
                    Token = null,
                };
            }

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

        private SecurityToken CreateJwtToken(Account user)
        {
            var utcNow = DateTime.UtcNow;
            var authClaims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.NameId, user.AccountId.ToString()),
                new(JwtRegisteredClaimNames.Email, user.UserName),
                new(ClaimTypes.Role, user.RoleName),
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
}