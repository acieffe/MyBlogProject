using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyBlogProject.Data;
using MyBlogProject.Enums;
using MyBlogProject.Models;

namespace MyBlogProject.Services
{
    public class DataService
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<BlogUser> _userManager;


        public DataService(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<BlogUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task ManageDataAsync()
        {
            await _dbContext.Database.MigrateAsync();

            // Seed Roles
            await SeedRolesAsync();

            // Seed Users
            await SeedUsersAsync();

        }

        private async Task SeedRolesAsync()
        {
            // do nothing if roles are populated
            if (_dbContext.Roles.Any()) return;

            // Otherwise create roles
            foreach(var role in Enum.GetNames(typeof(BlogRole)))
            {
                // Use role manager to create roles
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        private async Task SeedUsersAsync()
        {
            // do nothing if users are populated
            if (_dbContext.Users.Any()) return;

            // Step 1: Create new instance of bloguser
            var adminUser = new BlogUser()
            {
                Email = "acieffe@gmail.com",
                UserName = "acieffe@gmail.com",
                FirstName = "Ace",
                LastName = "Baugh",
                PhoneNumber = "(208) 557-9223",
                EmailConfirmed = true
            };

            // Step 2: Use the UserManager to create new user defined by adminUser
            await _userManager.CreateAsync(adminUser, "Abc$123!");

            // Step 3; Add user to Admin Role
            await _userManager.AddToRoleAsync(adminUser, BlogRole.Administrator.ToString());

            // Step 1: Create new instance of bloguser that's a moderator
            var modUser = new BlogUser()
            {
                Email = "acieffe@yahoo.com",
                UserName = "acieffe@yahoo.com",
                FirstName = "Tom",
                LastName = "Davenport",
                PhoneNumber = "(208) 346-2352",
                EmailConfirmed = true
            };

            // Step 2: Use the UserManager to create new user defined by modUser
            await _userManager.CreateAsync(modUser, "Def$123!");

            // Step 3; Add user to Moderator Role
            await _userManager.AddToRoleAsync(modUser, BlogRole.Moderator.ToString());

        }

    }

}
