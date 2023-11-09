using Assesment.Application.DTOs.Product;
using MediatR;

namespace Assesment.Application.Features.Product.Request.command;

public class ProductUpdateCommand:IRequest<Unit>
{
    public ProductUpdateDto ProductUpdateDto {get;set;}
}