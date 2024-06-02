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
        public async Task<bool> UpdateListDetail(List<OrderDetail> orderDetails,int OrderId){
            var result = true;
            var list = await this.GetDetailByOrderId(OrderId);
            foreach (var item in list)
            {
                if (item.OrderId == null) { }
            }
            return result;
        }
        public async Task<List<OrderDetail>> GetDetailByOrderId(int OrderId)
        {
            var result = await _dbSet.Where(x=>x.OrderId == OrderId).ToListAsync();
            return result;
        }
    }
}
