using Assesment.Domain.Entites;

namespace Assesment.Application.Contracts.Persistence;

public interface IUserRepository : IGenericRepository<User>
{
    public Task<bool> UsernameExists(string name);
    public Task<bool> EmailExists(string email);
    public Task<User> GetByEmail(string email);
    public Task<User> GetByUsername(string name);

}
