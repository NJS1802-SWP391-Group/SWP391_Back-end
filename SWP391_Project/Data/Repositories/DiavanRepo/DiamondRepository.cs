using Data.Repositories.Generic;
using Domain.DiamondEntities;
using Domain.DiavanEntities;
using Microsoft.EntityFrameworkCore;
using SWP391_Project.Data.Databases.DiavanSystem;
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
    }
}
