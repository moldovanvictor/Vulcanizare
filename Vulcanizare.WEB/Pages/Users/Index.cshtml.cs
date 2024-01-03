using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vulcanizare.WEB.Data;
using Vulcanizare.WEB.Models;

namespace Vulcanizare.WEB.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly Vulcanizare.WEB.Data.VulcanizareWEBContext _context;

        public IndexModel(Vulcanizare.WEB.Data.VulcanizareWEBContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.User != null)
            {
                User = await _context.User.ToListAsync();
            }
        }
    }
}
