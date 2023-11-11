

using Assesment.Application.Contracts.Persistence;
using Assesment.Application.DTOs.Product;
using Assesment.Application.Features.Product.Request.Querie;
using AutoMapper;
using MediatR;

namespace Assesment.Application.Features.Product.Handler.Querie;

public class ProductBookingRequestHandler : IRequestHandler<ProductBookingRequest, ProductDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public ProductBookingRequestHandler(IProductRepository productRepository,IMapper mapper)
    {
        _mapper = mapper;
        _productRepository = productRepository;
        
    }
  
    public async Task<ProductDto> Handle(ProductBookingRequest request, CancellationToken cancellationToken)
    {
        var result= await  _productRepository.Book(request.Id,request.Quantity);
        return _mapper.Map<ProductDto>(result);
    }
}
