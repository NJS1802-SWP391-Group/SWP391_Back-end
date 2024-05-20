//using AutoMapper;
//using SWP391_Project.Databases.System.Models;
//using SWP391_Project.Dtos;
//using SWP391_Project.DTOs;
//using SWP391_Project.Repositories.Interfaces;

//namespace SWP391_Project.Services
//{
//    public class UserService
//    {
//        private readonly IRepository<User, int> _userRepository;
//        private readonly IMapper _mapper;
//        private readonly IRepository<Role, int> _roleRepository;
//        public UserService(IRepository<User, int> userRepository, IMapper mapper, IRepository<Role, int> roleRepository)
//        {
//            _userRepository = userRepository;
//            _mapper = mapper;
//            _roleRepository = roleRepository;
//        }

//        public async Task<List<UserModel>> GetAll()
//        {
//            try
//            {
//                var users = _userRepository.GetAll().ToList();
//                var result = _mapper.Map<List<UserModel>>(users);
//                return result;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }

//        public async Task<UserModel> GetUserByEmail(string email)
//        {
//            try
//            {
//                return _mapper.Map<UserModel>(_userRepository.FindByCondition(x => x.Email == email).FirstOrDefault());
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }
//    }
//}
