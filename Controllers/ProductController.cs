using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using WebService.Data;
using WebService.Models;

namespace WebService.Controller
{

    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IDistributedCache _cache;

        public ProductsController(AppDbContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            const string cacheKey = "products";
            var chachedProducts = await _cache.GetAsync("products");

            if (chachedProducts != null)
            {
                var serializedProducts = Encoding.UTF8.GetString(chachedProducts);
                var products = JsonSerializer.Deserialize<List<Product>>(serializedProducts);
                return Ok(products);
            }
            else
            {
                var products = _context.Products.ToList();
                var serialized = JsonSerializer.Serialize(products);
                var opt = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(5))
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));
                await _cache.SetAsync(cacheKey, Encoding.UTF8.GetBytes(serialized), opt);
                return Ok(products);
            }
            
        }
    }
}