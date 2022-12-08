using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Web_053504_Belko.Data;
using Web_053504_Belko.Entities;

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

            if (!dbContext.DishGroups.Any())
            {
                dbContext.DishGroups.AddRange(
                new List<DishGroup>
                {
                new DishGroup("Супы"),
                new DishGroup("Салаты"),
                new DishGroup("Десерты"),
                new DishGroup("Мясо"),
                new DishGroup("Гарниры")
                });
                await dbContext.SaveChangesAsync();
            }
            // проверка наличия объектов
            if (!dbContext.Dishes.Any())
            {
                dbContext.Dishes.AddRange(
                new List<Dish>
                {
                new Dish(title: "Борщ", description: "Суп из свеклы со сметаной", calories: 63, image: "Борщ.jpg", groupId: 1),
                new Dish(title: "Салат Цезарь", description: "Популярный салат", calories: 44, image: "Цезарь.jpg", groupId: 2),
                new Dish(title: "Захер", description: "Шоколадный торт, изобретение австрийского кондитера Франца Захера", calories: 351.6f, image: "Захер.jpg", groupId: 3),
                new Dish(title: "Куриные отбивные", description: "Отбивные из куриного мяса", calories: 220, image: "Отбивные.jpg", groupId: 4),
                new Dish(title: "Картофель-фри", description: "Жаренный картофель во фритюре", calories: 321, image: "Фри.jpg", groupId: 5)
                     });
                await dbContext.SaveChangesAsync();
            }

        }
    }
}
