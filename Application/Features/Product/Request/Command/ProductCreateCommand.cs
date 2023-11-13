

using Assesment.Application.DTOs.Products;
using MediatR;

namespace Assesment.Application.Features.Products.Request.command;
public class ProductCreateCommand:IRequest<Unit>
{
    public ProductDto ProductDto{get;set;}


}