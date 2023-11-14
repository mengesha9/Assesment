using Assesment.Application.DTOs.Common;

namespace Assesment.Application.DTOs.Products;


public class ProductUpdateDto : BaseDto
{

    public string Name {get;set;}
    public string Description {get;set;}
    public string CategoryName {get;set;}
    public int Pricing {get;set;}
    public int Availability {get;set;}
    
}