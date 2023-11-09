using Assesment.Application.Contracts.Persistence;
using FluentValidation;

namespace Assesment.Application.DTOs.Product.Validation;

public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
{
    private readonly IProductRepository _productRepository;
    private readonly ICatagoryRepository _catagoryRepository;


    public ProductCreateDtoValidator(IProductRepository productRepository,ICatagoryRepository catagoryRepository)
    {
        _productRepository = productRepository;
        _catagoryRepository = catagoryRepository;

        RuleFor(p => p)
             .MustAsync(async(p,token)=>{
                var result  = await _catagoryRepository.GetAsync(p.Category);
                if(result == null){
                    return false;
                }
                return true;
             });
    
    }

}