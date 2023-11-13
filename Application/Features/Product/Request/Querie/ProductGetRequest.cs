

using Assesment.Application.DTOs.Products;
using MediatR;

namespace Assesment.Application.Features.Product.Request.Querie;
public class ProductGetRequest:IRequest<ProductDto>
{
    public int Id {get;set;}
    
}