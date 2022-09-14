using ecommerce_task.Models;
using ecommerce_task.Services;
using hotel_backend.Data;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_task.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LookupController : ControllerBase
    {
   
        private readonly ILookupService _lookupService;

        public LookupController(ILookupService lookupService)
        {
            _lookupService = lookupService;
        }

       

        [HttpGet("/categories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            try
            {
                return await _lookupService.GetCategories();
            } 
            catch
            {
                return BadRequest("Error: Cannot get Categories");
            }
        }

        [HttpGet("/subcategories/{categoryId}")]
        public async Task<ActionResult<IEnumerable<Subcategory>>> GetSubcategories(int categoryId)
        {
            try
            {
                return await _lookupService.GetSubcategories(categoryId);
            }
            catch
            {
                return BadRequest("Error: Cannot get Subcategories");
            }
        }

        [HttpGet("/products/{subcategoryId}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(int subcategoryId, string? sortBy)
        {
            try
            {
                if (sortBy == null)
                    sortBy = "";
                return await _lookupService.GetProductsBySubCategory(subcategoryId, sortBy);
            }
            catch
            {
                return BadRequest("Error: Cannot get Products");
            }
        }

        [HttpGet("/products/category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(int categoryId, string? sortBy)
        {
            try
            {
                if (sortBy == null)
                    sortBy = "";
                return await _lookupService.GetProductsByCategory(categoryId, sortBy);
            }
            catch
            {
                return BadRequest("Error: Cannot get Products");
            }
        }
    }
}