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
    public class OrderRepository : GenericRepository<Order>
    {
        public OrderRepository() { }
        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var order = await _dbSet.Include(x=>x.DetailValuations).ThenInclude(y=>y.Service).Include(x=>x.Customer).FirstOrDefaultAsync(x=>x.OrderID==id);
            return order;
        }
        public async Task<List<Order>> GetAllOrder()
        {
            var orders = await _dbSet.Include(x=>x.Customer).ToListAsync();
            return orders;
        }
        public async Task<Order> GetOrderInforById(int id)
        {
            var order = await _dbSet.Include(x => x.Customer).FirstOrDefaultAsync(x=>x.OrderID==id);
            return order;
        }
        public async Task<Order> GetOrderByCode(string code)
        {
            var order = await _dbSet.Include(x => x.DetailValuations).ThenInclude(y => y.Service).FirstOrDefaultAsync(x => x.Code == code);
            return order;
        }
        public async Task<List<Order>> GetOrdersByCustomerId(int customerId)
        {
            var orders = await _dbSet.Where(x=>x.CustomerId==customerId).ToListAsync();
            return orders;
        }
    }
}
