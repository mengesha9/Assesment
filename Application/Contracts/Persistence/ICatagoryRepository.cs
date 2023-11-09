using Assesment.Application.Contracts.Persistence;
using Assesment.Domain.Entites;

namespace Assesment.Application.Contracts.Persistence;

public interface ICatagoryRepository : IGenericRepository<Catagory> 
{
        Task<Catagory> GetNameAsync(string name);

    
}