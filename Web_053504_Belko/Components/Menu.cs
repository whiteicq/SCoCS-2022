using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_053504_Belko.Models;

namespace Web_053504_Belko.Components
{
    public class Menu: ViewComponent
    {
        private List<MenuItem> _menuItems;

        public IViewComponentResult Invoke() 
        {
            _menuItems = new List<MenuItem>
            {
            new MenuItem { Controller = "Home", Action = "Index", Text = "Lab 3" },
            new MenuItem { Controller = "Product", Action = "Index", Text = "Каталог" },
            new MenuItem { isPage = true, Area = "Admin", Page = "/Index", Text = "Администрирование" }
            };
            return View("Menu.cshtml", _menuItems);
        }
    }
}
