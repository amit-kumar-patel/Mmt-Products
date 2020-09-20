using AutoMapper;
using MmtProducts.Api.ViewModels;
using MmtProducts.Domain;

namespace MmtProducts.Api.MappingProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<Category, CategoryViewModel>();
        }
    }
}
