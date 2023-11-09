
using Assesment.Application.DTOs.Common;
using Assesment.Application.DTOs.Product;
using Assesment.Domain.Common;
using Assesment.Domain.Entites;
using AutoMapper;

namespace Assesment.Application.Profiles;
public class ProductProfile:Profile
{
    public ProductProfile()
    {
        CreateMap<BaseDomainEntity,BaseDto>().ReverseMap();
        
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Product, ProductUpdateDto>().ReverseMap(); 
        CreateMap<Product,ProductCreateDto>().ReverseMap();
        CreateMap<Product,ProductDeleteDto>().ReverseMap();
        
    }
}
