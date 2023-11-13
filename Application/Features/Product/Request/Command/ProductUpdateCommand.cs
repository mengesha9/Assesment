using Assesment.Application.DTOs.Products;
using MediatR;

namespace Assesment.Application.Features.Product.Request.command;

public class ProductUpdateCommand:IRequest<Unit>
{
    public ProductUpdateDto ProductUpdateDto {get;set;}
}