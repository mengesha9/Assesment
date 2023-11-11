using Assesment.Domain.Entites;

namespace Assesment.Application.Contracts.Persistence;

public interface IProductRepository : IGenericRepository<Product>
{

    Task<List<Product>> GetByName (string name);
    Task<List<Product>> GetByCategoryName(string category);
    Task<Product> Book(int id , int Quantity);
    
}