using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SWP391_Project.Databases.DiavanSystem.Models;
using SWP391_Project.Databases.System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP391_Project.Databases.System
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        #region DbSet
       
        public DbSet<Service> Services { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DetailValuation> DetailValuations { get; set; }
        public DbSet<OrderValuation> OrderValuations { get; set; }
        public DbSet<ValuationResult> ValuationObjects { get; set; }
        public DbSet<ValuationCertificate> ValuationResults { get; set; }

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

            modelBuilder.Entity<ValuationResult>()
               .HasOne(vo => vo.DetailValuation)
               .WithOne(dv => dv.ValuationResult)
               .HasForeignKey<ValuationResult>(vo => vo.DetailValuationId);

            modelBuilder.Entity<ValuationCertificate>()
                .HasOne(vo => vo.ValuationResult)
                .WithOne(dv => dv.ValuationCertificate)
                .HasForeignKey<ValuationCertificate>(vo => vo.ValuationCertificateId);
        }
    }


}
