using Assesment.Application.Contracts.Persistence;
using FluentValidation;

namespace Assesment.Application.DTOs.Products.Validation;

public class ProductCreateDtoValidator : AbstractValidator<ProductDto>
{
    private readonly IProductRepository _productRepository;
    private readonly ICatagoryRepository _catagoryRepository;


    public ProductCreateDtoValidator(IProductRepository productRepository,ICatagoryRepository catagoryRepository)
    {
        _productRepository = productRepository;
        _catagoryRepository = catagoryRepository;

        RuleFor(p => p)
             .MustAsync(async(p,token)=>{
                var result  = await _catagoryRepository.GetNameAsync(p.CategoryName);
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

        RuleFor(u => u.CategoryName)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .MaximumLength(20)
            .WithMessage("{PropertyName} must not exceed 20 characters.")
            .MinimumLength(3)
            .WithMessage("{PropertyName} must be at least 3 characters.");   
        RuleFor(u=>u.Pricing) 
              .GreaterThan(0)   
              .WithMessage("{PropertyName} must be greater than 0")
        RuleFor(u=>u.Availability) 
              .GreaterThanOrEqual(0)   
              .WithMessage("{PropertyName} must be greater than or  equal to 0")      
              
    
    }

}