

using Assesment.Application.DTOs.Products;
using MediatR;

namespace Assesment.Application.Features.Product.Request.Querie;
public class SearchProductRequest:IRequest<List<ProductDto>>
{
    public string Name {get;set;}
    
}