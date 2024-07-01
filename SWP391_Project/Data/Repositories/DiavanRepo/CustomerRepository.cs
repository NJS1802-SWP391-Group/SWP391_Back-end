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
    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository() { }

        public async Task<int> CountCustomers()
        {
            var count = await _dbSet.CountAsync();
            return count;
        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            var rs = await _dbSet.Where(_ => _.Email.Equals(email)).FirstOrDefaultAsync();
            return rs;
        }

        public async Task<Customer> GetCustomerByIdIncludeOrder(string email)
        {
            var rs = await _dbSet.Where(_ => _.Email.Equals(email)).FirstOrDefaultAsync();
            return rs;
        }
    }
}
