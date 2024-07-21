﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.DiavanModels
{
    public partial class SWP391_DiavanSystemContext : DbContext
    {
        public SWP391_DiavanSystemContext()
        {
        }

        public SWP391_DiavanSystemContext(DbContextOptions<SWP391_DiavanSystemContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
=> optionsBuilder.UseSqlServer("data source=diavan-valuation.asia;initial catalog=SWP391_DiavanSystem;user id=sa;password=<YourStrong@Passw0rd>;trustservercertificate=true;multipleactiveresultsets=true;");
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AssigningOrderDetail> AssigningOrderDetails { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<SystemDiamond> Diamonds { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<ResultImage> ResultImages { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceDetail> ServiceDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.RoleName).IsRequired();

                entity.Property(e => e.Status).IsRequired();

                entity.Property(e => e.UserName).IsRequired();
            });

            modelBuilder.Entity<AssigningOrderDetail>(entity =>
            {
                entity.ToTable("AssigningOrderDetail");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.OrderDetail)
                    .WithMany(p => p.AssigningOrderDetails)
                    .HasForeignKey(d => d.OrderDetailid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AssigningOrderDetail_OrderDetail");

                entity.HasOne(d => d.Result)
                    .WithMany(p => p.AssigningOrderDetails)
                    .HasForeignKey(d => d.ResultId)
                    .HasConstraintName("FK_AssigningOrderDetail_Result");

                entity.HasOne(d => d.ValuationStaff)
                    .WithMany(p => p.AssigningOrderDetails)
                    .HasForeignKey(d => d.ValuationStaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AssigningOrderDetail_Account");
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog");

                entity.Property(e => e.BlogName).IsRequired();

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.Status).IsRequired();
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.Cccd)
                    .IsRequired()
                    .HasColumnName("CCCD");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.PhoneNumber).IsRequired();

                entity.Property(e => e.Status).IsRequired();
            });

            modelBuilder.Entity<SystemDiamond>(entity =>
            {
                entity.ToTable("SystemDiamond");
                entity.HasKey(e => e.DiamondId);
                entity.Property(e => e.Status).IsRequired();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Code).IsRequired();

                entity.HasOne(d => d.ConsultingStaff)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ConsultingStaffId)
                    .HasConstraintName("FK_Order_Account");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");

                entity.Property(e => e.Code).IsRequired();

                entity.Property(e => e.ServiceName).HasMaxLength(50);

                entity.Property(e => e.Status).IsRequired();

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId);

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_Service");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.ToTable("Result");

                entity.Property(e => e.Status).IsRequired();
            });

            modelBuilder.Entity<ResultImage>(entity =>
            {
                entity.ToTable("ResultImage");

                entity.Property(e => e.ResultImageId).HasColumnName("ResultImageID");

                entity.Property(e => e.ImageType).IsRequired();

                entity.Property(e => e.ImageUrl).IsRequired();

                entity.Property(e => e.ResultId).HasColumnName("ResultID");

                entity.Property(e => e.Status).IsRequired();

                entity.HasOne(d => d.Result)
                    .WithMany(p => p.ResultImages)
                    .HasForeignKey(d => d.ResultId);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Status).IsRequired();
            });

            modelBuilder.Entity<ServiceDetail>(entity =>
            {
                entity.ToTable("ServiceDetail");

                entity.Property(e => e.ServiceDetailId).HasColumnName("ServiceDetailID");

                entity.Property(e => e.Code).IsRequired();

                entity.Property(e => e.ExtraPricePerMm).HasColumnName("ExtraPricePerMM");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.Status).IsRequired();

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServiceDetails)
                    .HasForeignKey(d => d.ServiceId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}