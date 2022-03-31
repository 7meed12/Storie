
using Models.Entities;

namespace Models.Specifications
{
    public class ProductWithFiltersCount : BaseSpecification<Product>
    {
        public ProductWithFiltersCount(ProductSpecParams param) :base(x=>
                (!string.IsNullOrEmpty(param.Search) || x.Name.ToLower().Contains(param.Search))&&
                (!param.brandId.HasValue || x.ProductBrandId==param.brandId) &&
                (!param.typeId.HasValue || x.ProductTypeId==param.typeId))
        {
                
        }
    }
}
