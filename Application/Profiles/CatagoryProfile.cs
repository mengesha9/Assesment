using Assesment.Application.DTOs.Catagory;
using Assesment.Domain.Entites;
using AutoMapper;

namespace Assesment.Application.Profiles;

public  class CatagoryProfile:Profile
{
    public CatagoryProfile()
    {
        CreateMap<Catagory, CatagoryDto>().ReverseMap();
        CreateMap<Catagory, CatagoryCreateDto>().ReverseMap(); 
        CreateMap<Catagory,CatagoryDeleteDto>().ReverseMap();
        CreateMap<Catagory,CatagoryUpdateDto>().ReverseMap();
        CreateMap<Catagory,CatagoryGetDto>().ReverseMap();

    }
}