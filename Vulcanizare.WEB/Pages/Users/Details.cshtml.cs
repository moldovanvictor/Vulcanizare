﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vulcanizare.WEB.Data;
using Vulcanizare.WEB.Models;

namespace Vulcanizare.WEB.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly Vulcanizare.WEB.Data.VulcanizareWEBContext _context;

        public DetailsModel(Vulcanizare.WEB.Data.VulcanizareWEBContext context)
        {
            _context = context;
        }

      public User User { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User.FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            else 
            {
                User = user;
            }
            return Page();
        }
    }
}
