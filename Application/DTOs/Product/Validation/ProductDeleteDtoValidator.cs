

using Assesment.Application.Contracts.Persistence;
using FluentValidation;

namespace Assesment.Application.DTOs.Product.Validation;
public class ProductDeleteDtoValidator:AbstractValidator<ProductDeleteDto>
{
    private readonly IProductRepository _productRepository;
    public ProductDeleteDtoValidator(IProductRepository productRepository)
    {
        _productRepository = productRepository;
        RuleFor(p=>p)
        .MustAsync(async (p,token) => {
            var result = await _productRepository.GetAsync(p.Id);
            if(result == null) {
                return false;
            }

            return true;

        });
        
    }
}