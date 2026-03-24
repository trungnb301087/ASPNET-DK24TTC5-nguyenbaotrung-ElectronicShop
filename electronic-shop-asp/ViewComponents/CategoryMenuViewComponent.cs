using electronic_shop_asp.Data;
using electronic_shop_asp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace electronic_shop_asp.ViewComponents
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public CategoryMenuViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _context.Categories
                .Select(c => new CategoryMenuViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    ProductCount = c.Products != null ? c.Products.Count : 0
                })
                .ToListAsync();

            return View(categories);
        }
    }
}