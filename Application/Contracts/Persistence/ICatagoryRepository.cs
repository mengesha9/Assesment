using Assesment.Application.Contracts.Persistence;
using Assesment.Domain.Entites;

namespace Assesment.Application.Contracts.Persistence;

public interface ICatagoryRepository : IGenericRepository<Category> 
{
        Task<Category>  GetNameAsync(string name);
       
          
}