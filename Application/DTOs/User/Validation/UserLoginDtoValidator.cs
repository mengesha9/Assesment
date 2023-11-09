
using FluentValidation;

namespace Assesment.Application.DTOs.User.Validation;

public class UserLoginDtoValidator:AbstractValidator<UserLoginDto>
{
    public UserLoginDtoValidator()
    {
        RuleFor(u => u.Password)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .MaximumLength(15)
            .WithMessage("{PropertyName} must not exceed 15 characters.")
            .MinimumLength(6)
            .WithMessage("{PropertyName} must be at least 6 characters.");

        RuleFor(u => u.Email)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .EmailAddress()
            .WithMessage("{PropertyName} must be a valid email address.");
        
    }
}