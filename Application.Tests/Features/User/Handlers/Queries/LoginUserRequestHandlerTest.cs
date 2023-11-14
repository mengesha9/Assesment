using Assesment.Application.Common.Responses;
using Assesment.Application.Contracts.Infrastructure;
using Assesment.Application.Contracts.Persistence;
using Assesment.Application.DTOs.User;
using Assesment.Application.Features.Authentication.Handlers.Queries;
using Assesment.Application.Features.User.Handlers.Queries;
using Assesment.Application.Features.User.Request.Querie;
using Assesment.Application.Profiles;
using Assesment.Application.Tests.Mocks;
using Assesment.Infrastructure.DateTimeService;
using Assesment.Infrastructure.JWT;
using Assesment.Infrastructure.PasswordService;
using AutoMapper;
using Microsoft.Extensions.Options;
using Moq;
using Shouldly;


namespace SocialSync.Application.Tests.Features.Authentication.Handlers.Commands;

public class LoginUserRequestHandlerTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IUserRepository> _mockuserRepository;
    private readonly UserRegistrationUserCommandHandler _registerHandler;
    private readonly UserLoginCommandHandler _handler;
    private readonly IJwtGenerator _jwtGenerator;
    private readonly IPasswordHasher _passwordHasher;

    public LoginUserRequestHandlerTest()
    {
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<UserProfile>();
        });
        var jwtSettings = new JwtSettings
        {
            Secret = "Assesment-ass-JWT-Secret-and-then-some",
            Issuer = "assesemtn",
            Audience = "assesment",
            ExpiryMinutes = 60
        };
        var jwtOptions = Options.Create(jwtSettings);
        _mapper = mapperConfig.CreateMapper();
        _mockuserRepository = MockUserRepository.GetMockUserRepository();
        _jwtGenerator = new JwtGenerator(new DateTimeProvider(), jwtOptions);
        _passwordHasher = new PasswordHasher();
        _handler = new UserLoginCommandHandler(
            _mockuserRepository.Object,
            _jwtGenerator,
            _mapper,
            _passwordHasher
        );

        _registerHandler = new UserRegistrationUserCommandHandler(
            _mockuserRepository.Object,
            _jwtGenerator,
            _mapper,
            _passwordHasher
        );
    }

    [Fact]
    public async Task Valid_LoginUser()
    {
        var result = await _handler.Handle(
            new UserLoginCommand
            {
                UserLoginDto = new UserLoginDto { Email = "User32@gmail.com", Password = "User3password" }
            },
            CancellationToken.None
        );

        result.ShouldBeOfType<CommonResponse<UserLoggedInDto>>();
        result.IsSuccess.ShouldBeTrue();
        result.Value.Token.ShouldNotBeNullOrEmpty();
    }

    [Fact]
    public async Task Invalid_IncorrectPasswordLoginUser()
    {
        var result = await _handler.Handle(
            new UserLoginCommand
            {
                UserLoginDto = new UserLoginDto
                {
                    Email = "User32@gmail.com",
                    Password = "User3passwordiswrong"
                }
            },
            CancellationToken.None
        );

        result.ShouldBeOfType<CommonResponse<UserLoggedInDto>>();
        result.IsSuccess.ShouldBeFalse();
        result.Value.ShouldBeNull();
    }

    [Fact]
    public async Task Invalid_NonExistingUsernameLoginUser()
    {
        var result = await _handler.Handle(
            new UserLoginCommand
            {
                UserLoginDto = new UserLoginDto
                {
                    Email = "ashebir@gmail.com",
                    Password = "User3password"
                }
            },
            CancellationToken.None
        );

        result.ShouldBeOfType<CommonResponse<UserLoggedInDto>>();
        result.IsSuccess.ShouldBeFalse();
        result.Value.ShouldBeNull();
    }

    [Fact]
    public async Task Invalid_InvalidUsernameLogin()
    {
        var result = await _handler.Handle(
            new UserLoginCommand
            {
                UserLoginDto = new UserLoginDto { Email = "Us", Password = "User3password" }
            },
            CancellationToken.None
        );

        result.ShouldBeOfType<CommonResponse<UserLoggedInDto>>();
        result.IsSuccess.ShouldBeFalse();
        result.Error.ShouldBe(new[] { "Username must be at least 3 characters." });
        result.Value.ShouldBeNull();
    }

    [Fact]
    public async Task Invalid_InvalidPasswordLogin()
    {
        var result = await _handler.Handle(
            new UserLoginCommand
            {
                UserLoginDto = new UserLoginDto { Email = "User3", Password = "u3" }
            },
            CancellationToken.None
        );

        result.ShouldBeOfType<CommonResponse<UserLoggedInDto>>();
        result.IsSuccess.ShouldBeFalse();
        result.Error.ShouldBe(new[] { "Password must be at least 6 characters." });
        result.Value.ShouldBeNull();
    }
}
