using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vulcanizare.WEB.Models;

namespace Vulcanizare.WEB.Pages.UserPages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Appointment Appointment { get; set; }
        public void OnGet()
        {
        }
    }
}
