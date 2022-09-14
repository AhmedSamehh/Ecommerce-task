using ecommerce_task.Models;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_task.Services
{
    public interface ILookupService
    {
        public Task<ActionResult<IEnumerable<Category>>> GetCategories();
        public Task<ActionResult<IEnumerable<Subcategory>>> GetSubcategories(int categoryId);
        public Task<ActionResult<IEnumerable<Product>>> GetProductsBySubCategory(int subcategoryId, string sortBy);
        public Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(int categoryId, string sortBy);
    }
}
