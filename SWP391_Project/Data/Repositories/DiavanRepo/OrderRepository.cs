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
    public class OrderRepository : GenericRepository<Order>
    {
        public OrderRepository() { }
        public async Task<int> CountOrders()
        {
            var count = await _dbSet.CountAsync();
            return count;
        }
        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var order = await _dbSet.Include(x=>x.OrderDetails).ThenInclude(x=>x.Service).Include(x=>x.Customer).FirstOrDefaultAsync(x=>x.OrderId==id);
            return order;
        }
        public async Task<List<Order>> GetAllOrder()
        {
            var orders = await _dbSet.Include(x=>x.Customer).ToListAsync();
            return orders;
        }
        public async Task<Order> GetOrderInforById(int id)
        {
            var order = await _dbSet.Include(x => x.Customer).FirstOrDefaultAsync(x=>x.OrderId==id);
            return order;
        }
        public async Task<Order> GetOrderByCode(string code)
        {
            var order = await _dbSet.Include(x => x.OrderDetails).ThenInclude(y => y.Service).FirstOrDefaultAsync(x => x.Code == code);
            return order;
        }
        public async Task<List<Order>> GetOrdersByCustomerId(int customerId)
        {
            var orders = await _dbSet.Where(x=>x.CustomerId==customerId).Include(x=>x.Customer).Include(x=>x.OrderDetails).ThenInclude(y=>y.Service).ToListAsync();
            return orders;
        }
    }
}
