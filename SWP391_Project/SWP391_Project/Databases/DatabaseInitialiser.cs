using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SWP391_Project.Databases.Models;
using SWP391_Project.Helpers;

namespace SWP391_Project.Databases
{
    public interface IDatabaseInitialiser
    {
        Task InitialiseAsync();
        Task SeedAsync();
        Task TrySeedAsync();
    }

    public class DatabaseInitialiser : IDatabaseInitialiser
    {
        public readonly AppDbContext _context;

        public DatabaseInitialiser(AppDbContext context)
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
            if (_context.Users.Any() && _context.Roles.Any())
            {
                return;
            }

            var guestRole = new Role { Id = "GU", RoleName = "Guest" };
            var customerRole = new Role { Id = "CU", RoleName = "Customer" };
            var consultingStaffRole = new Role { Id = "CO", RoleName = "Consulting Staff" };
            var valuatingStaffRole = new Role { Id = "VA", RoleName = "Valuting Staff" };
            var managerRole = new Role { Id = "MA", RoleName = "Guest" };
            var adminRole = new Role { Id = "AD", RoleName = "Admin" };
            List<Role> userRoles = new()
            {
                guestRole,customerRole,consultingStaffRole,valuatingStaffRole,managerRole,adminRole
            };
            List<User> users = new()
            {
                new User
                {
                    Email = "KhanhKhongKhoc@gmail.com",
                    FirstName = "Khanh",
                    LastName = "KhongKhoc",
                    Password = SecurityUtil.Hash("123456"),
                    CCCD = "123456879",
                    Address = "Dong Nai",
                    PhoneNumber = "0907080907",
                    Status = "Active",
                    Role = adminRole,
                },
                new User
                {
                    FirstName = "Bao",
                    LastName = "BongBay",
                    Email = "BaoBongBay@gmail.com",
                    Password = SecurityUtil.Hash("123456"),
                    CCCD = "123456879",
                    Address = "TPHCM",
                    PhoneNumber = "0907080907",
                    Status = "Active",
                    Role = managerRole,
                },
                new User
                {
                    FirstName = "Huy",
                    LastName = "Le Quang",
                    Email = "lequanghuy@gmail.com",
                    Password = SecurityUtil.Hash("123456"),
                    CCCD = "123456879",
                    Address = "Dong Nai",
                    PhoneNumber = "0907080907",
                    Status = "Active",
                    Role = guestRole,
                },
                new User
                {
                    FirstName = "Luan",
                    LastName = "Vo Mong",
                    Email = "vomongluan@gmail.com",
                    Password = SecurityUtil.Hash("123456"),
                    CCCD = "123456879",
                    Address = "Dong Nai",
                    PhoneNumber = "0907080907",
                    Status = "Active",
                    Role = consultingStaffRole,
                },
                                new User
                {
                    FirstName = "Tuan",
                    LastName = "Do Ngoc",
                    Email = "dongoctuan@gmail.com",
                    Password = SecurityUtil.Hash("123456"),
                    CCCD = "123456879",
                    Address = "Dong Nai",
                    PhoneNumber = "0907080907",
                    Status = "Active",
                    Role = valuatingStaffRole,
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

            List<RequestValuationForm> requestValuationForms = new()
            {
                new RequestValuationForm
                {
                    FirstName = "Huy",
                    LastName = "Le Quang",
                    Email = "lequanghuy@gmail.com",
                    CCCD = "123456879",
                    Address = "Dong Nai",
                    PhoneNumber = "0907080907",
                    Status = "Active",
                    Quantity = "5",
                },
                new RequestValuationForm
                {
                    FirstName = "vo",
                    LastName = "Mong Luan",
                    Email = "vomongluan@gmail.com",
                    CCCD = "123456879",
                    Address = "Dong Nai",
                    PhoneNumber = "0907080907",
                    Status = "Active",
                    Quantity = "8",
                },
            };

            List<ScheduleForm> scheduleForms = new()
            {
                new ScheduleForm
                {
                    Customer = users[2],
                    ConsultStaff = users[3],
                    RequestValuationForm = requestValuationForms[0],
                    Time = DateTime.Now,
                    Status = "Active"
                },
            };

            List<Diamond> diamonds = new()
            {
                new Diamond
                {
                    Code = "1234567890",
                    Origin = "Natural",
                    Shape = "Brilliant",
                    Carat = "1.50",
                    Color = "D",
                    Clarity = "IF",
                    Fluorescence = "None",
                    Symmetry = "Excellent",
                    Polish = "Excellent",
                    Certificate = "GIA",
                    CertificateDate = "2024-05-13",
                    Measurement = "7.25 - 7.30 x 4.51 mm",
                    CutGrade = "Excellent",
                    CutScore = 95.0,
                    ClarityCharacteristic = "Cloud",
                    Inscription = "GIA1234567890",
                    Comments = "Beautiful diamond with exceptional clarity and brilliance.",
                    Status = "Active",
                },
                new Diamond
                {
                    Code = "0987654321",
                    Origin = "Lab Grown",
                    Shape = "Square",
                    Carat = "2.10",
                    Color = "E",
                    Clarity = "VVS1",
                    Fluorescence = "Faint",
                    Symmetry = "Very Good",
                    Polish = "Very Good",
                    Certificate = "IGI",
                    CertificateDate = "2024-05-12",
                    Measurement = "6.50 x 6.50 x 4.20 mm",
                    CutGrade = "Very Good",
                    CutScore = 88.0,
                    ClarityCharacteristic = "Needle",
                    Inscription = "IGI0987654321",
                    Comments = "Stunning square-shaped diamond with exceptional clarity.",
                    Status = "Active",
                },
                new Diamond
                {
                    Code = "2468135790",
                    Origin = "Natural",
                    Shape = "Rectangular",
                    Carat = "3.25",
                    Color = "F",
                    Clarity = "VS2",
                    Fluorescence = "Medium",
                    Symmetry = "Good",
                    Polish = "Good",
                    Certificate = "AGS",
                    CertificateDate = "2024-05-11",
                    Measurement = "9.00 x 7.00 x 5.00 mm",
                    CutGrade = "Good",
                    CutScore = 80.0,
                    ClarityCharacteristic = "Feather",
                    Inscription = "AGS2468135790",
                    Comments = "Elegant emerald-cut diamond with balanced proportions.",
                    Status = "Active",
                },
                new Diamond
                {
                    Code = "1357924680",
                    Origin = "Lab Grown",
                    Shape = "Oval",
                    Carat = "1.75",
                    Color = "G",
                    Clarity = "SI1",
                    Fluorescence = "Strong",
                    Symmetry = "Fair",
                    Polish = "Fair",
                    Certificate = "HRD",
                    CertificateDate = "2024-05-10",
                    Measurement = "9.50 x 6.50 x 4.50 mm",
                    CutGrade = "Fair",
                    CutScore = 70.0,
                    ClarityCharacteristic = "Crystal",
                    Inscription = "HRD1357924680",
                    Comments = "Unique oval-shaped diamond with noticeable fluorescence.",
                    Status = "Active",
                },

            };

            List<ValuationReceipt> valuationReceipts = new()
            {
                new ValuationReceipt
                {
                    ScheduleForm = scheduleForms[0],
                    Time = DateTime.Now,
                    ConsultStaff = users[3],
                    ReceiptPrice = 15,
                    Signature = "Manager Signature",
                    Status = "Active"
                }
            };

            List<ValuationReceiptDetail> valuationReceiptDetails = new()
            {
                new ValuationReceiptDetail
                {
                    Diamond = diamonds[0],
                    Service = services[0],
                    ValuationReceipt = valuationReceipts[0],
                    Date = DateTime.Now,
                    EstimatePrice = 18000,
                    Signature = "Manager Signature",
                    Status = "Active"
                }
            };

            List<ValuationReceiptDetail_ValuationStaff> diamond_ValuationStaffs = new()
            {
                new ValuationReceiptDetail_ValuationStaff
                {
                    ValuationStaff = users[4],
                    ValuationReceiptDetail = valuationReceiptDetails[0],
                    Deadline = DateTime.Now,
                    Location = "A01",
                    Status = "Active"
                }
            };

            List<ValuationResult> valuationResults = new()
            {
                new ValuationResult
                {
                    ValuationReceiptDetail = valuationReceiptDetails[0],
                    ValuationStaff = users[3],
                    Time = DateTime.Now,
                    Signature = "Manager Signature",
                    Status = "Active"
                }
            };

            List<FinalReceipt> finalReceipts = new()
            {
                new FinalReceipt
                {
                    Manager = users[1],
                    ValuationResult = valuationResults[0],
                    Time = DateTime.Now,
                    Signature = "Manager Signature",
                    Status = "Active"
                }
            };

            List<DiamondPrice> diamondPrices = new()
            {
                new DiamondPrice
                {
                    Diamond = diamonds[0],
                    Price = 20000,
                    Source = "stonealgo.com",
                    UpdateTime = DateTime.Now,
                }
            };

            List<Blog> blogs = new()
            {
                new Blog
                {
                    BlogName = "This is a blog",
                    Content = "Hello world",  
                    User = users[0],
                }
            };

            await _context.Users.AddRangeAsync(users);
            await _context.Roles.AddRangeAsync(userRoles);
            await _context.RequestValuationForms.AddRangeAsync(requestValuationForms);
            await _context.ScheduleForms.AddRangeAsync(scheduleForms);
            await _context.Services.AddRangeAsync(services);
            await _context.Diamonds.AddRangeAsync(diamonds);
            await _context.DiamondPrices.AddRangeAsync(diamondPrices);
            await _context.ValuationReceiptDetail_ValuationStaff.AddRangeAsync(diamond_ValuationStaffs);
            await _context.ValuationReceipts.AddRangeAsync(valuationReceipts);
            await _context.ValuationReceiptDetails.AddRangeAsync(valuationReceiptDetails);
            await _context.ValuationResult.AddRangeAsync(valuationResults);
            await _context.FinalReceipts.AddRangeAsync(finalReceipts);
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
            var initializer = scope.ServiceProvider.GetRequiredService<DatabaseInitialiser>();

            await initializer.InitialiseAsync();

            // Try to seeding data
            await initializer.SeedAsync();
        }
    }
}
