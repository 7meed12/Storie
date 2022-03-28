
using Models.Entities;
using System.Linq.Expressions;

namespace Models.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(string? sort, int? brandId, int? typeId):
            base(x=>
                (!brandId.HasValue || x.ProductBrandId==brandId) &&
                (!typeId.HasValue || x.ProductTypeId==typeId))
        {
            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);
            AddOrderBy(x => x.Name);
            if(!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc": AddOrderBy(x=>x.Price); break;
                    case "priceDesc": AddOrderByDesc(x => x.Price); break;
                        default: AddOrderBy(x=>x.Name); break;
                }
            }
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);
        }
       
    }
}
