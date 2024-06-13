using AutoMapper;
using Business.Constants;
using Common.DTOs;
using Data.Repositories;
using Data.Repositories.DiavanRepo;
using Domain.Exceptions;
using SWP391_Project.Domain.DiavanEntities;
using SWP391_Project.Dtos;
using System.Data;
using System.IdentityModel.Tokens.Jwt;

namespace SWP391_Project.Services
{
    public interface IUserService
    {
        public Task<IServiceResult> GetAll();
        public Task<IServiceResult> GetUserByUserName(string email);
    }

    public class UserService : IUserService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IMapper mapper)
        {
            _unitOfWork ??= new UnitOfWork();
            _mapper = mapper;
        }

        public async Task<AccountModel> GetUserInToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new BadRequestException("Authorization header is missing or invalid.");
            }
            // Decode the JWT token
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            // Check if the token is expired
            if (jwtToken.ValidTo < DateTime.UtcNow)
            {
                throw new BadRequestException("Token has expired.");
            }
            string userName = jwtToken.Claims.FirstOrDefault(c => c.Type == "email")?.Value;

            var user = _unitOfWork.UserRepository.GetAll().Where(x => x.UserName == userName).FirstOrDefault();
            if (user is null)
            {
                throw new BadRequestException("Can not found User");
            }
            return _mapper.Map<AccountModel>(user);
        }

        public async Task<IServiceResult> GetAll()
        {
            try
            {
                var users = _unitOfWork.UserRepository.GetAll().ToList();
                var result = _mapper.Map<List<AccountModel>>(users);
                return new ServiceResult(1, "Get all users", result);
            }
            catch (Exception ex)
            {
                return new ServiceResult(-1, ex.Message);
            }
        }

        public async Task<IServiceResult> GetUserByUserName(string username)
        {
            try
            {
                var result = _mapper.Map<AccountModel>(_unitOfWork.UserRepository.GetAll().Where(_ => _.UserName == username).FirstOrDefault());
                return new ServiceResult(1, "Get user by user name", result);
            }
            catch (Exception ex)
            {
                return new ServiceResult(-1, ex.Message);
            }
        }

        public async Task<IServiceResult> GetAllValuationStaff()
        {
            try
            {
                var result = _mapper.Map<List<AccountModel>>(await _unitOfWork.UserRepository.GetAllValuationStaffAsync());
                return new ServiceResult(200, "Get all valuation staff", result);
            }
            catch (Exception ex)
            {
                return new ServiceResult(-1, ex.Message);
            }
        }

        public async Task<CustomerModel> GetCustomerByEmail(string email)
        {
            try
            {
                var result = _mapper.Map<CustomerModel>(await _unitOfWork.CustomerRepository.GetCustomerByEmail(email));
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        

        public async Task<CustomerModel> GetCustomerById(int customerId)
        {
            try
            {
                var result = _mapper.Map<CustomerModel>(await _unitOfWork.CustomerRepository.GetByIdAsync(customerId));
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}