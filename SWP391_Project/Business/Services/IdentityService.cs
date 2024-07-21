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
using Business.Constants;
using Data.DiavanModels;
using Common.Requests;

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
                var user = _unitOfWork.CustomerRepository.GetAll().Where(u => u.Email == req.Email).FirstOrDefault();
                if (user is not null)
                {
                    return new ServiceResult(500, "Email already exists");
                }

                var customer = new Customer
                {                   
                    Password = SecurityUtil.Hash(req.Password),
                    Address = req.Address,
                    Cccd = req.CCCD,
                    Dob = req.Dob,
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
                    return new ServiceResult(202, "Sign up successfully");
                }

                return new ServiceResult(500, "Sign up fail");
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }        
        
        public async Task<IServiceResult> SignupForSystem(SignupForSystemRequest req)
        {
            try
            {
                var user = _unitOfWork.UserRepository.GetAll().Where(u => u.UserName == req.UserName).FirstOrDefault();
                if (user is not null)
                {
                    return new ServiceResult(500, "Email already exists");
                }

                var account = new Account
                {
                    UserName = req.UserName,
                    Password = SecurityUtil.Hash(req.Password),
                    RoleName = req.RoleName,
                    Status = "Active"
                };

                _unitOfWork.UserRepository.PrepareCreate(account);

                var cusRes = await _unitOfWork.UserRepository.SaveAsync();

                if (cusRes > 0)
                {
                    return new ServiceResult(202, "Sign up successfully");
                }

                return new ServiceResult(500, "Sign up fail");
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public LoginResult LoginAsCustomer(string email, string password)
        {
            var user = _unitOfWork.CustomerRepository.GetAll().Where(u => u.Email == email && u.Status != "Inactive").FirstOrDefault();

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
                CustomerId = user.CustomerId,
                RoleName = "Customer",
                Authenticated = true,
                Token = CreateJwtTokenForCustomer(user),
            };
        }

        public LoginResult LoginAsSystem(string userName, string password)
        {
            var user = _unitOfWork.UserRepository.GetAll().Where(u => u.UserName == userName && u.Status != "Inactive").FirstOrDefault();

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
                CustomerId = user.AccountId,
                RoleName = user.RoleName,
                Authenticated = true,
                Token = CreateJwtToken(user),
            };
        }

        private SecurityToken CreateJwtTokenForCustomer(Customer user)
        {
            var utcNow = DateTime.UtcNow;
            var authClaims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.NameId, user.CustomerId.ToString()),
                new(JwtRegisteredClaimNames.Email, user.Email),
                new(ClaimTypes.Role, "Customer"),
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