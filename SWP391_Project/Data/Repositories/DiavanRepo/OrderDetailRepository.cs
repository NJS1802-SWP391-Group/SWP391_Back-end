﻿using Data.Repositories.Generic;
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
            var result = await _dbSet.Where(x => x.OrderId == OrderId).ToListAsync();
            return result;
        }
        public async Task<List<OrderDetail>> GetOrderDetailsWithOrderAndServiceAndResultAndValuationStaff(string status)
        {
            return await _dbSet.Include(_ => _.Order).Include(_ => _.Service).Where(_ => _.Status == status).ToListAsync();
        }

        public async Task<List<OrderDetail>> GetOrderDetailsByValuStaff(int staffId, string status)
        {
            return await _dbSet.Include(_ => _.Service).Where(_ => _.ValuationStaffId == staffId && _.Status == status).ToListAsync();
        }

        public async Task<OrderDetail> GetByIdAndIsAssigning(int orderDetailId, string status)
        {
            var rs = await _dbSet.Where(_ => _.OrderDetailId == orderDetailId && _.Status == status).FirstOrDefaultAsync();
            return rs;
        }

        public async Task<List<OrderDetail>> GetCompletedOrderDetails(string status)
        {
            return await _dbSet.Include(_ => _.Service).Include(_ => _.Order).Include(_ => _.Result).Include(_ => _.ValuationStaff).Where(_ => _.Status == status).ToListAsync();
        }
    }
}
