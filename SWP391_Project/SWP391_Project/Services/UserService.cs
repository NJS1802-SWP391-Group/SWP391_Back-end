using AutoMapper;
using SWP391_Project.Databases.DiavanSystem.Models;
using SWP391_Project.Databases.System.Models;
using SWP391_Project.Dtos;
using SWP391_Project.DTOs;
using SWP391_Project.Repositories.Interfaces;
using System.Data;

namespace SWP391_Project.Services
{
    public class UserService
    {
        private readonly IRepository<Account, int> _userRepository;
        private readonly IRepository<Customer, int> _customerRepository;
        private readonly IMapper _mapper;
        public UserService(IRepository<Account, int> userRepository, IMapper mapper, IRepository<Customer, int> customerRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<List<AccountModel>> GetAll()
        {
            try
            {
                var users = _userRepository.GetAll().ToList();
                var result = _mapper.Map<List<AccountModel>>(users);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AccountModel> GetUserByEmail(string email)
        {
            try
            {
                return _mapper.Map<AccountModel>(_userRepository.FindByCondition(x => x.UserName == email).FirstOrDefault());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}