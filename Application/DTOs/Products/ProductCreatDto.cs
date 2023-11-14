
using Assesment.Application.DTOs.Catagory;

namespace Assesment.Application.DTOs.Products;


public class ProductCreateDto
{

    public string Name {get;set;}
    public string Description {get;set;}
    public string CategoryName {get;set;}
    public int Pricing {get;set;}
    public int Availability {get;set;}
    
}