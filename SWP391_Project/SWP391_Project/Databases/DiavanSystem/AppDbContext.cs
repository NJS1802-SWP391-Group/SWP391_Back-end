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
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        #region DbSet
       
        public DbSet<Service> Services { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DetailValuation> DetailValuations { get; set; }
        public DbSet<OrderValuation> OrderValuations { get; set; }
        public DbSet<TotalCertificate> TotalCertificates { get; set; }
        public DbSet<ValuationObject> ValuationObjects { get; set; }
        public DbSet<ValuationResult> ValuationResults { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }


}
