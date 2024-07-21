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
    public class ServiceDetailRepository : GenericRepository<ServiceDetail>
    {
        public ServiceDetailRepository() { }

        public async Task<List<ServiceDetail>> GetAllActiveAsync()
        {
            return await _dbSet.Where(_ => _.Status.ToLower().Trim() == "active").Include(_ => _.Service).ToListAsync();
        }

        public async Task<(ServiceDetail, double price)> GetDetailByServiceIdAndLengthAsync(int serviceID, double length)
        {
            var details = await _dbSet.Where(_ => _.ServiceId == serviceID && _.Status.ToLower().Trim() == "active").ToListAsync();
            foreach (var detail in details)
            {
                if (length > detail.MinRange && length <= detail.MaxRange)
                {
                    return (detail, detail.Price);
                }
            }
            var rs = details.Where(_ => _.MaxRange == 0 && _.ExtraPricePerMm > 0).FirstOrDefault();
            var price = rs.Price + (length - rs.MinRange) * rs.ExtraPricePerMm;
            return (rs, price);
        }
    }
}
