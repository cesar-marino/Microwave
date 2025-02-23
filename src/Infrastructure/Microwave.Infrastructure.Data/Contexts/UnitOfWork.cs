using Microwave.Domain.Exceptions;
using Microwave.Domain.SeedWork;

namespace Microwave.Infrastructure.Data.Contexts
{
    public class UnitOfWork(MicrowaveContext context) : IUnitOfWork
    {
        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new UnexpectedException(innerException: ex);
            }
        }
    }
}
