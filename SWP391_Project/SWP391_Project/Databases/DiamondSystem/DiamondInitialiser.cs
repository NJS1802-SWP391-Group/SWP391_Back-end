using Microsoft.EntityFrameworkCore;
using SWP391_Project.Databases.DiamondSystem.Models;
using SWP391_Project.Databases.System;

namespace SWP391_Project.Databases.DiamondSystem
{
    public class DatabaseDiamondInitialiser : IDatabaseInitialiser
    {
        public readonly DiamondContext _context;

        public DatabaseDiamondInitialiser(DiamondContext context)
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
                    CutGrade = "Excellent",
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
                    CutGrade = "Very Good",
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

                    CutGrade = "Good",

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

                    CutGrade = "Fair",

                    Status = "Active",
                }
            };
            await _context.diamonds.AddRangeAsync(diamonds);
            _context.SaveChanges();
        }
    }
}
