using Data.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using SWP391_Project.Data.Databases.DiavanSystem;
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
        
        public async Task<List<Account>> GetAllValuationStaffAsync()
        {
            return await _dbSet.Where(_ => _.Status.ToLower().Trim() == "active" && _.RoleName.ToLower().Trim() == "valuationstaff").ToListAsync();
        }
    }
}
