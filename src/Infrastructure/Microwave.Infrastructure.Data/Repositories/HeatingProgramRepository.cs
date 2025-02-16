using Microsoft.EntityFrameworkCore;
using Microwave.Domain.Entities;
using Microwave.Domain.Exceptions;
using Microwave.Domain.Repositories;
using Microwave.Infrastructure.Data.Contexts;

namespace Microwave.Infrastructure.Data.Repositories
{
    public class HeatingProgramRepository(MicrowaveContext context) : IHeatingProgramRepository
    {
        public async Task<HeatingProgramEntity> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                var heatingProgram = await context.HeatingPrograms
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

                return heatingProgram ?? throw new NotFoundException();
            }
            catch (DomainException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new UnexpectedException(innerException: ex);
            }
        }

        public async Task InsertAsync(HeatingProgramEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                await context.HeatingPrograms.AddAsync(entity, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new UnexpectedException(innerException: ex);
            }
        }

        public async Task RemoveAsync(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                var heatingProgram = await context.HeatingPrograms.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

                if (heatingProgram != null)
                    _ = context.HeatingPrograms.Remove(heatingProgram);
            }
            catch (Exception ex)
            {
                throw new UnexpectedException(innerException: ex);
            }
        }

        public async Task<IReadOnlyList<HeatingProgramEntity>> SearchAsync(string? name = null, string? food = null, CancellationToken cancellationToken = default)
        {
            try
            {
                var query = context.HeatingPrograms.AsNoTracking();

                if (name != null)
                    query = query.Where(x => x.Name.ToLower().Trim().Contains(name.Trim().ToLower(), StringComparison.CurrentCultureIgnoreCase));

                if (food != null)
                    query = query.Where(x => x.Food.ToLower().Trim().Contains(food.Trim().ToLower(), StringComparison.CurrentCultureIgnoreCase));

                return await query.ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new UnexpectedException(innerException: ex);
            }
        }

        public async Task UpdateAsync(HeatingProgramEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                context.HeatingPrograms.Entry(entity).State = EntityState.Modified;
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new UnexpectedException(innerException: ex);
            }
        }
    }
}
