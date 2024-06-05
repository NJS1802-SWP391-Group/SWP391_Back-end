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
using Business.Constants;

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

        public async Task<IServiceResult> Signup(SignupRequest req)
        {
            try
            {
                var user = _unitOfWork.UserRepository.GetAll().Where(u => u.UserName == req.Username).FirstOrDefault();
                if (user is not null)
                {
                    return new ServiceResult(500, "username or email already exists");
                }

                var account = new Account
                {
                    UserName = req.Username,
                    Password = SecurityUtil.Hash(req.Password),
                    Status = "Active",
                    RoleName = "Customer"
                };

                var customer = new Customer
                {
                    AccountId = account.AccountId,
                    Account = account,
                    Address = req.Address,
                    CCCD = req.CCCD,
                    Dob = DateTimeHelper.ParseDay(req.Dob),
                    Email = req.Email,
                    FirstName = req.FirstName,
                    LastName = req.LastName,
                    PhoneNumber = req.PhoneNumber,
                    Status = "Active"
                };

                _unitOfWork.CustomerRepository.PrepareCreate(customer);

                var cusRes = await _unitOfWork.CustomerRepository.SaveAsync();

                if (cusRes > 0)
                {
                    return new ServiceResult(200, "Sign up complete");

                }
                return new ServiceResult(500, "Sign up fail");
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public LoginResult Login(string userName, string password)
        {
            var user = _unitOfWork.UserRepository.GetAll().Where(u => u.UserName == userName).FirstOrDefault();

            if (user is null)
            {
                return new LoginResult
                {
                    RoleName = null,
                    Authenticated = false,
                    Token = null,
                };
            }

            var hash = SecurityUtil.Hash(password);
            if (!user.Password.Equals(hash))
            {
                return new LoginResult
                {
                    RoleName = null,
                    Authenticated = false,
                    Token = null,
                };
            }

            return new LoginResult
            {
                RoleName = user.RoleName,
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