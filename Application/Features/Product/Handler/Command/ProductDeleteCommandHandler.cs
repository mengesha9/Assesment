

using Assesment.Application.Contracts.Persistence;
using Assesment.Application.DTOs.Product.Validation;
using Assesment.Application.Features.Product.Request.command;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.VisualBasic;

namespace Assesment.Application.Features.Product.Handler.Command;


public class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteCommand, Unit>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public ProductDeleteCommandHandler(IProductRepository productRepository,IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper=mapper;
        
    }
    public async Task<Unit> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
    {   
        var vallidate = new ProductDeleteDtoValidator(_productRepository);
        var result = await vallidate.ValidateAsync(request.ProductDeleteDto);
        if(!result.IsValid){
            return Unit.Value;

        }
        var entity =  await _productRepository.GetAsync(request.ProductDeleteDto.Id);
        await _productRepository.DeleteAsync(entity);
        await _productRepository.SaveChangesAsync();

        return Unit.Value;

    }
}
