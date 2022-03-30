
using Api.Dto;
using Api.Errors;
using Api.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using Models.Entities;
using Models.Interfaces;
using Models.Specifications;

namespace Api.Controllers
{
   
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _brandRepo;
        private readonly IGenericRepository<ProductType> _typeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> ProductRepo, IGenericRepository<ProductBrand> BrandRepo,
            IGenericRepository<ProductType> TypeRepo , IMapper mapper)
        {
            _productRepo = ProductRepo;
            _brandRepo = BrandRepo;
            _typeRepo = TypeRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductDto>>> GetProducts([FromQuery]ProductSpecParams param)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(param);
            var count = new ProductWithFiltersCount(param);
            var totalItems = await _productRepo.CountAsync(count);
            var products = await _productRepo.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);
            
            return Ok(new Pagination<ProductDto>(param.PageIndex,param.PageSize,totalItems,data));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
           var product =  await _productRepo.GetEntityWithSpec(spec);
            if(product == null) return NotFound(new ApiResponses(404));
            return  _mapper.Map<Product, ProductDto>(product);


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
