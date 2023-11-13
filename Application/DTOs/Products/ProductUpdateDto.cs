using Assesment.Application.DTOs.Common;

namespace Assesment.Application.DTOs.Products;


public class ProductUpdateDto : BaseDto
{

    public string Name {get;set;}
    public string Description {get;set;}
    public string Category {get;set;}
    public int Pricing {get;set;}
    public bool Availability {get;set;}
    
}