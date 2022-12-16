using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_053504_Belko.Entities;
using Web_053504_Belko.Models;
using Web_053504_Belko.Extensions;
using Web_053504_Belko.Data;
using Microsoft.Extensions.Logging;

namespace Web_053504_Belko.Controllers
{
    public class ProductController : Controller
    {
        private ILogger _logger;
        private ApplicationDbContext _context;
        private List<Dish> dishes;
        private List<DishGroup> dishGroups;
        private int _pageSize;
        public ProductController(ApplicationDbContext context,
                                ILogger<ProductController> logger)
        {
            _context = context;
            _pageSize = 3;
            _logger = logger;
            dishGroups = new List<DishGroup>
            {
                new DishGroup("Супы"),
                new DishGroup("Салаты"),
                new DishGroup("Десерты"),
                new DishGroup("Мясо"),
                new DishGroup("Гарниры")
            };

            dishes = new List<Dish>
            {
                new Dish(title: "Борщ", description: "Суп из свеклы со сметаной", calories: 63, image: "Борщ.jpg", groupId: 1),
                new Dish(title: "Салат Цезарь", description: "Популярный салат", calories: 44, image: "Цезарь.jpg", groupId: 2),
                new Dish(title: "Захер", description: "Шоколадный торт, изобретение австрийского кондитера Франца Захера", calories: 351.6f, image: "Захер.jpg", groupId: 3),
                new Dish(title: "Куриные отбивные", description: "Отбивные из куриного мяса", calories: 220, image: "Отбивные.jpg", groupId: 4),
                new Dish(title: "Картофель-фри", description: "Жаренный картофель во фритюре", calories: 321, image: "Фри.jpg", groupId: 5)
            };
        }


        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo = 1)
        {
            _logger.LogInformation($"info: group={group}, page={pageNo}");

            var dishesFiltered = _context.Dishes
                                .Where(d => !group.HasValue || d.Id == group.Value);
            ViewData["Groups"] = _context.DishGroups;
            ViewData["CurrentGroup"] = group ?? 0;

            var model = ListViewModel<Dish>.GetModel(dishesFiltered, pageNo, _pageSize);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_listpartial", model);
            }
            else
            { 
                return View(model);
            } 
        }
           /* return View(ListViewModel<Dish>.GetModel(dishesFiltered, pageNo, _pageSize));*/
    }
}
