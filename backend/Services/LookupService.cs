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

        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(int subcategoryId)
        {
            var products = await _context.Products.Where(p => p.Subcategory.Id == subcategoryId).ToListAsync();
            return products;
        }

        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(int categoryId)
        {
            var products = await _context.Products.Where(p => p.Category.Id == categoryId).ToListAsync();
            return products;
        }
    }
}
