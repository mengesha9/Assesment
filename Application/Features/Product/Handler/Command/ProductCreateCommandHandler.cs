

using MediatR;
using Assesment.Application.Features.Products.Request.command;
using Assesment.Application.Contracts.Persistence;
using Assesment.Application.DTOs.Products.Validation;
using AutoMapper;
namespace Assesment.Application.Features.Products.Handler.Command;

public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Unit>
{
    private readonly IProductRepository _productRepository;
    private readonly ICatagoryRepository _catagoryRepository;
    private readonly IMapper _mapper;
    public ProductCreateCommandHandler(IProductRepository productRepository,ICatagoryRepository catagoryRepository,IMapper mapper)
    {
        _productRepository =productRepository;
        _catagoryRepository =catagoryRepository;
        _mapper=mapper;
        
    }
    public async Task<Unit> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
    {

        var vallidate = new ProductCreateDtoValidator(_productRepository,_catagoryRepository);
        var result = await vallidate.ValidateAsync(request.ProductDto);
        if(!result.IsValid){
            return Unit.Value;

        }
        var product = _mapper.Map<Assesment.Domain.Entites.Product>(request.ProductDto);
        await _productRepository.AddAsync(product);
        return Unit.Value;

    }
}
