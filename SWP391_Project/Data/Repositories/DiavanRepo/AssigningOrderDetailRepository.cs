﻿using Data.DiavanModels;
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
            return await _dbSet.Include(_ => _.Result).Include(_ => _.ValuationStaff).Include(_ => _.OrderDetail).Where(_ => _.OrderDetailid == id && _.Status.Equals("Active")).FirstOrDefaultAsync();
        }        
        
        public async Task<AssigningOrderDetail> GetByStaffIDAndActive(int id)
        {
            return await _dbSet.Include(_ => _.Result).Include(_ => _.ValuationStaff).Include(_ => _.OrderDetail).Where(_ => _.ValuationStaffId == id && _.Status.Equals("Active")).FirstOrDefaultAsync();
        }
    }
}
