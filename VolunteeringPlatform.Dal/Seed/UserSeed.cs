using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringPlatform.Domain.Auth;

namespace VolunteeringPlatform.Dal.Seed
{
    public class UserSeed
    {
        public static async Task Seed(UserManager<User> userManager, RoleManager<Role> roleManager)
        {

            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new Role() { Name = "admin" });
            }

            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new Role() { Name = "user" });
            }

            if (await roleManager.FindByNameAsync("volunteer") == null)
            {
                await roleManager.CreateAsync(new Role() { Name = "volunteer" });
            }

            if (await roleManager.FindByNameAsync("organization") == null)
            {
                await roleManager.CreateAsync(new Role() { Name = "organization" });
            }
            
            if (!userManager.Users.Any())
            {
                var user = new User()
                {
                    UserName = "admin",
                    Email = "admin@volunteeringplatform.com",
                    FullName = "Administrator"
                };

                await userManager.CreateAsync(user, "Admin.11");
                await userManager.AddToRoleAsync(user, "admin");
            }
        }
    }
}
