using Data.Repositories.Generic;
using SWP391_Project.Data.Repositories;
using SWP391_Project.Domain.DiavanEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.DiavanRepo
{
    public class UserRepository : GenericRepository<Account>
    {
        public UserRepository() { }
    }
}
