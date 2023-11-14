using Assesment.Application.DTOs.Catagory;
using Assesment.Domain.Entites;
using AutoMapper;

namespace Assesment.Application.Profiles;

public  class CatagoryProfile:Profile
{
    public CatagoryProfile()
    {
        CreateMap<Category, CatagoryDto>().ReverseMap();
        CreateMap<Category, CatagoryCreateDto>().ReverseMap(); 
        CreateMap<Category,CatagoryDeleteDto>().ReverseMap();
        CreateMap<Category,CatagoryUpdateDto>().ReverseMap();
        CreateMap<Category,CatagoryGetDto>().ReverseMap();

    }
}