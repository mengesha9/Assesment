using Assesment.Domain.Common;

namespace Assesment.Domain.Entites;

public class Category : BaseDomainEntity
{
    public string Name {get;set;}
    public string Description {get;set;}
    public ICollection<Product> Products { get; set; }

}

