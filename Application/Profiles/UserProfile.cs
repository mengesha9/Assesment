

using Assesment.Application.DTOs.User;
using Assesment.Domain.Entites;
using AutoMapper;
namespace Assesment.Application.Profiles;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserLoginDto>().ReverseMap();
        CreateMap<User, UserRegisterDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, UserLoggedInDto>().ReverseMap();


 
    }

}