using SWP391_Project.Helpers;
using SWP391_Project.Data.Databases.DiavanSystem;
using SWP391_Project.Data.Databases.DiamondSystem;
using Microsoft.EntityFrameworkCore;
using SWP391_Project.Domain.DiavanEntities;
using Domain.DiamondEntities;
using Microsoft.Extensions.DependencyInjection;
using Data.Helpers;
using Domain.DiavanEntities;

namespace SWP391_Project.Data.Databases
{
    public interface IDatabaseInitialiser
    {
        Task InitialiseAsync();
        Task SeedAsync();
        Task SeedDatabaseAsync(AppDbContext appDbContext, DiamondContext diamondContext);
    }

    public class DatabaseInitialiser : IDatabaseInitialiser
    {
        public readonly AppDbContext _context;
        public readonly DiamondContext _diamondContext;

        public DatabaseInitialiser(AppDbContext context, DiamondContext diamondContext)
        {
            _context = context;
            _diamondContext = diamondContext;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                // Migration Database - Create database if it does not exist
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
                await SeedDatabaseAsync(_context, _diamondContext);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task SeedDatabaseAsync(AppDbContext appDbContext, DiamondContext diamondContext)
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
                    UserName ="baoCT",
                    Password = SecurityUtil.Hash("12345"),
                    RoleName ="Customer",
                    Status = "Active"
                },
                new Account
                {
                    UserName ="huyCT",
                    Password = SecurityUtil.Hash("12345"),
                    RoleName ="Customer",
                    Status = "Active"
                },
                new Account
                {
                    UserName ="luanCT",
                    Password = SecurityUtil.Hash("12345"),
                    RoleName ="Customer",
                    Status = "Active"
                },
                new Account
                {
                    UserName ="tuanCT",
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
                    Account = accounts[1]
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
                    Account = accounts[2]
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
                    Account = accounts[3]
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
                    Account = accounts[4]
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
                    Name = "Quick Valuation 6h",
                    Description = "- Inspection time is 4 working hours from the time the product is received./n" +
                                  "- Service price list according to regulations.",
                    Status = "Active"
                },
            };

                List<ServiceDetail> serviceDetails = new()
            {
                new ServiceDetail
                {
                    Code = "S6R1",
                    MinRange = 0,
                    MaxRange = 3,
                    Price = 50,
                    ExtraPricePerMM = 0,
                    Service = services[3],
                    Status = "Active"
                },
                new ServiceDetail
                {
                    Code = "S6R2",
                    MinRange = 3.1,
                    MaxRange = 5,
                    Price = 55,
                    ExtraPricePerMM = 0,
                    Service = services[3],
                    Status = "Active"
                },
                new ServiceDetail
                {
                    Code = "S6R3",
                    MinRange = 5.1,
                    MaxRange = 8,
                    Price = 60,
                    ExtraPricePerMM = 0,
                    Service = services[3],
                    Status = "Active"
                },
                new ServiceDetail
                {
                    Code = "S6R4",
                    MinRange = 8.1,
                    MaxRange = 0,
                    Price = 65,
                    ExtraPricePerMM = 5,
                    Service = services[3],
                    Status = "Active"
                },
                new ServiceDetail
                {
                    Code = "S24R1",
                    MinRange = 0,
                    MaxRange = 3,
                    Price = 40,
                    ExtraPricePerMM = 0,
                    Service = services[2],
                    Status = "Active"
                },
                new ServiceDetail
                {
                    Code = "S24R2",
                    MinRange = 3.1,
                    MaxRange = 5,
                    Price = 45,
                    ExtraPricePerMM = 0,
                    Service = services[2],
                    Status = "Active"
                },
                new ServiceDetail
                {
                    Code = "S24R3",
                    MinRange = 5.1,
                    MaxRange = 8,
                    Price = 50,
                    ExtraPricePerMM = 0,
                    Service = services[2],
                    Status = "Active"
                },
                new ServiceDetail
                {
                    Code = "S24R4",
                    MinRange = 8.1,
                    MaxRange = 0,
                    Price = 55,
                    ExtraPricePerMM = 5,
                    Service = services[2],
                    Status = "Active"
                },
                new ServiceDetail
                {
                    Code = "S48R1",
                    MinRange = 0,
                    MaxRange = 3,
                    Price = 30,
                    ExtraPricePerMM = 0,
                    Service = services[1],
                    Status = "Active"
                },
                new ServiceDetail
                {
                    Code = "S48R2",
                    MinRange = 3.1,
                    MaxRange = 5,
                    Price = 35,
                    ExtraPricePerMM = 0,
                    Service = services[1],
                    Status = "Active"
                },
                new ServiceDetail
                {
                    Code = "S48R3",
                    MinRange = 5.1,
                    MaxRange = 8,
                    Price = 40,
                    ExtraPricePerMM = 0,
                    Service = services[1],
                    Status = "Active"
                },
                new ServiceDetail
                {
                    Code = "S48R4",
                    MinRange = 8.1,
                    MaxRange = 0,
                    Price = 45,
                    ExtraPricePerMM = 5,
                    Service = services[1],
                    Status = "Active"
                },
                new ServiceDetail
                {
                    Code = "SSR1",
                    MinRange = 0,
                    MaxRange = 3,
                    Price = 20,
                    ExtraPricePerMM = 0,
                    Service = services[0],
                    Status = "Active"
                },
                new ServiceDetail
                {
                    Code = "SSR2",
                    MinRange = 3.1,
                    MaxRange = 5,
                    Price = 25,
                    ExtraPricePerMM = 0,
                    Service = services[0],
                    Status = "Active"
                },
                new ServiceDetail
                {
                    Code = "SSR3",
                    MinRange = 5.1,
                    MaxRange = 8,
                    Price = 30,
                    ExtraPricePerMM = 0,
                    Service = services[0],
                    Status = "Active"
                },
                new ServiceDetail
                {
                    Code = "SSR4",
                    MinRange = 8.1,
                    MaxRange = 0,
                    Price = 35,
                    ExtraPricePerMM = 5,
                    Service = services[0],
                    Status = "Active"
                },
            };


