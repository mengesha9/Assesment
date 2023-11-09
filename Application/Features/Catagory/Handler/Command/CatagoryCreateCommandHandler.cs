using Assesment.Application.Contracts.Persistence;
using Assesment.Application.Features.Catagory.Request.Command;
using AutoMapper;
using MediatR;
using Assesment.Domain.Entites;
using Assesment.Application.DTOs.Catagory.Validation;
namespace Assesment.Application.Features.Catagory.Handler.Command;

public class CatagoryCreateCommandHandler : IRequestHandler<CatagoryCreateCommand, Unit>
{


    private readonly ICatagoryRepository _catagoryRepository;
    private readonly IMapper _mapper;
    public CatagoryCreateCommandHandler(ICatagoryRepository catagoryRepository,IMapper mapper)
    {
        _catagoryRepository =catagoryRepository;
        _mapper=mapper;
        
    }

   
    public async Task<Unit> Handle(CatagoryCreateCommand request, CancellationToken cancellationToken)
    {

        var vallidate = new CatagoryCreateDtoValidate(_catagoryRepository);
        var result = await vallidate.ValidateAsync(request.CatagoryCreateDto);
        if(result.IsValid){
            return Unit.Value;

        }

        var catagory = _mapper.Map<Catagory>(request.CatagoryCreateDto);
        await _catagoryRepository.AddAsync(catagory);
        await _catagoryRepository.SaveChangesAsync();
        return Unit.Value;

    }
}
