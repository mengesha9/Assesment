using Assesment.Domain.Entites;

namespace Assesment.Application.Contracts.Infrastructure;

public interface IJwtGenerator
{
    public string Generate(User user);
}
