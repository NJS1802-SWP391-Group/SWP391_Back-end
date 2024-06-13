using Data.Repositories.Generic;
using Domain.DiavanEntities;
using Microsoft.EntityFrameworkCore;
using SWP391_Project.Domain.DiavanEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.DiavanRepo
{
    public class ResultImageRepository : GenericRepository<ResultImage>
    {
        public ResultImageRepository() { }

        public async Task<List<ResultImage>> GetByResultIdAsync(int id)
        {
            return await _dbSet.Where(_ => _.ResultID == id && _.Status.Trim().ToLower().Equals("active")).ToListAsync();
        }
    }
}
