using Assesment.Domain.Common;

namespace Assesment.Domain.Entites;

public class User : BaseDomainEntity

{

  public string Name {get;set;}
  public string Email {get;set;}
  public string Password {get;set;}
  public string Role { get; set; }

  public ICollection<Product> Products { get; set; }

    
}