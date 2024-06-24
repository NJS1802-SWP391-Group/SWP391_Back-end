
using Domain.DiavanEntities;
using Microsoft.EntityFrameworkCore;
using SWP391_Project.Domain.DiavanEntities;

namespace SWP391_Project.Data.Databases.DiavanSystem
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        #region DbSet
        public DbSet<SystemDiamond> SystemDiamonds { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<ServiceDetail> ServiceDetails { get; set; }
        public DbSet<ResultImage> ResultImages { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;database=SWP391_DiavanSystem;uid=sa;pwd=12345;TrustServerCertificate=True;MultipleActiveResultSets=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
               .HasOne(c => c.Account)
               .WithOne(a => a.Customer)
               .HasForeignKey<Customer>(c => c.AccountId);

            modelBuilder.Entity<Result>()
               .HasOne(vo => vo.OrderDetail)
               .WithOne(dv => dv.Result)
               .HasForeignKey<Result>(vo => vo.OrderDetailId);
        }
    }


}
