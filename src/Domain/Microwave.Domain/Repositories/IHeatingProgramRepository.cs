using Microwave.Domain.Entities;
using Microwave.Domain.SeedWork;

namespace Microwave.Domain.Repositories
{
    public interface IHeatingProgramRepository : IRepository<HeatingProgramEntity>
    {
        Task<bool> CheckCharacterAsync(char character, CancellationToken cancellationToken = default);
    }
}
