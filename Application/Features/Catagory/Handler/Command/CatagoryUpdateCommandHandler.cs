using Assesment.Application.Contracts.Persistence;
using Assesment.Application.Features.Catagory.Request.Command;
using AutoMapper;
using MediatR;
using Assesment.Domain.Entites;
using Assesment.Application.DTOs.Catagory.Validation;
namespace Assesment.Application.Features.Catagory.Handler.Command;

public class CatagoryUpdateCommandHandler : IRequestHandler<CatagoryUpdateCommand, Unit>
{


    private readonly ICatagoryRepository _catagoryRepository;
    private readonly IMapper _mapper;
    public CatagoryUpdateCommandHandler(ICatagoryRepository catagoryRepository,IMapper mapper)
    {
        _catagoryRepository =catagoryRepository;
        _mapper=mapper;
        
    }

   
    public async Task<Unit> Handle(CatagoryUpdateCommand request, CancellationToken cancellationToken)
    {

        var vallidate = new CatagoryUpdateDtoValidate(_catagoryRepository);
        var result = await vallidate.ValidateAsync(request.CatagoryUpdateDto);
        if(!result.IsValid){
            return Unit.Value;

        }

        var catagory = _mapper.Map<Catagory>(request.CatagoryUpdateDto);
        await _catagoryRepository.UpdateAsync(catagory);
        await _catagoryRepository.SaveChangesAsync();
        return Unit.Value;

    }

    
}
