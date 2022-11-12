using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Web_053504_Belko.Data;

namespace Web_053504_Belko.Entities
{
    public class DbInitializer
    {
        public static async void Initialize(IApplicationBuilder app)
        {
            IServiceProvider provider = app.ApplicationServices.CreateScope().ServiceProvider;
            ApplicationDbContext dbContext = provider.GetService<ApplicationDbContext>();
            UserManager<ApplicationUser> userManager = provider.GetService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole> roleManager = provider.GetService<RoleManager<IdentityRole>>();

            async Task<IdentityResult> CreateUser(string email, string userName, string password, Task<IdentityResult> role = null)
            {
                return await userManager.CreateAsync(new ApplicationUser
                {
                    Email = email,
                    UserName = userName,
                }, password);
            }

            IdentityResult result = await userManager.CreateAsync(new ApplicationUser { Email = "test1@mail.ru", UserName = "Test1" }, "123456");
            Console.WriteLine($"Result: {result.Succeeded}");
            await roleManager.CreateAsync(new IdentityRole("admin"));

            result = await userManager.CreateAsync(new ApplicationUser { Email = "admin@mail.ru", UserName = "admin" }, "123456");

                await userManager.AddToRoleAsync(
                        userManager.Users.First(user => user.UserName == "admin"),
                        "admin");
                

            dbContext.SaveChanges();
        }
    }
}
