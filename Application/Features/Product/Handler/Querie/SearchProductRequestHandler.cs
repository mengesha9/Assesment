

using Assesment.Application.Contracts.Persistence;
using Assesment.Application.DTOs.Products;
using Assesment.Application.Features.Product.Request.Querie;
using AutoMapper;
using MediatR;

namespace Assesment.Application.Features.Product.Handler.Querie;

public class SearchProductRequestHandler : IRequestHandler<SearchProductRequest, List<ProductDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly ICatagoryRepository _catagoryRepository;
    private readonly IMapper _mapper;
    public SearchProductRequestHandler(IProductRepository productRepository,IMapper mapper)
    {
        _mapper = mapper;
        _productRepository = productRepository;
        
    }
    public async Task<List<ProductDto>> Handle(SearchProductRequest request, CancellationToken cancellationToken)
    {
        var result = _catagoryRepository.GetNameAsync(request.Name);
        if(result == null){

            var name = await _productRepository.GetByName(request.Name);

            return _mapper.Map<List<ProductDto>>(name);
        }
        var category =await  _productRepository.GetByCategoryName(request.Name);

        return  _mapper.Map<List<ProductDto>>(category);
        
    }

}
