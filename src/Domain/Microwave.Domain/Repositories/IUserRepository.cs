using Microwave.Domain.Entities;
using Microwave.Domain.SeedWork;

namespace Microwave.Domain.Repositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<bool> CheckUsernameAsync(string username, CancellationToken cancellationToken = default);
    }
}
