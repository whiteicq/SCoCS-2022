using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_053504_Belko.Extensions;

namespace Web_053504_Belko.Components
{
    public class Cart: ViewComponent
    {
        private Cart _cart;
        public Cart(Cart cart)
        {
            _cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            var cart = HttpContext.Session.Get<Models.Cart>("cart");
            return View(cart);
        }
    }
}
