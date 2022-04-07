
using Models.Entities;
using System.Linq.Expressions;

namespace Models.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams param):
            base(x=>
                (string.IsNullOrEmpty(param.Search) || x.Name.ToLower().Contains(param.Search))&&
                (!param.brandId.HasValue || x.ProductBrandId==param.brandId) &&
                (!param.typeId.HasValue || x.ProductTypeId==param.typeId))
        {
            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);
            AddOrderBy(x => x.Name);
            ApplyPaging(param.PageSize *(param.PageIndex-1), param.PageSize);
            if(!string.IsNullOrEmpty(param.sort))
            {
                switch (param.sort)
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
