using Assesment.Application.DTOs.User;
using Assesment.Domain.Entites;

namespace Assesment.Application.DTOs.User;

public class UserLoggedInDto
{
    public UserDto UserDto { get; set; } = null!;
    public string Token { get; set; } = null!;
}
