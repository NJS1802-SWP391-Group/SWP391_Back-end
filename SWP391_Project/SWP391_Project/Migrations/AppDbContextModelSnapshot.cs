﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SWP391_Project.Databases;

#nullable disable

namespace SWP391_Project.Migrations
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

            modelBuilder.Entity("SWP391_Project.Databases.Models.Blog", b =>
                {
                    b.Property<int>("BlogID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BlogID"), 1L, 1);

                    b.Property<string>("BlogName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("BlogID");

                    b.HasIndex("UserID");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("SWP391_Project.Databases.Models.Diamond", b =>
                {
                    b.Property<int>("DiamondID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiamondID"), 1L, 1);

                    b.Property<string>("Carat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Certificate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CertificateDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Clarity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClarityCharacteristic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CutGrade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("CutScore")
                        .HasColumnType("float");

                    b.Property<string>("Fluorescence")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Inscription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Measurement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Origin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Polish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Shape")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Symmetry")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiamondID");

                    b.ToTable("Diamond");
                });

            modelBuilder.Entity("SWP391_Project.Databases.Models.DiamondPrice", b =>
                {
                    b.Property<int>("DiamondPriceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiamondPriceID"), 1L, 1);

                    b.Property<int>("DiamondID")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("DiamondPriceID");

                    b.HasIndex("DiamondID");

                    b.ToTable("DiamondPrice");
                });

            modelBuilder.Entity("SWP391_Project.Databases.Models.FinalReceipt", b =>
                {
                    b.Property<int>("FinalReceiptID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FinalReceiptID"), 1L, 1);

                    b.Property<int>("ManagerID")
                        .HasColumnType("int");

                    b.Property<string>("Signature")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("ValuationResultID")
                        .HasColumnType("int");

                    b.HasKey("FinalReceiptID");

                    b.HasIndex("ManagerID");

                    b.HasIndex("ValuationResultID");

                    b.ToTable("FinalReceipt");
                });

            modelBuilder.Entity("SWP391_Project.Databases.Models.RequestValuationForm", b =>
                {
                    b.Property<int>("RequestValuationFormID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestValuationFormID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CCCD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("Quantity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RequestValuationFormID");

                    b.ToTable("RequestValuationForm");
                });

            modelBuilder.Entity("SWP391_Project.Databases.Models.Role", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("SWP391_Project.Databases.Models.ScheduleForm", b =>
                {
                    b.Property<int>("ScheduleFormID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduleFormID"), 1L, 1);

                    b.Property<int>("ConsultStaffID")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int?>("RequestValuationFormID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("ScheduleFormID");

                    b.HasIndex("ConsultStaffID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("RequestValuationFormID");

                    b.ToTable("ScheduleForm");
                });

            modelBuilder.Entity("SWP391_Project.Databases.Models.Service", b =>
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

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceID");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("SWP391_Project.Databases.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CCCD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("SWP391_Project.Databases.Models.ValuationReceipt", b =>
                {
                    b.Property<int>("ValuationReceiptID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ValuationReceiptID"), 1L, 1);

                    b.Property<int>("ConsultStaffID")
                        .HasColumnType("int");

                    b.Property<double>("ReceiptPrice")
                        .HasColumnType("float");

                    b.Property<int>("ScheduleFormID")
                        .HasColumnType("int");

                    b.Property<string>("Signature")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("ValuationReceiptID");

                    b.HasIndex("ConsultStaffID");

                    b.HasIndex("ScheduleFormID");

                    b.ToTable("ValuationReceipts");
                });

            modelBuilder.Entity("SWP391_Project.Databases.Models.ValuationReceiptDetail", b =>
                {
                    b.Property<int>("ValuationReceiptDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ValuationReceiptDetailID"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DiamondID")
                        .HasColumnType("int");

                    b.Property<double>("EstimatePrice")
                        .HasColumnType("float");

                    b.Property<int>("ServiceID")
                        .HasColumnType("int");

                    b.Property<string>("Signature")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ValuationReceiptID")
                        .HasColumnType("int");

                    b.HasKey("ValuationReceiptDetailID");

                    b.HasIndex("DiamondID");

                    b.HasIndex("ServiceID");

                    b.HasIndex("ValuationReceiptID");

                    b.ToTable("ValuationReceiptDetails");
                });

            modelBuilder.Entity("SWP391_Project.Databases.Models.ValuationReceiptDetail_ValuationStaff", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ValuationReceiptDetailID")
                        .HasColumnType("int");

                    b.Property<int>("ValuationStaffID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ValuationReceiptDetailID");

                    b.HasIndex("ValuationStaffID");

                    b.ToTable("ValuationReceiptDetail_ValuationStaff");
                });

            modelBuilder.Entity("SWP391_Project.Databases.Models.ValuationResult", b =>
                {
                    b.Property<int>("ValuationResultID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ValuationResultID"), 1L, 1);

                    b.Property<string>("Signature")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("ValuationReceiptDetailID")
                        .HasColumnType("int");

                    b.Property<int>("ValuationStaffID")
                        .HasColumnType("int");

                    b.HasKey("ValuationResultID");

                    b.HasIndex("ValuationReceiptDetailID");

                    b.HasIndex("ValuationStaffID");

                    b.ToTable("ValuationResult");
                });

            modelBuilder.Entity("SWP391_Project.Databases.Models.Blog", b =>
                {
                    b.HasOne("SWP391_Project.Databases.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SWP391_Project.Databases.Models.DiamondPrice", b =>
                {
                    b.HasOne("SWP391_Project.Databases.Models.Diamond", "Diamond")
                        .WithMany()
                        .HasForeignKey("DiamondID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diamond");
                });

            modelBuilder.Entity("SWP391_Project.Databases.Models.FinalReceipt", b =>
                {
                    b.HasOne("SWP391_Project.Databases.Models.User", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SWP391_Project.Databases.Models.ValuationResult", "ValuationResult")
                        .WithMany()
                        .HasForeignKey("ValuationResultID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Manager");

                    b.Navigation("ValuationResult");
                });

            modelBuilder.Entity("SWP391_Project.Databases.Models.ScheduleForm", b =>
                {
                    b.HasOne("SWP391_Project.Databases.Models.User", "ConsultStaff")
                        .WithMany()
                        .HasForeignKey("ConsultStaffID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SWP391_Project.Databases.Models.User", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID");

                    b.HasOne("SWP391_Project.Databases.Models.RequestValuationForm", "RequestValuationForm")
                        .WithMany()
                        .HasForeignKey("RequestValuationFormID");

                    b.Navigation("ConsultStaff");

                    b.Navigation("Customer");

                    b.Navigation("RequestValuationForm");
                });

            modelBuilder.Entity("SWP391_Project.Databases.Models.User", b =>
                {
                    b.HasOne("SWP391_Project.Databases.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("SWP391_Project.Databases.Models.ValuationReceipt", b =>
                {
                    b.HasOne("SWP391_Project.Databases.Models.User", "ConsultStaff")
                        .WithMany()
                        .HasForeignKey("ConsultStaffID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SWP391_Project.Databases.Models.ScheduleForm", "ScheduleForm")
                        .WithMany()
                        .HasForeignKey("ScheduleFormID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConsultStaff");

                    b.Navigation("ScheduleForm");
                });

            modelBuilder.Entity("SWP391_Project.Databases.Models.ValuationReceiptDetail", b =>
                {
                    b.HasOne("SWP391_Project.Databases.Models.Diamond", "Diamond")
                        .WithMany()
                        .HasForeignKey("DiamondID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SWP391_Project.Databases.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SWP391_Project.Databases.Models.ValuationReceipt", "ValuationReceipt")
                        .WithMany()
                        .HasForeignKey("ValuationReceiptID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diamond");

                    b.Navigation("Service");

                    b.Navigation("ValuationReceipt");
                });

            modelBuilder.Entity("SWP391_Project.Databases.Models.ValuationReceiptDetail_ValuationStaff", b =>
                {
                    b.HasOne("SWP391_Project.Databases.Models.ValuationReceiptDetail", "ValuationReceiptDetail")
                        .WithMany()
                        .HasForeignKey("ValuationReceiptDetailID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SWP391_Project.Databases.Models.User", "ValuationStaff")
                        .WithMany()
                        .HasForeignKey("ValuationStaffID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ValuationReceiptDetail");

                    b.Navigation("ValuationStaff");
                });

            modelBuilder.Entity("SWP391_Project.Databases.Models.ValuationResult", b =>
                {
                    b.HasOne("SWP391_Project.Databases.Models.ValuationReceiptDetail", "ValuationReceiptDetail")
                        .WithMany()
                        .HasForeignKey("ValuationReceiptDetailID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SWP391_Project.Databases.Models.User", "ValuationStaff")
                        .WithMany()
                        .HasForeignKey("ValuationStaffID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ValuationReceiptDetail");

                    b.Navigation("ValuationStaff");
                });
#pragma warning restore 612, 618
        }
    }
}
