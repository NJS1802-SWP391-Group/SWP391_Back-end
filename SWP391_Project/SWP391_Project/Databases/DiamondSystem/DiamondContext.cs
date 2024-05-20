using Microsoft.EntityFrameworkCore;
using SWP391_Project.Databases.DiamondSystem.Models;
using SWP391_Project.Databases.System;
using SWP391_Project.Databases.System.Models;

namespace SWP391_Project.Databases.DiamondSystem
{
    public class DiamondContext : DbContext
    {
        public DiamondContext(DbContextOptions<DiamondContext> options) : base(options)
        { }
        #region DbSet
        public DbSet<Diamond> diamonds { get; set; }
        public DbSet<Source> sources { get; set; }


        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
    
