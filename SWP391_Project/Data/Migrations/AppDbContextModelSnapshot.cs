﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SWP391_Project.Data.Databases.DiavanSystem;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.DiavanEntities.Diamond", b =>
                {
                    b.Property<int>("DiamondId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiamondId"), 1L, 1);

                    b.Property<string>("Carat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Clarity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CutGrade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fluorescence")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Origin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Polish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Shape")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Symmetry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Value")
                        .HasColumnType("float");

                    b.HasKey("DiamondId");

                    b.ToTable("Diamond");
                });

            modelBuilder.Entity("SWP391_Project.Domain.DiavanEntities.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"), 1L, 1);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("SWP391_Project.Domain.DiavanEntities.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BlogId"), 1L, 1);

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("BlogName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BlogId");

                    b.HasIndex("AdminId");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("SWP391_Project.Domain.DiavanEntities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"), 1L, 1);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CCCD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("SWP391_Project.Domain.DiavanEntities.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Payment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quantity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusPayment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<double?>("TotalPay")
                        .HasColumnType("float");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("SWP391_Project.Domain.DiavanEntities.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailId"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Range")
                        .HasColumnType("float");

                    b.Property<int?>("ResultId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceDetailId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ValuationStaffId")
                        .HasColumnType("int");

                    b.Property<bool?>("isDiamond")
                        .HasColumnType("bit");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ServiceDetailId");

                    b.HasIndex("ValuationStaffId");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("SWP391_Project.Domain.DiavanEntities.Result", b =>
                {
                    b.Property<int>("ResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResultId"), 1L, 1);

                    b.Property<string>("Carat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CertificateStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Clarity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CutGrade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("DiamondValue")
                        .HasColumnType("float");

                    b.Property<DateTime?>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fluorescence")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDiamond")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderDetailId")
                        .HasColumnType("int");

                    b.Property<string>("Origin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Polish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Shape")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Signature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Symmetry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValueStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResultId");

                    b.HasIndex("OrderDetailId")
                        .IsUnique();

                    b.ToTable("Result");
                });

            modelBuilder.Entity("SWP391_Project.Domain.DiavanEntities.Service", b =>
                {
                    b.Property<int>("ServiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceID");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("SWP391_Project.Domain.DiavanEntities.ServiceDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("MaxRange")
                        .HasColumnType("float");

                    b.Property<double>("MinRange")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Status")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServiceDetail");
                });

            modelBuilder.Entity("SWP391_Project.Domain.DiavanEntities.Blog", b =>
                {
                    b.HasOne("SWP391_Project.Domain.DiavanEntities.Account", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("SWP391_Project.Domain.DiavanEntities.Customer", b =>
                {
                    b.HasOne("SWP391_Project.Domain.DiavanEntities.Account", "Account")
                        .WithOne("Customer")
                        .HasForeignKey("SWP391_Project.Domain.DiavanEntities.Customer", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("SWP391_Project.Domain.DiavanEntities.Order", b =>
                {
                    b.HasOne("SWP391_Project.Domain.DiavanEntities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("SWP391_Project.Domain.DiavanEntities.OrderDetail", b =>
                {
                    b.HasOne("SWP391_Project.Domain.DiavanEntities.Order", "Order")
                        .WithMany("DetailValuations")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SWP391_Project.Domain.DiavanEntities.ServiceDetail", "ServiceDetail")
                        .WithMany()
                        .HasForeignKey("ServiceDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SWP391_Project.Domain.DiavanEntities.Account", "ValuationStaff")
                        .WithMany()
                        .HasForeignKey("ValuationStaffId");

                    b.Navigation("Order");

                    b.Navigation("ServiceDetail");

                    b.Navigation("ValuationStaff");
                });

            modelBuilder.Entity("SWP391_Project.Domain.DiavanEntities.Result", b =>
                {
                    b.HasOne("SWP391_Project.Domain.DiavanEntities.OrderDetail", "OrderDetail")
                        .WithOne("Result")
                        .HasForeignKey("SWP391_Project.Domain.DiavanEntities.Result", "OrderDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderDetail");
                });

            modelBuilder.Entity("SWP391_Project.Domain.DiavanEntities.ServiceDetail", b =>
                {
                    b.HasOne("SWP391_Project.Domain.DiavanEntities.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("SWP391_Project.Domain.DiavanEntities.Account", b =>
                {
                    b.Navigation("Customer");
                });

            modelBuilder.Entity("SWP391_Project.Domain.DiavanEntities.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("SWP391_Project.Domain.DiavanEntities.Order", b =>
                {
                    b.Navigation("DetailValuations");
                });

            modelBuilder.Entity("SWP391_Project.Domain.DiavanEntities.OrderDetail", b =>
                {
                    b.Navigation("Result");
                });
#pragma warning restore 612, 618
        }
    }
}
