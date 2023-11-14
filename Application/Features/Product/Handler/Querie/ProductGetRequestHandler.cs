

using Assesment.Application.Contracts.Persistence;
using Assesment.Application.DTOs.Products;
using Assesment.Application.Features.Product.Request.Querie;
using AutoMapper;
using MediatR;

namespace Assesment.Application.Features.Product.Handler.Querie;

public class ProductGetRequestHandler : IRequestHandler<ProductGetRequest, ProductDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public ProductGetRequestHandler(IProductRepository productRepository,IMapper mapper)
    {
        _mapper = mapper;
        _productRepository = productRepository;
        
    }
    public async Task<ProductDto> Handle(ProductGetRequest request, CancellationToken cancellationToken)
    {
        
        var product = await _productRepository.GetAsync(request.Id);
        return _mapper.Map<ProductDto>(product);
    }
}
