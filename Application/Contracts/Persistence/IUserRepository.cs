using Assesment.Domain.Entites;

namespace Assesment.Application.Contracts.Persistence;

public interface IUserRepository : IGenericRepository<User>
{
    public Task<bool> UsernameExists(string username);
    public Task<User> EmailExists(string email);
    public Task<User> GetByUsername(string username);

}
