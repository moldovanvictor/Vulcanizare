using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vulcanizare.WEB.Models;
using Vulcanizare.WEB.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Vulcanizare.WEB.Pages.UserPages
{
    public class CartModel : PageModel
    {
        private readonly VulcanizareWEBContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CartModel(VulcanizareWEBContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public Cart Cart { get; set; }

        public Cart CurrentCart { get; set; }
        public Cart CarttoUpdate { get; set; }
        public List<Cart> PreviousCarts { get; set; }
        public Dictionary<Tire, int> GroupedCartItems { get; set; }

        public async Task OnGetAsync()
        {
            var identityUser = await _userManager.GetUserAsync(User);
            var userEmail = identityUser.Email;
            var user = _context.User.FirstOrDefault(u => u.Email.ToLower() == userEmail.ToLower());

            CurrentCart = await _context.Cart
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Tire)
                .FirstOrDefaultAsync(c => c.UserId == user.Id && c.Status == null);

            if (CurrentCart != null)
            {
                GroupedCartItems = CurrentCart.CartItems
                    .GroupBy(ci => ci.Tire)
                    .ToDictionary(g => g.Key, g => g.Sum(ci => ci.Quantity));
            }



            PreviousCarts = await _context.Cart
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Tire)
                .Where(c => c.UserId == user.Id && c.Status != null)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostCheckoutAsync()
        {
            var identityUser = await _userManager.GetUserAsync(User);
            var userEmail = identityUser.Email;
            var user = _context.User.FirstOrDefault(u => u.Email.ToLower() == userEmail.ToLower());

            CurrentCart = await _context.Cart
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Tire)
                .FirstOrDefaultAsync(c => c.UserId == user.Id && c.Status == null);

            if (CurrentCart != null)
            {
                // Update the cart status
                CurrentCart.Status = "Awaiting Confirmation";
                _context.Cart.Update(CurrentCart);
                await _context.SaveChangesAsync();

                // Display a confirmation message
                TempData["Message"] = "Comanda dvs. este în așteptarea confirmării.";
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostIncreaseQuantityAsync(int id)
        {
            var tire = await _context.Tire.FindAsync(id);
            if (tire == null)
            {
                // Handle the error - the tireId does not exist in the Tire table
                return NotFound($"No tire found with ID {id}");
            }
            var identityUser = await _userManager.GetUserAsync(User);
            var userEmail = identityUser.Email;
            var user = _context.User.FirstOrDefault(u => u.Email.ToLower() == userEmail.ToLower());

            CarttoUpdate = await _context.Cart.FirstOrDefaultAsync(c => c.UserId == user.Id && c.Status == null);

            var cartItem = new CartItem
            {
                CartId = CarttoUpdate.Id,
                TireId = id,
                Quantity = 1
            };


            _context.CartItem.Add(cartItem);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDecreaseQuantityAsync(int id)
        {
            var tire = await _context.Tire.FindAsync(id);
            if (tire == null)
            {
                // Handle the error - the tireId does not exist in the Tire table
                return NotFound($"No tire found with ID {id}");
            }
            var identityUser = await _userManager.GetUserAsync(User);
            var userEmail = identityUser.Email;
            var user = _context.User.FirstOrDefault(u => u.Email.ToLower() == userEmail.ToLower());

            CarttoUpdate = await _context.Cart.FirstOrDefaultAsync(c => c.UserId == user.Id && c.Status == null);

            var cartItem = await _context.CartItem.FirstOrDefaultAsync(c => c.CartId == CarttoUpdate.Id && c.TireId == id);

            if (cartItem != null)
            {
                _context.CartItem.Remove(cartItem);
                await _context.SaveChangesAsync();
            }


            return RedirectToPage();
        }



    }
}