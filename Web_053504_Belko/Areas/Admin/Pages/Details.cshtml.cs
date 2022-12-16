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
    public class DetailsModel : PageModel
    {
        private readonly Web_053504_Belko.Data.ApplicationDbContext _context;

        public DetailsModel(Web_053504_Belko.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Dish Dish { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dish = await _context.Dishes.FirstOrDefaultAsync(m => m.Id == id);

            if (Dish == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
