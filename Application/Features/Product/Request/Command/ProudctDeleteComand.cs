using Assesment.Application.DTOs.Products;
using MediatR;

namespace Assesment.Application.Features.Product.Request.command;

public class ProductDeleteCommand: IRequest<Unit>
{
    public ProductDeleteDto ProductDeleteDto {get;set;}
}