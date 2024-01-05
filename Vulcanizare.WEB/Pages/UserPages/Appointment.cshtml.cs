using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Vulcanizare.WEB.Data;
using Vulcanizare.WEB.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;

namespace Vulcanizare.WEB.Pages.UserPages
{
    public class AppointmentModel : PageModel
    {
        private readonly Vulcanizare.WEB.Data.VulcanizareWEBContext _context;
        private readonly UserManager<User> _userManager;

        public AppointmentModel(Vulcanizare.WEB.Data.VulcanizareWEBContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            ViewData["TireId"] = new SelectList(_context.Tire, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Appointment == null || Appointment == null)
            {
                return Page();
            }

            // Get the currently logged-in user's ID
            var user = await _userManager.GetUserAsync(User);
            Appointment.UserId = user.Id;

            _context.Appointment.Add(Appointment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
