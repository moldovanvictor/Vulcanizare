using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Vulcanizare.WEB.Data;
using Vulcanizare.WEB.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Vulcanizare.WEB.Pages.UserPages
{
    public class AppointmentModel : PageModel
    {
        private readonly Vulcanizare.WEB.Data.VulcanizareWEBContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AppointmentModel(Vulcanizare.WEB.Data.VulcanizareWEBContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IEnumerable<SelectListItem> TireItems => _context.Tire
           .Select(t => new SelectListItem($"{t.Brand} {t.Model} {t.Width}/{t.Diameter} {t.Profile}", t.Id.ToString()))
           .ToList();

        public IActionResult OnGet()
        {
            ViewData["TireId"] = new SelectList(_context.Tire, "Id", "Brand" + " " + "Model" + " " + "Width" + " " + "Diameter" + " " + "Profile");

            return Page();
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Appointment.Status = "Awaiting Confirmation";
            if (!ModelState.IsValid || _context.Appointment == null || Appointment == null)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                foreach (var error in errors)
                {
                    Console.WriteLine($"Model error: {error}");
                }
                return Page();
            }

            var identityUser = await _userManager.GetUserAsync(User);
            if (identityUser == null)
            {
                Console.WriteLine("Unable to get the authenticated user.");
                return Page();
            }
            var userEmail = identityUser.Email;
            Console.WriteLine($"Authenticated user email: {userEmail}");
            var user = _context.User.FirstOrDefault(u => u.Email.ToLower() == userEmail.ToLower());
            if (user == null)
            {
                return Page();
            }
            else
            {
                Appointment.UserId = user.Id;
                
                _context.Appointment.Add(Appointment);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
