using Assesment.Application.Contracts.Persistence;
using Assesment.Application.Features.Catagory.Request.Command;
using AutoMapper;
using MediatR;
using Assesment.Domain.Entites;
using Assesment.Application.DTOs.Catagory.Validation;
namespace Assesment.Application.Features.Catagory.Handler.Command;

public class CatagoryDeleteCommandHandler : IRequestHandler<CatagoryDeleteCommand, Unit>
{


    private readonly ICatagoryRepository _catagoryRepository;
    private readonly IMapper _mapper;
    public CatagoryDeleteCommandHandler(ICatagoryRepository catagoryRepository,IMapper mapper)
    {
        _catagoryRepository =catagoryRepository;
        _mapper=mapper;
        
    }

   
    public async Task<Unit> Handle(CatagoryDeleteCommand request, CancellationToken cancellationToken)
    {

        var vallidate = new CatagoryDeleteDtoValidate(_catagoryRepository);
        var result = await vallidate.ValidateAsync(request.CatagoryDeleteDto);
        if(!result.IsValid){
            return Unit.Value;

        }

        var catagory = _mapper.Map<Catagory>(request.CatagoryDeleteDto);
        await _catagoryRepository.DeleteAsync(catagory);
        await _catagoryRepository.SaveChangesAsync();
        return Unit.Value;

    }

    
}
