using Domain.DiamondEntities;
using Microsoft.EntityFrameworkCore;

namespace SWP391_Project.Data.Databases.DiamondSystem
{
    public class DiamondContext : DbContext
    {
        public DiamondContext() { }
        public DiamondContext(DbContextOptions<DiamondContext> options) : base(options)
        { }

        #region DbSet
        public DbSet<Diamond> Diamonds { get; set; }
        public DbSet<DiamondCheck> DiamondGIAChecks { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;database=SWP391_DiamondSystem;uid=sa;pwd=12345;TrustServerCertificate=True;MultipleActiveResultSets=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
    
