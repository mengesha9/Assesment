using Assesment.Application.Contracts.Persistence;
using Assesment.Application.DTOs.Catagory;
using Assesment.Application.Features.Catagory.Request.Querie;
using AutoMapper;
using MediatR;

namespace Assesment.Application.Features.Catagory.Handler.Querie;

public class CatagoryGetReqeustHandler : IRequestHandler<CatagoryGetReqeust, CatagoryDto>
{
    private readonly ICatagoryRepository _catagoryRepository;
    private readonly IMapper _mapper;
    public CatagoryGetReqeustHandler(ICatagoryRepository catagoryRepository,IMapper mapper)
    {
        _catagoryRepository = catagoryRepository;
        _mapper = mapper;
        
    }
    public async Task<CatagoryDto> Handle(CatagoryGetReqeust request, CancellationToken cancellationToken)
    {
        var catagory = await _catagoryRepository.GetAsync(request.Id);
        return _mapper.Map<CatagoryDto>(catagory);
    }
}
