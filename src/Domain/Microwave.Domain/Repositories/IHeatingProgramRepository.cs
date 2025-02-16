using Microwave.Domain.Entities;
using Microwave.Domain.SeedWork;

namespace Microwave.Domain.Repositories
{
    public interface IHeatingProgramRepository : IRepository<HeatingProgramEntity>
    {
        Task<IReadOnlyList<HeatingProgramEntity>> SearchAsync(
            string? name = null,
            string? food = null,
            CancellationToken cancellationToken = default);
    }
}
