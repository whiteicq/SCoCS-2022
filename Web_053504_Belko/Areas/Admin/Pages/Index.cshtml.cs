using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web_053504_Belko.Data;
using Web_053504_Belko.Entities;

namespace Web_053504_Belko.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Web_053504_Belko.Data.ApplicationDbContext _context;

        public IndexModel(Web_053504_Belko.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Dish> Dish { get;set; }

        public async Task OnGetAsync()
        {
            Dish = await _context.Dishes.ToListAsync();
        }
    }
}
