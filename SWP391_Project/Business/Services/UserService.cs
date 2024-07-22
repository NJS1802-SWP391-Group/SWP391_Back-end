using AutoMapper;
using Business.Constants;
using Common.DTOs;
using Data.Repositories;
using Data.Repositories.DiavanRepo;
using Domain.Exceptions;
using SWP391_Project.Dtos;
using System.Data;
using System.IdentityModel.Tokens.Jwt;

namespace SWP391_Project.Services
{
    public interface IUserService
    {
        public Task<IServiceResult> GetAll();
        public Task<IServiceResult> GetUserByUserName(string email);
        public Task<IServiceResult> CountAccounts();
        public Task<IServiceResult> CountConsultingStaffs();
        public Task<IServiceResult> CountValuatingStaffs();
        public Task<IServiceResult> CountManagers();
        public Task<IServiceResult> CountAdmins();
        public Task<IServiceResult> CountCustomers();
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
                throw new BadRequestException("Cannot find User");
            }
            return _mapper.Map<AccountModel>(user);
        }
        public async Task<AccountModel> GetCustomerInToken(string token)
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

            var user = _unitOfWork.CustomerRepository.GetAll().Where(x => x.Email == userName).FirstOrDefault();
            if (user is null)
            {
                throw new BadRequestException("Cannot find User");
            }

            var rs = new AccountModel
            {
                CustomerId = user.CustomerId,
                Password = user.Password,
                RoleName = "Customer",
                Status = user.Status,
                UserName = user.Email,
                AccountId =0,
            };

            return rs;
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

        public async Task<IServiceResult> CountAccounts()
        {
            try
            {
                var count = await _unitOfWork.UserRepository.CountAccounts();
                return new ServiceResult(200, "Count accounts", count);
            }
            catch (Exception ex)
            {
                return new ServiceResult(-1, ex.Message);
            }

        }

        public async Task<IServiceResult> CountConsultingStaffs()
        {
            try
            {
                var count = await _unitOfWork.UserRepository.CountConsultingStaffs();
                return new ServiceResult(200, "Count consulting staffs", count);
            }
            catch (Exception ex)
            {
                return new ServiceResult(-1, ex.Message);
            }

        }

        public async Task<IServiceResult> CountValuatingStaffs()
        {
            try
            {
                var count = await _unitOfWork.UserRepository.CountValuatingStaffs();
                return new ServiceResult(200, "Count valuating staffs", count);
            }
            catch (Exception ex)
            {
                return new ServiceResult(-1, ex.Message);
            }

        }

        public async Task<IServiceResult> CountManagers()
        {
            try
            {
                var count = await _unitOfWork.UserRepository.CountManagers();
                return new ServiceResult(200, "Count managers", count);
            }
            catch (Exception ex)
            {
                return new ServiceResult(-1, ex.Message);
            }

        }        
        
        public async Task<IServiceResult> CountAdmins()
        {
            try
            {
                var count = await _unitOfWork.UserRepository.CountAdmin();
                return new ServiceResult(200, "Count admins", count);
            }
            catch (Exception ex)
            {
                return new ServiceResult(-1, ex.Message);
            }

        }

        public async Task<IServiceResult> CountCustomers()
        {
            try
            {
                var count = await _unitOfWork.CustomerRepository.CountCustomers();
                return new ServiceResult(200, "Count customers", count);
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

        public async Task<IServiceResult> GetCustomerByUserName(string username)
        {
            try
            {
                var customer = _unitOfWork.CustomerRepository.GetAll().Where(_ => _.Email == username).FirstOrDefault();
                var result = new AccountModel
                {
                    UserName = customer.Email,
                    Password = customer.Password,
                    Status = customer.Status,
                    CustomerId = customer.CustomerId,
                    RoleName = "Customer"
                };
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