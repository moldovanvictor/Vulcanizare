﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vulcanizare.WEB.Data;
using Vulcanizare.WEB.Models;

namespace Vulcanizare.WEB.Pages.CartItems
{
    public class DetailsModel : PageModel
    {
        private readonly Vulcanizare.WEB.Data.VulcanizareWEBContext _context;

        public DetailsModel(Vulcanizare.WEB.Data.VulcanizareWEBContext context)
        {
            _context = context;
        }

      public CartItem CartItem { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CartItem == null)
            {
                return NotFound();
            }

            var cartitem = await _context.CartItem
                .Include(c=>c.Cart)
                .Include(t=>t.Tire)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cartitem == null)
            {
                return NotFound();
            }
            else 
            {
                CartItem = cartitem;
            }
            return Page();
        }
    }
}
