using AdventureApp.Models.Entities;
using AdventureApp.Models.RequestDtos;
using AutoMapper;

namespace AdventureApp.Mapping
{
    public class MappingProfile : Profile
    {   
        public MappingProfile() 
        {   
            CreateMap<ProductRequestDto, Product>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

            CreateMap<Product, ProductRequestDto>();
        }
    }
}
