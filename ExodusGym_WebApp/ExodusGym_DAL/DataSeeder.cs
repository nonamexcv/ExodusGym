﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ExodusGym_DAL.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExodusGym_DAL
{
    public class DataSeeder
    {
        public static async Task InitializeData(IServiceProvider _serviceProvider,AppDbContext _context)
        {
            Console.WriteLine("Seeding data");
            _context.Database.Migrate();

            var _roleManager = _serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            if (!_context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(_context);
                var role = new IdentityRole { Name = "Admin" };
                await _roleManager.CreateAsync(role);
            }
            if (!_context.Roles.Any(r => r.Name == "Instructor"))
            {
                var store = new RoleStore<IdentityRole>(_context);
                var role = new IdentityRole { Name = "Instructor" };
                await _roleManager.CreateAsync(role);
            }
            if (!_context.Roles.Any(r => r.Name == "Client"))
            {
                var store = new RoleStore<IdentityRole>(_context);
                var role = new IdentityRole { Name = "Client" };
                await _roleManager.CreateAsync(role);
            }

            var userStore = new UserStore<AppUser>(_context);
            var userManager = _serviceProvider.GetRequiredService<UserManager<AppUser>>();

            if (!_context.Users.Any(x => x.UserName == "admin"))
            {
                var Admin = new AppUser()
                {
                    UserName = "admin",
                    PasswordHash = AppUser.HashPassword("Admin123!"),
                    DateOfBirth = new DateTime(1996, 3, 5),
                    FirstName = "Nenad",
                    Lastname = "Radulovic",
                    ImageUrl = "",
                    Email = "admin@gmail.com"
                };
                await userManager.CreateAsync(Admin);
                await userManager.AddToRoleAsync(Admin, "Admin");
            }
            _context.SaveChanges();
            Console.WriteLine("Seeding completed");
        }
    }
}
