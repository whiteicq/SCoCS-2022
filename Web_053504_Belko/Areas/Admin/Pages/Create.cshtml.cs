﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web_053504_Belko.Data;
using Web_053504_Belko.Entities;

namespace Web_053504_Belko.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Web_053504_Belko.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public CreateModel(Web_053504_Belko.Data.ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
           //ViewData["DishGroupId"] = new SelectList(_context.DishGroups, "DishGroupId", "GroupName");
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Dish Dish { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Dishes.Add(Dish);
            await _context.SaveChangesAsync();
            if (Image != null)
            {
                var fileName = $"{Dish.Id}" +
                Path.GetExtension(Image.FileName);
                Dish.Image = fileName;
                var path = Path.Combine(_environment.WebRootPath, "Images",
                fileName);
                using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(fStream);
                }
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
