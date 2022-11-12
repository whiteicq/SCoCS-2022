using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Web_053504_Belko.Components
{
    public class Cart: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
