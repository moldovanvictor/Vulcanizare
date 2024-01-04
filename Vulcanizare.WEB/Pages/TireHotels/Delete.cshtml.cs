using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vulcanizare.WEB.Data;
using Vulcanizare.WEB.Models;

namespace Vulcanizare.WEB.Pages.TireHotels
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly Vulcanizare.WEB.Data.VulcanizareWEBContext _context;

        public DeleteModel(Vulcanizare.WEB.Data.VulcanizareWEBContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TireHotel == null)
            {
                return NotFound();
            }
            var tirehotel = await _context.TireHotel.FindAsync(id);

            if (tirehotel != null)
            {
                TireHotel = tirehotel;
                _context.TireHotel.Remove(TireHotel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
