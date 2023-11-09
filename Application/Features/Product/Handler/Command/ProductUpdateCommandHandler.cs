

using Assesment.Application.Contracts.Persistence;
using Assesment.Application.DTOs.Product.Validation;
using Assesment.Application.Features.Product.Request.command;
using Assesment.Domain.Entites;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Unit>
{

    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductUpdateCommandHandler(IProductRepository productRepository,IMapper mapper)
    {
        _productRepository =productRepository;
        _mapper = mapper;
        
    }
    
    public async Task<Unit> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
    {
        var vallidate= new ProductUpdateDtoValidator(_productRepository);
        var result = await vallidate.ValidateAsync(request.ProductUpdateDto);
        if(!result.IsValid){
            return Unit.Value;

        }
        var product = _mapper.Map<Product>(request.ProductUpdateDto);
        await _productRepository.UpdateAsync(product);
        await _productRepository.SaveChangesAsync();
        return Unit.Value;
    }
}
