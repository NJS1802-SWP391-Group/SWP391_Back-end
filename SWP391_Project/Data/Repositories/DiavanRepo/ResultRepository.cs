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
    public class ResultRepository : GenericRepository<Result>
    {
        public ResultRepository() { }

        public async Task<List<Result>> GetAllActiveAsync()
        {
            return await _dbSet.Where(_ => _.Status.ToLower().Trim() == "active").ToListAsync();
        }

        public async Task<Result> GetByOrderDetailIdAsync(int id)
        {
            return await _dbSet.Where(_ => _.AssigningOrderDetails == null).FirstOrDefaultAsync();
            // ham can sua
        }  
    }
}
