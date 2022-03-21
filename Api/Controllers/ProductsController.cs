
using Microsoft.AspNetCore.Mvc;

using Models.Entities;
using Models.Interfaces;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        public IGenericRepository<Product> _productRepo;
        public IGenericRepository<ProductBrand> _brandRepo;
        public IGenericRepository<ProductType> _typeRepo;
        public ProductsController(IGenericRepository<Product> ProductRepo, IGenericRepository<ProductBrand> BrandRepo,
            IGenericRepository<ProductType> TypeRepo)
        {
            _productRepo = ProductRepo;
            _brandRepo = BrandRepo;
            _typeRepo = TypeRepo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            
            return Ok(await _productRepo.ListAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
          return  await _productRepo.GetByIdAsync(id);
            
        }
        [HttpGet("types")]
        public async Task<IActionResult> GetProductTypes()
        {
           
            return Ok(await _typeRepo.ListAllAsync());
        }
        [HttpGet("brands")]
        public async Task<IActionResult> GetProductBrands()
        {

            return Ok(await _brandRepo.ListAllAsync());
        }

    }
}
