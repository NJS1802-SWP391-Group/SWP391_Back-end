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
    public class DiamondRepository : GenericRepository<SystemDiamond>
    {
        public DiamondRepository() { }  

        public async Task<List<SystemDiamond>> GetDiamondByParameters(string origin, string shape, double carat, string color, 
            string clarity, string fluorescence, string symmetry, string polish, string cutGrade)
        {
            var rs = await _dbSet.Where(_ => _.Origin == origin && _.Shape == shape && _.Carat == carat && _.Color == color && _.Clarity == clarity
            && _.Fluorescence == fluorescence && _.Symmetry == symmetry && _.Polish == polish && _.CutGrade == cutGrade).ToListAsync();
            return rs;
        }
    }
}
