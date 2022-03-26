using Api.Dto;
using AutoMapper;
using Models.Entities;

namespace Api.Helpers
{
    
        public class ProductUrlResvoler : IValueResolver<Product,ProductDto, string>
        {
            private readonly IConfiguration _config;

            public ProductUrlResvoler(IConfiguration config)
            {
                _config = config;
            }

            public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
            {
                if (!string.IsNullOrEmpty(source.PictureUrl)) return _config["ApiUrl"] + source.PictureUrl;
                return null;
            }
        }
 
}
