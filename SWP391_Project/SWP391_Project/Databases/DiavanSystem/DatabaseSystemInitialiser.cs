using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SWP391_Project.Databases.DiamondSystem.Models;
using SWP391_Project.Databases.DiavanSystem.Models;
using SWP391_Project.Databases.System.Models;
using SWP391_Project.Helpers;

namespace SWP391_Project.Databases.System
{


    public class DatabaseSystemInitialiser : IDatabaseInitialiser
    {
        public readonly AppDbContext _context;

        public DatabaseSystemInitialiser(AppDbContext context)
        {
            _context = context;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                // Migrate the database schema to the latest version
                await _context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                // Seed the database with initial data
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task TrySeedAsync()
        {
            List<Account> accounts = new()
            { 
                new Account
                {
                    UserName ="rootCT",
                    Password ="12345",
                    RoleName ="Customer",
                    Status=true
                },
                new Account
                {
                    UserName="rootAD",
                    Password="12345",
                    RoleName ="Admin",
                    Status=true
                },
                new Account
                {
                    UserName ="rootVA",
                    Password ="12345",
                    RoleName ="ValuationStaff",
                    Status=true
                },
                new Account
                {
                    UserName ="rootCS",
                    Password ="12345",
                    RoleName="ConsultingStaff",
                    Status=true
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
                    Dob  = new DateOnly(2003, 6, 1),
                    AccountId = 1
                    
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
                    Dob  = new DateOnly(2003, 1, 1),
                    AccountId = 2
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
                    Dob  = new DateOnly(2003, 1, 1),
                    AccountId = 3
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
                    Dob  = new DateOnly(2003, 1, 1),
                    AccountId = 3
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
                    Dob  = new DateOnly(2003, 1, 1),
                    AccountId = 4
                },
            };

            List<Service> services = new()
            {
                new Service
                {
                    Name = "Standard Valuation",
                    Description = "- The time it takes to send for valuation depends on the time of sending./n" +
                                  "- Service price list according to regulations.",
                    Price = 15,
                    Status = "Active"
                },
                new Service
                {
                    Name = "Quick Valuation 48h",
                    Description = "- Inspection time is 48 working hours from the time the product is received./n" +
                                  "- Service price list according to regulations.",
                    Price = 20,
                    Status = "Active"
                },
                new Service
                {
                    Name = "Quick Valuation 24h",
                    Description = "- Inspection time is 24 working hours from the time the product is received./n" +
                                  "- Service price list according to regulations.",
                    Price = 25,
                    Status = "Active"
                },
                new Service
                {
                    Name = "Quick Valuation 4h",
                    Description = "- Inspection time is 4 working hours from the time the product is received./n" +
                                  "- Service price list according to regulations.",
                    Price = 40,
                    Status = "Active"
                },
            };

          

            List<Blog> blogs = new()
            {
                new Blog
                {
                    BlogName = "This is a blog",
                    Content = "Hello world",
                    AdminId = 1
                }
            };

            await _context.Customers.AddRangeAsync(users);
            
            await _context.Services.AddRangeAsync(services);
           
            await _context.Blogs.AddRangeAsync(blogs);

            // Save to DB
            await _context.SaveChangesAsync();
        }
    }

    public static class DatabaseInitialiserExtension
    {
        public static async Task InitialiseDatabaseAsync(this WebApplication app)
        {
            // Create IServiceScope to resolve service scope
            using var scope = app.Services.CreateScope();
            var initializer = scope.ServiceProvider.GetRequiredService<DatabaseSystemInitialiser>();

            await initializer.InitialiseAsync();

            // Try to seeding data
            await initializer.SeedAsync();
        }
    }
}
