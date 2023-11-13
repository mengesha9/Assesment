using Assesment.Application.Common.Responses;
using Assesment.Application.Contracts.Infrastructure;
using Assesment.Application.Contracts.Persistence;
using Assesment.Application.DTOs.User;
using Assesment.Application.Features.User.Handlers.Queries;
using Assesment.Application.Features.User.Request.Command;
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

public class RegisterUserCommandHandlerTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly UserRegistrationUserCommandHandler _handler;
    private readonly IJwtGenerator _jwtGenerator;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterUserCommandHandlerTest()
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
        _mockUserRepository = MockUserRepository.GetMockUserRepository();
        _jwtGenerator = new JwtGenerator(new DateTimeProvider(), jwtOptions);
        _passwordHasher = new PasswordHasher();
        _handler = new UserRegistrationUserCommandHandler(
            _mockUserRepository.Object,
            _jwtGenerator,
            _mapper,
            _passwordHasher
        );
    }

    [Fact]
    public async Task Valid_RegisterNewUser()
    {
        var newUser = new UserRegisterDto
        {
            Name = "user",
            Email = "User@gmail.com",
            Password = "User4password",
        };

        var result = await _handler.Handle(
            new UserRegistrationCommand { UserRegisterDto = newUser },
            CancellationToken.None
        );

        result.ShouldBeOfType<CommonResponse<UserLoggedInDto>>();
        result.IsSuccess.ShouldBeTrue();
        result.Value.ShouldNotBeNull();

        var Users = await _mockUserRepository.Object.GetAsync();
        Users.Count.ShouldBe(4);
    }

    [Fact]
    public async Task Invalid_InvalidEmailRegisterNewUser()
    {
        var newUser = new UserRegisterDto
        {
            Name = "user",
            Email = "user@",
            Password = "User4password",
        };

        var result = await _handler.Handle(
            new UserRegistrationCommand { UserRegisterDto = newUser },
            CancellationToken.None
        );

        result.ShouldBeOfType<CommonResponse<UserLoggedInDto>>();
        result.IsSuccess.ShouldBeFalse();
        result.Error.ShouldBe(new[] { "Email must be a valid email address." });
        result.Value.ShouldBeNull();
    }

    [Fact]
    public async Task Invalid_DuplicateEmailRegisterNewUsew()
    {
        var newUser = new UserRegisterDto
        {
            Name = "user",
            Email = "User@gmail.com",
            Password = "User4password",
        
        };

        await _handler.Handle(
            new UserRegistrationCommand { UserRegisterDto = newUser },
            CancellationToken.None
        );

        // Change the username (username and email need to be unique)
        newUser.Name = "new_name";

        var result = await _handler.Handle(
            new UserRegistrationCommand { UserRegisterDto = newUser },
            CancellationToken.None
        );

        result.ShouldBeOfType<CommonResponse<UserLoggedInDto>>();
        result.IsSuccess.ShouldBeFalse();
        result.Error.ShouldBe(new[] { "Email Exists." });
        result.Value.ShouldBeNull();
    }
    
 

    [Fact]
    public async Task Invalid_LongNameRegisterNewUsew()
    {
        var newUser = new UserRegisterDto
        {
            Name = "nameisveryverylongitshouldn'tbelongerthan20",
            Email = "User4@gmail.com",
            Password = "User4password",
        };

        var result = await _handler.Handle(
            new UserRegistrationCommand { UserRegisterDto = newUser },
            CancellationToken.None
        );

        result.ShouldBeOfType<CommonResponse<UserLoggedInDto>>();
        result.IsSuccess.ShouldBeFalse();
        result.Error.ShouldBe(new[] { " Name must not exceed 20 characters." });
        result.Value.ShouldBeNull();
    }

    [Fact]
    public async Task Invalid_ShorNameRegisterNewUsew()
    {
        var newUser = new UserRegisterDto
        {
            Name = "u",
            Email = "User4@gmail.com",
            Password = "User4password",
        };

        var result = await _handler.Handle(
            new UserRegistrationCommand { UserRegisterDto = newUser },
            CancellationToken.None
        );

        result.ShouldBeOfType<CommonResponse<UserLoggedInDto>>();
        result.IsSuccess.ShouldBeFalse();
        result.Error.ShouldBe(new[] { " Name must be at least 3 characters." });
        result.Value.ShouldBeNull();
    }

    [Fact]
    public async Task Invalid_EmptyEmailRegisterNewUsew()
    {
        var newUser = new UserRegisterDto
        {
            Name = "User4",
            Email = "",//Empty Email
            Password = "User4password",
        };

        var result = await _handler.Handle(
            new UserRegistrationCommand { UserRegisterDto = newUser },
            CancellationToken.None
        );

        result.ShouldBeOfType<CommonResponse<UserLoggedInDto>>();
        result.IsSuccess.ShouldBeFalse();
        result.Error.ShouldBe(new[] { "Email is required.", "Email must be at least 3 characters." });
        result.Value.ShouldBeNull();
    }
}
