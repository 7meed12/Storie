using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Entities;
using Models.Interfaces;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _repo;
        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            
            return Ok(await _repo.GetProductTyepsAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
          return  await _repo.GetProductByIdAsync(id);
            
        }
        [HttpGet("types")]
        public async Task<IActionResult> GetProductTypes()
        {
           
            return Ok(await _repo.GetProductTypesAsync());
        }
        [HttpGet("brands")]
        public async Task<IActionResult> GetProductBrands()
        {
            
            return Ok(await _repo.GetProductBrandsAsync());
        }

    }
}
