using Assesment.Application.Contracts.Persistence;
using FluentValidation;

namespace Assesment.Application.DTOs.Catagory.Validation;

public class CatagoryDeleteDtoValidate : AbstractValidator<CatagoryDeleteDto>
{
    private readonly ICatagoryRepository _catagoryRepository;
     

    public CatagoryDeleteDtoValidate(ICatagoryRepository catagoryRepository)
    {
        _catagoryRepository = catagoryRepository;

        RuleFor(p => p)
             .MustAsync(async(p,token)=>{
                var result  = await _catagoryRepository.GetAsync(p.Id);
                if(result == null){
                    return false;
                }
                return true;
             });
    
    }

}