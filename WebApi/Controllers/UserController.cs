using Assesment.Application.DTOs.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialSync.Application.DTOs.Authentication;
using SocialSync.Application.Features.Authentication.Requests.Commands;
using SocialSync.Application.Features.Authentication.Requests.Queries;

namespace SocialSync.WebApi.Controller;

[ApiController]
[Route("api/auth")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Queries
    [HttpPost("register")]
    public async Task<ActionResult<UserLoginDto>> Register([FromBody] UserRegisterDto request)
    {
        var response = await _mediator.Send(new UserRegistrationCommand { RegisterUserDto = request });
        return Ok(response);
    }

    #endregion
    #region Commands
    [HttpPost("login")]
    public async Task<ActionResult<UserLoginDto>> Login([FromBody] UserLoginDto request)
    {
        var response = await _mediator.Send(new LoginUserRequest { LoginUserDto = request });
        return Ok(response);
    }
    #endregion
}
