using Data.DiavanModels;
using Data.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
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
            // ham can sua
            var result = await _dbSet.Include(_ => _.AssigningOrderDetails).Include(_ => _.Order).Where(x => x.OrderId == OrderId).ToListAsync();
            return result;
        }
        public async Task<List<OrderDetail>> GetOrderDetailsWithOrderAndServiceAndResultAndValuationStaff(string statusAssigning, string statusReassigning)
        {
            // ham can sua
            return await _dbSet.Include(_ => _.Service).ThenInclude(_ => _.ServiceDetails)
                .Include(_ => _.Order)
                .Where(_ => _.Status == statusAssigning || _.Status == statusReassigning).ToListAsync();
        }

        public async Task<List<OrderDetail>> GetOrderDetailsByValuStaff(string status)
        {
           // ham can sua
            return await _dbSet.Include(_ => _.Service).ThenInclude(_ => _.ServiceDetails).Where(_ => _.Status == status).ToListAsync();
        }

        public async Task<OrderDetail> GetByIdAndIsAssigning(int orderDetailId, string statusAssigning, string statusReassigning)
        {
            var rs = await _dbSet.Where(_ => _.OrderDetailId == orderDetailId && (_.Status == statusAssigning || _.Status == statusReassigning)).FirstOrDefaultAsync();
            return rs;
        }

        public async Task<OrderDetail> GetByIdAndIsValuatingAndHasResult(int orderDetailId, string status)
        {
            // Ham can sua
            var rs = await _dbSet.Where(_ => _.OrderDetailId == orderDetailId && _.Status == status).FirstOrDefaultAsync();
            return rs;
        }

        public async Task<OrderDetail> GetByIdAndIsCompletedAndHasResult(int orderDetailId, string statusCompleted, string statusFailed)
        {
            // Ham can sua
            var rs = await _dbSet.Where(_ => _.OrderDetailId == orderDetailId && (_.Status.Equals(statusCompleted) || _.Status.Equals(statusFailed)) && _.OrderDetailId != null).FirstOrDefaultAsync();
            return rs;
        }

        public async Task<List<OrderDetail>> GetCompletedOrderDetails(string statusCompleted, string statusFailed)
        {
            // Ham can sua
            return await _dbSet.Include(_ => _.Service).ThenInclude(_ => _.ServiceDetails).Include(_ => _.Order)
                               .Where(_ => _.Status.Equals(statusCompleted) || _.Status.Equals(statusFailed)).ToListAsync();
        }
        public async Task<int> GetTotalQuantity(int orderid)
        {
            var rs = (await _dbSet.Where(x=>x.OrderId == orderid).ToListAsync()).Count;
            return rs;
        }
        public async Task<double> GetTotalPrice(int orderid)
        {
            var rs = await _dbSet.Where(x => x.OrderId == orderid).SumAsync(x => x.Price);
            return rs;
        }
    }
}
