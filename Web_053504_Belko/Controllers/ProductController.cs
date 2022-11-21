using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_053504_Belko.Entities;
using Web_053504_Belko.Models;

namespace Web_053504_Belko.Controllers
{
    public class ProductController : Controller
    {
        private List<Dish> dishes;
        private List<DishGroup> dishGroups;
        private int _pageSize;
        public ProductController()
        {
            _pageSize = 3;
            dishGroups = new List<DishGroup>
            {
                new DishGroup(id: 1, "Супы"),
                new DishGroup(id: 2, "Салаты"),
                new DishGroup(id: 3, "Десерты"),
                new DishGroup(id: 4, "Мясо"),
                new DishGroup(id: 5, "Гарниры")
            };

            dishes = new List<Dish>
            {
                new Dish(id: 1, title: "Борщ", description: "Суп из свеклы со сметаной", calories: 63, image: "Борщ.jpg", groupId: 1),
                new Dish(id: 2, title: "Салат Цезарь", description: "Популярный салат", calories: 44, image: "Цезарь.jpg", groupId: 2),
                new Dish(id: 3, title: "Захер", description: "Шоколадный торт, изобретение австрийского кондитера Франца Захера", calories: 351.6f, image: "Захер.jpg", groupId: 3),
                new Dish(id: 4, title: "Куриные отбивные", description: "Отбивные из куриного мяса", calories: 220, image: "Отбивные.jpg", groupId: 4),
                new Dish(id: 5, title: "Картофель-фри", description: "Жаренный картофель во фритюре", calories: 321, image: "Фри.jpg", groupId: 5)
            };
        }



        public IActionResult Index(int? group, int pageNo = 1)
        {
            var dishesFiltered = dishes
                                .Where(d => !group.HasValue || d.Id == group.Value);
            ViewData["Groups"] = dishGroups;
            ViewData["CurrentGroup"] = group ?? 0;
            return View(ListViewModel<Dish>.GetModel(dishesFiltered, pageNo, _pageSize));
        }
    }
}
