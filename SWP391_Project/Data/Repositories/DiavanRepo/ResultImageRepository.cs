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
    public class ResultImageRepository : GenericRepository<Data.DiavanModels.ResultImage>
    {
        public ResultImageRepository() { }

        public async Task<List<ResultImage>> GetByResultIdAsync(int id)
        {
            return await _dbSet.Where(_ => _.ResultId == id && _.Status.Trim().ToLower().Equals("active")).ToListAsync();
        }
    }
}
