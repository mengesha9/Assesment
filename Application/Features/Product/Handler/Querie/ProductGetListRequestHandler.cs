

using Assesment.Application.Contracts.Persistence;
using Assesment.Application.DTOs.Products;
using Assesment.Application.Features.Product.Request.Querie;
using AutoMapper;
using MediatR;

namespace Assesment.Application.Features.Product.Handler.Querie;

public class ProductGetListRequestHandler : IRequestHandler<ProductGetListRequest, List<ProductDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public ProductGetListRequestHandler(IProductRepository productRepository,IMapper mapper)
    {
        _mapper = mapper;
        _productRepository = productRepository;
        
    }
    public async Task<List<ProductDto>> Handle(ProductGetListRequest request, CancellationToken cancellationToken)
    {
        
        var product = await _productRepository.GetAsync();
        return _mapper.Map<List<ProductDto>>(product);
    }

}
