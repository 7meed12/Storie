
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Interfaces;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {   
        private readonly StoreContext _storeContext;
        public ProductRepository(StoreContext db)
        {
            _storeContext=db;
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _storeContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _storeContext.Products.FindAsync(id);
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _storeContext.ProductTypes.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _storeContext.ProductBrands.ToListAsync();
        }
    }
}
