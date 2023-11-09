
using System.Data;
using Assesment.Application.Contracts.Persistence;
using FluentValidation;

namespace Assesment.Application.DTOs.Product.Validation;

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
        
    }

}