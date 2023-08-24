using Castle.Core.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC_ONION_PROJECT.DOMAIN.ENTITIES;
using MVC_ONION_PROJECT.DOMAIN.ENUMS;
using MVC_ONION_PROJECT.INFRASTRUCTURE.APPCONTEXT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace MVC_ONION_PROJECT.INFRASTRUCTURE.Seeds
{
    public static class AdminSeed
    {
        private const string adminEmail = "admin@bilgeadam.com";
        private const string adminPassword = "Password.1";

        public static async Task SeedAsync(IConfiguration configuration)
        {
            var dbContextBuilder = new DbContextOptionsBuilder<AppDbContext>();
            dbContextBuilder.UseSqlServer(configuration.GetConnectionString("AppConnection"));

            AppDbContext context = new AppDbContext(dbContextBuilder.Options);
            if (!context.Roles.Any())
            {
                await AddRoles(context);

            }
            if (!context.Users.Any(user => user.Email == adminEmail))
            {
                await AddAdmin(context);
            }
            await Task.CompletedTask;

        }

        private static async Task AddAdmin(AppDbContext context)
        {
            IdentityUser user = new IdentityUser()
            {
                UserName = adminEmail,
                NormalizedUserName = adminEmail.ToUpper(),
                Email = adminEmail,
                NormalizedEmail = adminEmail.ToUpper(),
                EmailConfirmed = true
            };

            user.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(user,adminPassword);
            await context.Users.AddAsync(user);
            var adminRoleId = context.Roles.FirstOrDefault(role => role.Name == Roles.Admin.ToString())!.Id;
            await context.UserRoles.AddAsync(new IdentityUserRole<string> 
            { 
                RoleId = adminRoleId, 
                UserId = user.Id 
            });
            await context.Admins.AddAsync(new Admin()
            {
                Status = Status.Created,
                CreatedBy = "SuperAdmin",
                CreatedDate = DateTime.Now,
                FirstName = "Admin",
                LastName = "Admin",
                Email = adminEmail,
                Gender = true,
                DateOfBirth = new DateTime(1990, 1, 1),
                IdentityId = user.Id
            });
            await context.SaveChangesAsync();

        }


        private static async Task AddRoles(AppDbContext context)
        {
            string[] roles = Enum.GetNames(typeof(Roles));

            for (int i = 0; i < roles.Length; i++)
            {
                if (await context.Roles.AnyAsync(role => role.Name == roles[i]))
                {
                    continue;
                }

                await context.Roles.AddAsync(new IdentityRole(roles[i]));
                await context.SaveChangesAsync();

            }

        }
    }
}
