
using Assesment.Application.DTOs.Catagory;

namespace Assesment.Application.DTOs.Product;


public class ProductCreateDto
{

    public string Name {get;set;}
    public string Description {get;set;}
    public CatagoryDto Category {get;set;}
    public int Pricing {get;set;}
    public bool Availability {get;set;}
    
}