

using Assesment.Application.DTOs.Product;
using MediatR;

namespace Assesment.Application.Features.Product.Request.command;
public class ProductCreateCommand:IRequest<Unit>
{
    public ProductCreateDto ProductCreateDto{get;set;}


}