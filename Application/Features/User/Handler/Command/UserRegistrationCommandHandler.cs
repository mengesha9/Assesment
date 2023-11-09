using Assesment.Application.Common.Responses;
using Assesment.Application.Contracts.Infrastructure;
using Assesment.Application.Contracts.Persistence;
using Assesment.Application.DTOs.User;
using Assesment.Application.DTOs.User.Validation;
using Assesment.Application.Features.User.Request.Command;
using AutoMapper;
using MediatR;


namespace Assesment.Application.Features.User.Handlers.Queries;

public class UserRegistrationUserCommandHandler
    : IRequestHandler<UserRegistrationCommand, CommonResponse<UserLoggedInDto>>
{
    private IUserRepository _userRepository;
    private IJwtGenerator _jwtGenerator;
    private IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;

    public UserRegistrationUserCommandHandler(
        IUserRepository userRepository,
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
        UserRegistrationCommand request,
        CancellationToken cancellationToken
    )
    {
        var dtoValidator = new UserRequestDtoValidator();
        var validationResult = dtoValidator.Validate(request.UserRegisterDto);

        if (validationResult.IsValid == false)
        {
            return new CommonResponse<UserLoggedInDto>
            {
                IsSuccess = false,
                Message = "User registration failed.",
                Error = validationResult.Errors.Select(error => error.ErrorMessage).ToList()
            };
        }

        var userExists = await _userRepository.UsernameExists(
            request.UserRegisterDto.Name
        );

        if (userExists == true)
        {
            return new CommonResponse<UserLoggedInDto>
            {
                IsSuccess = false,
                Message = "User registration failed.",
                Error = new List<string> { "Username Exists." }
            };
        }

        userExists = await _userRepository.EmailExists(request.UserRegisterDto.Email);

        if (userExists == null)
        {
            return new CommonResponse<UserLoggedInDto>
            {
                IsSuccess = false,
                Message = "User registration failed.",
                Error = new List<string> { "Email Exists." }
            };
        }
        var createdUser = _mapper.Map<User>(request.UserRegisterDto);
        createdUser.Password = _passwordHasher.HashPassword(createdUser.Password);

        createdUser = await _userRepository.AddAsync(createdUser);

        var User = _mapper.Map<UserDto>(createdUser);
        var token = _jwtGenerator.Generate(createdUser);

        return new CommonResponse<UserLoggedInDto>
        {
            IsSuccess = true,
            Message = "User registration success.",
            Value = new UserLoggedInDto { UserDto = User, Token = token }
        };
    }
}
