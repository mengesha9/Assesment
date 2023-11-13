using Assesment.Application.Contracts.Persistence;
using FluentValidation;

namespace Assesment.Application.DTOs.Catagory.Validation;

public class CatagoryCreateDtoValidate : AbstractValidator<CatagoryCreateDto>
{
    private readonly ICatagoryRepository _catagoryRepository;
     

    public CatagoryCreateDtoValidate(ICatagoryRepository catagoryRepository)
    {
        _catagoryRepository = catagoryRepository;

        RuleFor(p => p)
             .MustAsync(async(p,token)=>{
                var result  = await _catagoryRepository.GetNameAsync(p.Name);
                if(result == null){
                    return false;
                }
                return true;
             });
        RuleFor(u => u.Name)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .MaximumLength(20)
            .WithMessage("{PropertyName} must not exceed 20 characters.")
            .MinimumLength(3)
            .WithMessage("{PropertyName} must be at least 3 characters.");

        RuleFor(u => u.Description)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .MaximumLength(1500)
            .WithMessage("{PropertyName} must not exceed 1500 characters.")
            .MinimumLength(100)
            .WithMessage("{PropertyName} must be at least 100 characters.");

    
    }

}