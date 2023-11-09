using Assesment.Application.Common.Responses;
using Assesment.Application.DTOs.User;
using MediatR;

namespace Assesment.Application.Features.User.Request.Querie;

public class UserLoginCommand:IRequest<CommonResponse<UserLoggedInDto>>
{
    public UserLoginDto UserLoginDto {get;set;}

}