using Assesment.Application.Contracts.Persistence;
using Assesment.Application.DTOs.Catagory;
using Assesment.Application.Features.Catagory.Request.Querie;
using AutoMapper;
using MediatR;

namespace Assesment.Application.Features.Catagory.Handler.Querie;

public class CatagoryGetListReqeustHandler : IRequestHandler<CatagoryGetListReqeust, List<CatagoryDto>>
{
    private readonly ICatagoryRepository _catagoryRepository;
    private readonly IMapper _mapper;
    public CatagoryGetListReqeustHandler(ICatagoryRepository catagoryRepository,IMapper mapper)
    {
        _catagoryRepository = catagoryRepository;
        _mapper = mapper;
        
    }
    public async Task<List<CatagoryDto>> Handle(CatagoryGetListReqeust request, CancellationToken cancellationToken)
    {
        var catagory = await _catagoryRepository.GetAsync();
        return _mapper.Map<List<CatagoryDto>>(catagory);
    }
}
