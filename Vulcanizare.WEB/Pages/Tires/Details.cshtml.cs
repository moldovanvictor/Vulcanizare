﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vulcanizare.WEB.Data;
using Vulcanizare.WEB.Models;

namespace Vulcanizare.WEB.Pages.Tires
{
    public class DetailsModel : PageModel
    {
        private readonly Vulcanizare.WEB.Data.VulcanizareWEBContext _context;

        public DetailsModel(Vulcanizare.WEB.Data.VulcanizareWEBContext context)
        {
            _context = context;
        }

      public Tire Tire { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tire == null)
            {
                return NotFound();
            }

            var tire = await _context.Tire.FirstOrDefaultAsync(m => m.Id == id);
            if (tire == null)
            {
                return NotFound();
            }
            else 
            {
                Tire = tire;
            }
            return Page();
        }
    }
}
