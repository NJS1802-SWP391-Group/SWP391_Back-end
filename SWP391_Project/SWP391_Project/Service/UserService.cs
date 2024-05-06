using Core.Repositories;
using SWP391_Project.Databases.Models;
using SWP391_Project.Service.Interfaces;

namespace SWP391_Project.Service
{
    public class UserService:IUserService
    {
        private readonly IRepository<User, int> _userRepository;
        public UserService( ) { }
    }
}
