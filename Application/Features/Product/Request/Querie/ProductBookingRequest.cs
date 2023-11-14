

using Assesment.Application.DTOs.Products;
using MediatR;

namespace Assesment.Application.Features.Product.Request.Querie;
public class ProductBookingRequest:IRequest<ProductDto>
{

    public int Quantity {get;set;}
    public int Id {get;set;}

}