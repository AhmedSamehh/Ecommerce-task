using ecommerce_task.Models;
using ecommerce_task.Services;
using hotel_backend.Data;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(int subcategoryId, string? sortBy, [FromQuery] PaginationParameters @params)
        {
            try
            {
                if (sortBy == null)
                    sortBy = "";

                var products = await _lookupService.GetProductsBySubCategory(subcategoryId, sortBy, @params);

                var paginationMetaData = new PaginationMetadata(products.Count(), @params.Page, @params.ItemsPerPage);

                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetaData));
                Response.Headers.Add("Access-Control-Expose-Headers", "X-Pagination");

                var paginatedProducts = products.Skip((@params.Page - 1) * @params.ItemsPerPage)
                .Take(@params.ItemsPerPage);

                return paginatedProducts.ToList();
            }
            catch
            {
                return BadRequest("Error: Cannot get Products");
            }
        }

        [HttpGet("/products/category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(int categoryId, [FromQuery] PaginationParameters @params)
        {
            try 
            { 
                var products = await _lookupService.GetProductsByCategory(categoryId, @params);
                var paginationMetaData = new PaginationMetadata(products.Count(), @params.Page, @params.ItemsPerPage);

                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetaData));
                Response.Headers.Add("Access-Control-Expose-Headers", "X-Pagination");

                var paginatedProducts = products.Skip((@params.Page - 1) * @params.ItemsPerPage)
                .Take(@params.ItemsPerPage);

                return paginatedProducts.ToList();
            }
            catch
            {
                return BadRequest("Error: Cannot get Products");
            }
        }
    }
}