                List<Order> orders = new()
                {
                    new Order
                    {
                        Customer = users[0],
                        Code = GenerateCode.OrderCode(),
                        Time = DateTime.Now,
                        Quantity = 1,
                        TotalPay = 25,
                        Payment = "Cash",
                        StatusPayment = "Paid",
                        Status = "Active"
                    },
                    new Order
                    {
                        Customer = users[1],
                        Code = GenerateCode.OrderCode(),
                        Time = DateTime.Now,
                        Quantity = 2,
                        TotalPay = 80,
                        Payment = "Cash",
                        StatusPayment = "Paid",
                        Status = "Active"
                    },
                    new Order
                    {
                        Customer = users[2],
                        Code = GenerateCode.OrderCode(),
                        Time = DateTime.Now,
                        Quantity = 1,
                        TotalPay = 30,
                        Payment = "Cash",
                        StatusPayment = "Paid",
                        Status = "Active"
                    },
                };

                List<OrderDetail> orderDetails = new()
                {
                    new OrderDetail
                    {
                        Code = GenerateCode.OrderDetailCode(orders[1].OrderID),
                        EstimateLength = 2.5,
                        Service = services[2],
                        Price = serviceDetails[4].Price,
                        isDiamond = true,
                        Status = "Active",
                        Order = orders[1],
                        ValuationStaff = null,
                        Result = null
                    },
                    new OrderDetail
                    {
                        Code = GenerateCode.OrderDetailCode(orders[1].OrderID),
                        EstimateLength = 1.8,
                        Service= services[2],
                        Price = serviceDetails[4].Price,
                        isDiamond = true,
                        Status = "Active",
                        Order = orders[1],
                        ValuationStaff = null,
                        Result = null
                    },
                    new OrderDetail
                    {
                        Code = GenerateCode.OrderDetailCode(orders[0].OrderID),
                        EstimateLength = 2.5,
                        Service = services[1],
                        Price = serviceDetails[12].Price,
                        isDiamond = false,
                        Status = "Active",
                        Order = orders[0],
                        ValuationStaff = null,
                        Result = null
                    },
                    new OrderDetail
                    {
                        Code = GenerateCode.OrderDetailCode(orders[2].OrderID),
                        EstimateLength = 3.5,
                        Service = services[0],
                        Price = serviceDetails[13].Price,
                        isDiamond = true,
                        Status = "Active",
                        Order = orders[0],
                        ValuationStaff = null,
                        Result = null
                    },
                };

