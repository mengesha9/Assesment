

using Assesment.Application.Contracts.Persistence;
using Assesment.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Assesment.Persistence.Repositoties;
public class ProductRespository : GenericRespositoty<Product>, IProductRepository
{
    private readonly AssesmentApiDbContext _context;
    public ProductRespository(AssesmentApiDbContext context) :base(context)
    {
        _context =context;
    }



    public async Task<List<Product>> GetByName(string name)
    {
        var products = new List<Product>();

        await foreach (var product in _context.Products)
        {
            if (product.Name == name)
            {
                products.Add(product);
            }
        }

        return products; 
    }
    public async Task<List<Product>> GetByCategoryName(string name)
    {
        var products = new List<Product>();

        await foreach (var product in _context.Products)
        {
            if (product.CategoryName == name)
            {
                products.Add(product);
            }
        }

        return products;

    }

    public async Task<Product> Book(int id, int Quantity)
    {
        var entity = await _context.Set<Product>().FindAsync(id);
        if(entity != null && entity.Availability >= Quantity ){
            entity.Availability -= Quantity;
           await _context.SaveChangesAsync();
        }

        return entity;

    }
}