using Data.Repositories.Generic;
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

        public List<ServiceDetail> GetAllActive()
        {
            return _dbSet.Where(_ => _.Status.ToLower().Trim() == "active").ToList();
        }
    }
}
