using Data.DiavanModels;
using Data.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
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
        public async Task<List<Service>> GetAllServices()
        {
            return await _dbSet.Include(x=>x.ServiceDetails).ToListAsync();
        }
    }
}
