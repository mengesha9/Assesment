using Assesment.Application.Common.Responses;
using Assesment.Application.DTOs.User;
using MediatR;

namespace Assesment.Application.Features.User.Request.Command;

public class UserRegistrationCommand:IRequest<CommonResponse<UserLoggedInDto>>
{
    public UserRegisterDto UserRegisterDto {get;set;}

}