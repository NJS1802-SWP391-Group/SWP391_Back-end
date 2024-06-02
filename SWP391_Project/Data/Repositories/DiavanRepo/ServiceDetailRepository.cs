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
    public class ServiceDetailRepository : GenericRepository<ServiceDetail>
    {
        public ServiceDetailRepository() { }

        public async Task<List<ServiceDetail>> GetAllActiveAsync()
        {
            return await _dbSet.Where(_ => _.Status.ToLower().Trim() == "active").ToListAsync();
        }

        public async Task<(ServiceDetail, double price)> GetDetailByServiceIdAndLengthAsync(int serviceID, double length)
        {
            var details = await _dbSet.Where(_ => _.ServiceID == serviceID && _.Status.ToLower().Trim() == "active").ToListAsync();
            foreach (var detail in details)
            {
                if (length > detail.MinRange && length <= detail.MaxRange)
                {
                    return (detail, detail.Price);
                }
            }
            var rs = details.Where(_ => _.MaxRange == 0 && _.ExtraPricePerMM > 0).FirstOrDefault();
            var price = rs.Price + (length - rs.MinRange) * rs.ExtraPricePerMM;
            return (rs, price);
        }
    }
}
