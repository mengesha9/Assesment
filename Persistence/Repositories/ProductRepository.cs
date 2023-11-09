

using Assesment.Application.Contracts.Persistence;
using Assesment.Domain.Entites;

namespace Assesment.Persistence.Repositoties;
public class ProductRespository : GenericRespositoty<Product>, IProductRepository
{
    private readonly AssesmentApiDbContext _context;
    public ProductRespository(AssesmentApiDbContext context) :base(context)
    {
        _context =context;
    }
}