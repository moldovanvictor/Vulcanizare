using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vulcanizare.WEB.Data;
using Vulcanizare.WEB.Models;

namespace Vulcanizare.WEB.Pages.TireHotels
{
    public class DetailsModel : PageModel
    {
        private readonly Vulcanizare.WEB.Data.VulcanizareWEBContext _context;

        public DetailsModel(Vulcanizare.WEB.Data.VulcanizareWEBContext context)
        {
            _context = context;
        }

      public TireHotel TireHotel { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TireHotel == null)
            {
                return NotFound();
            }

            var tirehotel = await _context.TireHotel.FirstOrDefaultAsync(m => m.Id == id);
            if (tirehotel == null)
            {
                return NotFound();
            }
            else 
            {
                TireHotel = tirehotel;
            }
            return Page();
        }
    }
}
