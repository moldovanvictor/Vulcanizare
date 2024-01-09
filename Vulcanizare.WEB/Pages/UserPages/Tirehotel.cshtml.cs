using Microsoft.AspNetCore.Mvc.RazorPages;
using Vulcanizare.WEB.Data;
using Vulcanizare.WEB.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Vulcanizare.WEB.Pages.UserPages
{
    public class TirehotelModel : PageModel
    {
        private readonly Vulcanizare.WEB.Data.VulcanizareWEBContext _context;

        public TirehotelModel(Vulcanizare.WEB.Data.VulcanizareWEBContext context)
        {
            _context = context;
        }

        public List<TireHotel> TireHotelData { get; set; }
        public DateTime AppointmentDate { get; set; }

        public IActionResult OnGet()
        {
            // Retrieve tire hotel data for the current user (adjust the logic based on your application)
            var currentUserEmail = User.Identity.Name; // Assuming user email is stored in Identity

            var user = _context.User.FirstOrDefault(u => u.Email == currentUserEmail);
            if (user != null)
            {
                TireHotelData = _context.TireHotel
                    .Where(tireHotel => tireHotel.UserId == user.Id)
                    .ToList();

                var appointment = _context.Appointment
                    .FirstOrDefault(a => a.UserId == user.Id && a.ServiceType == "TireStorageinaTireHotel");

                if (appointment != null)
                {
                    AppointmentDate = appointment.AppointmentDate;
                }
            }

            return Page();
        }

    }
}
