using ecommerce_task.Models;
using hotel_backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_task.Services
{
    public class LookupService : ILookupService
    {
        private readonly ApplicationDbContext _context;
        public LookupService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }

        public async Task<ActionResult<IEnumerable<Subcategory>>> GetSubcategories(int categoryId)
        {
            var subcategories = await _context.Subcategories.Where(sc=>sc.Category.Id == categoryId).ToListAsync();
            return subcategories;
        }

        public async Task<ActionResult<IEnumerable<Product>>> GetProductsBySubCategory(int subcategoryId, string sortBy)
        {
            var products = await _context.Products.Where(p => p.Subcategory.Id == subcategoryId)
                .Include(p=>p.Category)
                .Include(p=>p.Subcategory).ToListAsync();

            if (sortBy.ToUpper() == "L2H")
                products = products.OrderBy(p => p.Price).ToList();

            else if (sortBy.ToUpper() == "H2L")
                products = products.OrderByDescending(p => p.Price).ToList();

            else if (sortBy.ToUpper() == "NAME")
                products = products.OrderBy(p => p.Name).ToList();

            return products;
        }

        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(int categoryId)
        {
            var products = await _context.Products.Where(p => p.Category.Id == categoryId)
                .Include(p => p.Category)
                .Include(p => p.Subcategory).ToListAsync();

            return products;
        }
    }
}
