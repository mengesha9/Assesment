using Assesment.Domain.Common;
using Assesment.Domain.Entites;
namespace Assesment.Domain.Entites;

public class  Product : BaseDomainEntity
{
    public string Name {get;set;}
    public string Description {get;set;}
    public string Catagory {get;set;}
    public int Pricing {get;set;}
    public bool Availability {get;set;}

    public int UserId { get; set; }
    public User User { get; set; }

    public Catagory Category  {get;set;}
    public int CategoryId {get;set;}


}
