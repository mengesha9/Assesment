using Assesment.Application.DTOs.User;
using Assesment.Application.Features.User.Request.Command;
using Assesment.Application.Features.User.Request.Querie;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Assesment.WebApi.Controller;

[ApiController]
[Route("api/auth")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Queries
    [HttpPost("register")]
    public async Task<ActionResult<UserLoginDto>> Register([FromBody] UserRegisterDto request)
    {
        var response = await _mediator.Send(new UserRegistrationCommand { UserRegisterDto = request });
        return Ok(response);
    }

    #endregion
    #region Commands
    [HttpPost("login")]
    public async Task<ActionResult<UserLoginDto>> Login([FromBody] UserLoginDto request)
    {
        var response = await _mediator.Send(new UserLoginCommand { UserLoginDto = request });
        return Ok(response);
    }
    #endregion
}
