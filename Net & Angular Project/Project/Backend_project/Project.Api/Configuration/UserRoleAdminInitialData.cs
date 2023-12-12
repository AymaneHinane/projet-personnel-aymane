using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Project.Entities.Models;
using Project.Repository;

namespace Project.Api.Configuration
{
	public class UserRoleAdminInitialData
	{
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<RepositoryContext>();

            string[] roles = new string[] { "ADMIN"};

            foreach (string role in roles)
            {
                var roleStore = new RoleStore<IdentityRole>(context);

                if (!context.Roles.Any(r => r.Name == role))
                {
                    roleStore.CreateAsync(new IdentityRole(role));
                }
            }


            var user = new User
            {
                FirstName = "XXX",
                LastName = "XXXX",
                Email = "xxxx@example.com",
                NormalizedEmail = "XXXX@EXAMPLE.COM",
                UserName = "admin",
                NormalizedUserName = "OWNER",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };


            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<User>();
                var hashed = password.HashPassword(user, "admin123");
                user.PasswordHash = hashed;

                var userStore = new UserStore<User>(context);
                var result = userStore.CreateAsync(user);

            }

            AssignRoles(serviceProvider, user.Email, roles);

            context.SaveChangesAsync();
        }

        public static async Task<IdentityResult> AssignRoles(IServiceProvider services, string email, string[] roles)
        {
            UserManager<User> _userManager = services.GetService<UserManager<User>>();
            User user = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.AddToRolesAsync(user, roles);

            return result;
        }

    }
}

