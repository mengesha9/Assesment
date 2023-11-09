

using MediatR;
using Assesment.Application.Features.Product.Request.command;
using Assesment.Application.Contracts.Persistence;
using Assesment.Application.DTOs.Product.Validation;
using AutoMapper;
using Assesment.Application.DTOs.Product;
namespace Assesment.Application.Features.Product.Handler.Command;

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
        var result = await vallidate.ValidateAsync(request.ProductCreateDto);
        if(!result.IsValid){
            return Unit.Value;

        }
        var product = _mapper.Map<Product>(request.ProductCreateDto);
        await _productRepository.AddAsync(product);
        await _productRepository.SaveChangesAsync();
        return Unit.Value;

    }
}
