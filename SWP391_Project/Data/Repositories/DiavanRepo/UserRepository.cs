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

        public async Task<int> CountAccounts()
        {
            var count = await _dbSet.CountAsync();
            return count;
        }

        public async Task<int> CountConsultingStaffs()
        {
            var count = await _dbSet.Where(_ => _.RoleName.Equals("ConsultingStaff")).CountAsync();
            return count;
        }

        public async Task<int> CountValuatingStaffs()
        {
            var count = await _dbSet.Where(_ => _.RoleName.Equals("ValuationStaff")).CountAsync();
            return count;
        }

        public async Task<int> CountManagers()
        {
            var count = await _dbSet.Where(_ => _.RoleName.Equals("Manager")).CountAsync();
            return count;
        }        
        
        public async Task<int> CountAdmin()
        {
            var count = await _dbSet.Where(_ => _.RoleName.Equals("Admin")).CountAsync();
            return count;
        }

        public async Task<List<Account>> GetAllValuationStaffAsync()
        {
            return await _dbSet.Where(_ => _.Status.ToLower().Trim() == "active" && _.RoleName.ToLower().Trim() == "valuationstaff").ToListAsync();
        }
    }
}
