using Api.Dto;
using AutoMapper;
using Models.Entities;

namespace Api.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(x => x.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(x => x.ProductType, o => o.MapFrom(s => s.ProductType.Name));
        }

    }
}
