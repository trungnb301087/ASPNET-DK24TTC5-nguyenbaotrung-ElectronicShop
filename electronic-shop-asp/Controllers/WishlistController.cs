using electronic_shop_asp.Data;
using electronic_shop_asp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace electronic_shop_asp.Controllers
{
    public class WishlistController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WishlistController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var userIdStr = HttpContext.Session.GetString("UserId");

            if (string.IsNullOrEmpty(userIdStr))
                return RedirectToAction("Login", "Account");

            int userId = int.Parse(userIdStr);

            var wishlist = await _context.Wishlists
                .Include(w => w.WishlistItems)
                .ThenInclude(i => i.Product)
                .ThenInclude(p => p.Category)
                .FirstOrDefaultAsync(w => w.UserId == userId);

            return View(wishlist);
        }

        public async Task<IActionResult> Toggle(int productId)
        {
            var userIdStr = HttpContext.Session.GetString("UserId");

            if (userIdStr == null)
                return RedirectToAction("Login", "Account");

            int userId = int.Parse(userIdStr);

            var wishlist = await _context.Wishlists
                .Include(w => w.WishlistItems)
                .FirstOrDefaultAsync(w => w.UserId == userId);

            if (wishlist == null)
            {
                wishlist = new Wishlist
                {
                    UserId = userId
                };

                _context.Wishlists.Add(wishlist);
                await _context.SaveChangesAsync();
            }

            var item = wishlist.WishlistItems
                .FirstOrDefault(x => x.ProductId == productId);

            if (item == null)
            {
                wishlist.WishlistItems.Add(new WishlistItem
                {
                    ProductId = productId
                });
            }
            else
            {
                _context.WishlistItems.Remove(item);
            }

            await _context.SaveChangesAsync();

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}