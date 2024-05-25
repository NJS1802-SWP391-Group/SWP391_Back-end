using SWP391_Project.Databases.DiamondSystem.Models;
using SWP391_Project.Databases.DiamondSystem;
using SWP391_Project.Databases.System;
using Microsoft.EntityFrameworkCore;
using SWP391_Project.Databases.DiavanSystem.Models;
using SWP391_Project.Databases.System.Models;
using SWP391_Project.Helpers;

namespace SWP391_Project.Databases
{
    public static class DatabaseInitialiserExtension
    {
        public static async Task InitialiseDatabaseAsync(this ModelBuilder modelBuilder)
        {
            using var dbContext = new AppDbContext();
            using var diamondContext = new DiamondContext();

            // Apply any pending migrations
            await dbContext.Database.MigrateAsync();
            await diamondContext.Database.MigrateAsync();

            // Seed the database if needed
            await SeedDatabaseAsync(dbContext, diamondContext);
        }

        private static async Task SeedDatabaseAsync(AppDbContext appDbContext, DiamondContext diamondContext)
        {
            // Add your database seeding logic here
            // For example:
            if (!await appDbContext.Accounts.AnyAsync())
            {
                // Seed users
                List<Account> accounts = new()
            {
                new Account
                {
                    UserName ="rootCT",
                    Password = SecurityUtil.Hash("12345"),
                    RoleName ="Customer",
                    Status = "Active"
                },
                new Account
                {
                    UserName="rootAD",
                    Password=SecurityUtil.Hash("12345"),
                    RoleName ="Admin",
                    Status = "Active"
                },
                new Account
                {
                    UserName ="rootVA",
                    Password =SecurityUtil.Hash("12345"),
                    RoleName ="ValuationStaff",
                    Status = "Active"
                },
                new Account
                {
                    UserName ="rootCS",
                    Password =SecurityUtil.Hash("12345"),
                    RoleName="ConsultingStaff",
                    Status = "Active"
                }
            };

                List<Customer> users = new()
            {
                new Customer
                {
                    Email = "KhanhKhongKhoc@gmail.com",
                    FirstName = "Khanh",
                    LastName = "KhongKhoc",
                    CCCD = "123456879",
                    Address = "Dong Nai",
                    PhoneNumber = "0907080907",
                    Status = "Active",
                    Dob  = new DateTime(2003, 6, 1),
                    Account = accounts[0]
                },
                new Customer
                {
                    FirstName = "Bao",
                    LastName = "BongBay",
                    Email = "BaoBongBay@gmail.com",
                    CCCD = "123456879",
                    Address = "TPHCM",
                    PhoneNumber = "0907080907",
                    Status = "Active",
                    Dob  = new DateTime(2003, 1, 1),
                    Account = accounts[0]
                },
                new Customer
                {
                    FirstName = "Huy",
                    LastName = "Le Quang",
                    Email = "lequanghuy@gmail.com",
                    CCCD = "123456879",
                    Address = "Dong Nai",
                    PhoneNumber = "0907080907",
                    Status = "Active",
                    Dob  = new DateTime(2003, 1, 1),
                    Account = accounts[0]
                },
                new Customer
                {
                    FirstName = "Luan",
                    LastName = "Vo Mong",
                    Email = "vomongluan@gmail.com",
                    CCCD = "123456879",
                    Address = "Dong Nai",
                    PhoneNumber = "0907080907",
                    Status = "Active",
                    Dob  = new DateTime(2003, 1, 1),
                    Account = accounts[0]
                },
                new Customer
                {
                    FirstName = "Tuan",
                    LastName = "Do Ngoc",
                    Email = "dongoctuan@gmail.com",
                    CCCD = "123456879",
                    Address = "Dong Nai",
                    PhoneNumber = "0907080907",
                    Status = "Active",
                    Dob  = new DateTime(2003, 1, 1),
                    Account = accounts[0]
                },
            };

                List<Service> services = new()
            {
                new Service
                {
                    Name = "Standard Valuation",
                    Description = "- The time it takes to send for valuation depends on the time of sending./n" +
                                  "- Service price list according to regulations.",
                    Status = "Active"
                },
                new Service
                {
                    Name = "Quick Valuation 48h",
                    Description = "- Inspection time is 48 working hours from the time the product is received./n" +
                                  "- Service price list according to regulations.",
                    Status = "Active"
                },
                new Service
                {
                    Name = "Quick Valuation 24h",
                    Description = "- Inspection time is 24 working hours from the time the product is received./n" +
                                  "- Service price list according to regulations.",
                    Status = "Active"
                },
                new Service
                {
                    Name = "Quick Valuation 4h",
                    Description = "- Inspection time is 4 working hours from the time the product is received./n" +
                                  "- Service price list according to regulations.",
                    Status = "Active"
                },
            };



                List<Blog> blogs = new()
            {
                new Blog
                {
                    BlogName = "This is a blog",
                    Content = "Hello world",
                    Admin = accounts[1],
                    Status = "Active"
                }
            };

                await appDbContext.AddRangeAsync(accounts);
                await appDbContext.AddRangeAsync(blogs);
                await appDbContext.AddRangeAsync(services);
                await appDbContext.AddRangeAsync(users);

                await appDbContext.SaveChangesAsync();
            }

            if (!await diamondContext.Diamonds.AnyAsync())
            {
                List<Diamond> diamonds = new()
            {
                new Diamond
                {
                    Origin = "Natural",
                    Shape = "Brilliant",
                    Carat = "1.50",
                    Color = "D",
                    Clarity = "IF",
                    Fluorescence = "None",
                    Symmetry = "Excellent",
                    Polish = "Excellent",
                    CutGrade = "Excellent",
                    Status = "Active",
                },
                new Diamond
                {
                    Origin = "Lab Grown",
                    Shape = "Square",
                    Carat = "2.10",
                    Color = "E",
                    Clarity = "VVS1",
                    Fluorescence = "Faint",
                    Symmetry = "Very Good",
                    Polish = "Very Good",
                    CutGrade = "Very Good",
                    Status = "Active",
                },
                new Diamond
                {
                    Origin = "Natural",
                    Shape = "Rectangular",
                    Carat = "3.25",
                    Color = "F",
                    Clarity = "VS2",
                    Fluorescence = "Medium",
                    Symmetry = "Good",
                    Polish = "Good",
                    CutGrade = "Good",
                    Status = "Active",
                },
                new Diamond
                {
                    Origin = "Lab Grown",
                    Shape = "Oval",
                    Carat = "1.75",
                    Color = "G",
                    Clarity = "SI1",
                    Fluorescence = "Strong",
                    Symmetry = "Fair",
                    Polish = "Fair",
                    CutGrade = "Fair",
                    Status = "Active",
                }
            };
                await diamondContext.AddRangeAsync(diamonds);
                await diamondContext.SaveChangesAsync();
            }
        }
    }
}
