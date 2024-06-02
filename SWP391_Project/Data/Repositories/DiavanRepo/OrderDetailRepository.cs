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
    public class OrderDetailRepository : GenericRepository<OrderDetail>
    {
        public OrderDetailRepository() { }

        public async Task<List<OrderDetail>> GetOrderDetailsWithOrderAndServiceAndResultAndValuationStaff()
        {
            return await _dbSet.Include(_ => _.Order).Include(_ => _.Service).Include(_ => _.Result).Include(_ => _.ValuationStaff).ToListAsync();
        }
    }
}
