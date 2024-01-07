using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vulcanizare.WEB.Data;
using Vulcanizare.WEB.Models;

namespace Vulcanizare.WEB.Pages.Appointments
{
    
    public class CreateModel : PageModel
    {
        private readonly Vulcanizare.WEB.Data.VulcanizareWEBContext _context;

        public CreateModel(Vulcanizare.WEB.Data.VulcanizareWEBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["TireId"] = new SelectList(_context.Tire, "Id", "Brand");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Email");
            return Page();
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Appointment == null || Appointment == null)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                foreach (var error in errors)
                {
                    Console.WriteLine($"Model error: {error}");
                }
                return Page();
            }

            _context.Appointment.Add(Appointment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
