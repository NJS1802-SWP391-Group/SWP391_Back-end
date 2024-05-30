using Data.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using SWP391_Project.Data.Databases.DiavanSystem;
using SWP391_Project.Domain.DiavanEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.DiavanRepo
{
    public class ServiceRepository : GenericRepository<Service>
    {
        public ServiceRepository() { }

        public async Task<List<Service>> GetAllActiveAsync()
        {
            return await _dbSet.Where(_ => _.Status.ToLower().Trim() == "active").ToListAsync();
        }
    }
}
