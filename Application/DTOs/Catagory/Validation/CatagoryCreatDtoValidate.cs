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
                var result  = await _catagoryRepository.GetAsync(p.Name);
                if(result == null){
                    return false;
                }
                return true;
             });
    
    }

}