using Assesment.Application.Contracts.Infrastructure;
using Assesment.Application.Contracts.Persistence;
using Assesment.Application.DTOs.User;
using Assesment.Application.Features.User.Request.Querie;
using AutoMapper;
using MediatR;
using Assesment.Application.Common.Responses;
using Assesment.Application.DTOs.User.Validation;
using Assesment.Application.DTOs.User;
using Assesment.Application.DTOs.User;

namespace Assesment.Application.Features.Authentication.Handlers.Queries;

public class UserLoginCommandHandler: IRequestHandler<UserLoginCommand, CommonResponse<UserLoggedInDto>>
{
    private IUserRepository _userRepository;
    private IJwtGenerator _jwtGenerator;
    private IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;

    public UserLoginCommandHandler(
        IUserRepository userRepository ,
        IJwtGenerator jwtGenerator,
        IMapper mapper,
        IPasswordHasher passwordHasher
    )
    {
        _userRepository = userRepository;
        _jwtGenerator = jwtGenerator;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }

  
    public async Task<CommonResponse<UserLoggedInDto>> Handle(
        UserLoginCommand request,
        CancellationToken cancellationToken
    )
    {
        var dtoValidator = new UserLoginDtoValidator();
        var validationResult = dtoValidator.Validate(request.UserLoginDto);

        if (validationResult.IsValid == false)
        {
            return new CommonResponse<UserLoggedInDto>
            {
                IsSuccess = false,
                Message = "User login failed.",
                Error = validationResult.Errors.Select(error => error.ErrorMessage).ToList()
            };
        }

        // Check user existence and password
        var existingUser = await _userRepository.EmailExists(request.UserLoginDto.Email);
        if (existingUser == null)
        {
            return new CommonResponse<UserLoggedInDto>
            {
                IsSuccess = false,
                Message = "User login failed.",
                Error = new List<string> { "User not found." }
            };
        }

        var passwordsMatch = _passwordHasher.VerifyPassword(
            existingUser.Password,
            request.UserLoginDto.Password
        );

        if (passwordsMatch == false)
        {
            return new CommonResponse<UserLoggedInDto>
            {
                IsSuccess = false,
                Message = "User login failed.",
                Error = new List<string> { "Username or Password is incorrect." }
            };
        }
        var User = _mapper.Map<UserDto>(existingUser);
        var token = _jwtGenerator.Generate(existingUser);

        return new CommonResponse<UserLoggedInDto>
        {
            IsSuccess = true,
            Message = "User login successfull.",
            Value = new UserLoggedInDto { UserDto = User, Token = token }
        };

    }
}