                List<Result> results = new()
                {
                    new Result
                    {
                        IsDiamond = true,
                        Code = "01010101",
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
                        CertificateStatus = "Pending",
                        DiamondValue = 18000,
                        Description = "",
                        IssueDate = DateTime.Now,
                        ExpireDate = DateTime.Now,
                        OrderDetail = orderDetails[3],
                        ValueStatus = "Active"
                    }
                };

                List<SystemDiamond> diamonds = new()
            {
                new SystemDiamond
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
                    Source = "stonealgo.com",
                    UpdateDate = DateTime.Now,
                    Value = 4000
                },
                new SystemDiamond
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
                    Source = "stonealgo.com",
                    UpdateDate = DateTime.Now,
                    Value = 5000
                },
                new SystemDiamond
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
                    Source = "stonealgo.com",
                    UpdateDate = DateTime.Now,
                    Value = 6000
                },
                new SystemDiamond
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
                    Source = "stonealgo.com",
                    UpdateDate = DateTime.Now,
                    Value = 6000
                }
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
                await appDbContext.AddRangeAsync(serviceDetails);
                await appDbContext.AddRangeAsync(users);
                await appDbContext.AddRangeAsync(diamonds);
                await appDbContext.AddRangeAsync(orders);
                await appDbContext.AddRangeAsync(orderDetails);
                await appDbContext.AddRangeAsync(results);

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
                    Source = "stonealgo.com",
                    UpdateDate = DateTime.Now,
                    Value = 4000
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
                    Source = "stonealgo.com",
                    UpdateDate = DateTime.Now,
                    Value = 4000
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
                    Source = "stonealgo.com",
                    UpdateDate = DateTime.Now,
                    Value = 4000
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
                    Source = "stonealgo.com",
                    UpdateDate = DateTime.Now,
                    Value = 4000
                }
            };

                List<DiamondCheck> diamondChecks = new()
                {
                                new DiamondCheck
            {
                CertificateCode = "DC001",
                Origin = "South Africa",
                Shape = "Round",
                Carat = "1.0",
                Color = "D",
                Clarity = "VS1",
                Fluorescence = "None",
                Symmetry = "Excellent",
                Polish = "Excellent",
                CutGrade = "Ideal",
                CutScore = "9.5",
                FairPrice = 10000.00,
                CertDate = new DateTime(2023, 1, 15),
                Measurement = "6.5 x 6.5 x 4.0 mm",
                ClarityCharacteristic = "None",
                Comment = "Excellent diamond",
                Status = "Available"
            },
            new DiamondCheck
            {
                CertificateCode = "DC002",
                Origin = "Russia",
                Shape = "Princess",
                Carat = "1.5",
                Color = "E",
                Clarity = "VVS2",
                Fluorescence = "Faint",
                Symmetry = "Very Good",
                Polish = "Very Good",
                CutGrade = "Premium",
                CutScore = "9.0",
                FairPrice = 15000.00,
                CertDate = new DateTime(2023, 2, 20),
                Measurement = "6.0 x 6.0 x 4.5 mm",
                ClarityCharacteristic = "Feather",
                Comment = "High-quality princess cut",
                Status = "Available"
            },
            new DiamondCheck
            {
                CertificateCode = "DC003",
                Origin = "Canada",
                Shape = "Oval",
                Carat = "2.0",
                Color = "F",
                Clarity = "SI1",
                Fluorescence = "Medium",
                Symmetry = "Good",
                Polish = "Good",
                CutGrade = "Very Good",
                CutScore = "8.5",
                FairPrice = 20000.00,
                CertDate = new DateTime(2023, 3, 10),
                Measurement = "7.0 x 5.0 x 3.5 mm",
                ClarityCharacteristic = "Crystal",
                Comment = "Beautiful oval shape",
                Status = "Sold"
            },
                };

                await diamondContext.AddRangeAsync(diamonds);
                await diamondContext.AddRangeAsync(diamondChecks);
                await diamondContext.SaveChangesAsync();
            }
        }
    }
    public static class DatabaseInitialiserExtension
    {
        public static async Task InitialiseDatabaseAsync(this IServiceProvider modelBuilder)
        {
            // Create IServiceScope to resolve service scope
            using var scope = modelBuilder.CreateScope();
            var initializer = scope.ServiceProvider.GetRequiredService<DatabaseInitialiser>();

            await initializer.InitialiseAsync();

            // Try to seeding data
            await initializer.SeedAsync();
        }


    }
}
