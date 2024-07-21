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
    public class AssigningOrderDetailRepository : GenericRepository<AssigningOrderDetail>
    {
        public AssigningOrderDetailRepository() { }

        public async Task<AssigningOrderDetail> GetByOrderDetailIDAndActive(int id)
        {
            return await _dbSet.Where(_ => _.OrderDetailid == id && _.Status.Equals("Active")).FirstOrDefaultAsync();
        }
    }
}
