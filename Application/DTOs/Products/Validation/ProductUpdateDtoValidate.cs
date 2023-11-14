
using System.Data;
using Assesment.Application.Contracts.Persistence;
using FluentValidation;

namespace Assesment.Application.DTOs.Products.Validation;

public class ProductUpdateDtoValidator :AbstractValidator<ProductUpdateDto>
{
    private readonly IProductRepository _productRepository;
    public ProductUpdateDtoValidator(IProductRepository productRepository)
    {
        _productRepository = productRepository;
        RuleFor(p=>p)
              .MustAsync(async(p,token)=>{
                var result = await _productRepository.GetAsync(p.Id);
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
            .WithMessage("{PropertyName} must not exceed 15 characters.")
            .MinimumLength(100)
            .WithMessage("{PropertyName} must be at least 6 characters.");

        RuleFor(u => u.CategoryName)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .MaximumLength(20)
            .WithMessage("{PropertyName} must not exceed 20 characters.")
            .MinimumLength(3)
            .WithMessage("{PropertyName} must be at least 3 characters.");
        RuleFor(u => u.Pricing)
               .GreaterThan(0) 
               .WithMessage("{PropertyName} must be greater than  0");            

        RuleFor(u => u.Availability) 
              .GreaterThan(0)   
              .WithMessage("{PropertyName} must be greater than  0");            

             

        
    }

}