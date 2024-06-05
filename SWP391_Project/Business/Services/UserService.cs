using AutoMapper;
using Business.Constants;
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
    }
}