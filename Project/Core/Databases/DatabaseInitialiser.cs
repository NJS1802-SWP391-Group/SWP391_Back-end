﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Core.Helpers;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Core.Databases
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

            var superAdminRole = new Role { Id="SA", RoleName = "Super Admin" };
            var adminRole = new Role { Id = "AD", RoleName = "Admin" };
            var User = new Role { Id= "US",RoleName = "User" };
            List<Role> userRoles = new()
            {
                superAdminRole,
                adminRole,
            };
            var khanh = new User
            {
                UserName = "KhanhKhongKhoc",
                Password = SecurityUtil.Hash("123456"),
                Status = "Active",
                Name = "Khanh",
                RoleID = "AD",
            };
            var bao = new User
            {
                Name = "Bao",
                UserName = "BaoBongBay",
                Password = SecurityUtil.Hash("123456"),
                Status = "Active",
                RoleID = "AD",
            };
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
