using Data.Repositories.DiavanRepo;
using Data.Repositories.Generic;
using Domain.DiamondEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.DiamondRepo
{
    public class DiamondCheckRepository : DiamondGenericRepository<DiamondCheck>
    {
        public DiamondCheckRepository() { }
        public async Task<DiamondCheck> GetDiamondsByIdCertificate(string Id)
        {
            var result = await _dbSet.Where(x => x.CertificateId == Id).Include(x => x.DiamondCheckValues).FirstOrDefaultAsync();
            return result;
        }
    }
}
