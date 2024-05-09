using Microsoft.EntityFrameworkCore;
using SWP391_Project.Databases.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP391_Project.Databases
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        #region DbSet
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Diamond> Diamonds { get; set; }
        public DbSet<SWP391_Project.Databases.Models.Service> Services { get; set; }
        public DbSet<RequestValuationForm> RequestValuationForms{ get; set; }
        public DbSet<ScheduleForm> ScheduleForms{ get; set; }

        #endregion
    }


}
