using Assesment.Application.DTOs.Common;

namespace Assesment.Application.DTOs.User;

public class UserDto : BaseDto
{
    public string Name { get; set; } 
    public string Password { get; set; }     
    public string Email { get; set; } 
}
