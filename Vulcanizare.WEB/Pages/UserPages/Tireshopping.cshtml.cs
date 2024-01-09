using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vulcanizare.WEB.Models;
using Vulcanizare.WEB.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Vulcanizare.WEB.Pages.UserPages
{
    public class TireShoppingModel : PageModel
    {
        private readonly VulcanizareWEBContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public TireShoppingModel(VulcanizareWEBContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Tire> Tires { get; set; }

        public async Task OnGetAsync()
        {
            Tires = await _context.Tire.ToListAsync();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(int tireId)
        {
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

            var cart = await _context.Cart
                .Include(c => c.CartItems)
                .Where( c => c.Status == null )
                .FirstOrDefaultAsync(c => c.UserId == user.Id);

            if (cart == null)
            {
                cart = new Cart { UserId = user.Id };
                _context.Cart.Add(cart);
                await _context.SaveChangesAsync();
            }

            var cartItem = new CartItem
            {
                CartId = cart.Id,
                TireId = tireId,
                Quantity = 1
            };

            _context.CartItem.Add(cartItem);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public IActionResult OnPostGoToCart()
        {
            return RedirectToPage("./Cart");
        }

    }
}
