using ecommerce_task.Models;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_task.Services
{
    public interface ILookupService
    {
        public Task<ActionResult<IEnumerable<Category>>> GetCategories();
        public Task<ActionResult<IEnumerable<Subcategory>>> GetSubcategories(int categoryId);
        public Task<IEnumerable<Product>> GetProductsBySubCategory(int subcategoryId, string sortBy, PaginationParameters @params);
        public Task<IEnumerable<Product>> GetProductsByCategory(int categoryId, PaginationParameters @params);
    }
}
