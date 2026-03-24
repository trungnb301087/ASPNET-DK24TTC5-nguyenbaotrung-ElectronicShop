using electronic_shop_asp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace electronic_shop_asp.ViewComponents
{
    public class WishlistCountViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public WishlistCountViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int count = 0;

            var userIdString = HttpContext.Session.GetString("UserId");

            if (!string.IsNullOrEmpty(userIdString))
            {
                int userId = int.Parse(userIdString);

                var wishlist = await _context.Wishlists
                    .Include(w => w.WishlistItems)
                    .FirstOrDefaultAsync(w => w.UserId == userId);

                if (wishlist != null)
                {
                    count = wishlist.WishlistItems.Count;
                }
            }

            return View("Default", count);
        }
    }
}