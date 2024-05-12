using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
        public DbSet<RequestValuationForm> RequestValuationForms { get; set; }
        public DbSet<ScheduleForm> ScheduleForms { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<FinalReceipt> FinalReceipts{ get;set; }
        public DbSet<DiamondPrice> DiamondPrices { get; set; }
        public DbSet<ValuationReceipt> ValuationReceipts { get; set; }
        public DbSet<ValuationResult> ValuationResult { get; set; }
        public DbSet<Diamond_ValuationStaff> Diamond_ValuationStaff { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ValuationReceipt>()
                .HasOne(vr => vr.ConsultStaff)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ValuationResult>()
                .HasOne(vr => vr.Diamond)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<FinalReceipt>()
                .HasOne(vr => vr.ValuationResult)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Diamond_ValuationStaff>()
                .HasOne(vr => vr.ValuationStaff)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Diamond_ValuationStaff>()
                .HasOne(vr => vr.Diamond)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }


}
