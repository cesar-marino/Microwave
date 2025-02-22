using Microsoft.EntityFrameworkCore;
using Microwave.Domain.Entities;
using Microwave.Domain.Exceptions;
using Microwave.Domain.Repositories;
using Microwave.Infrastructure.Data.Contexts;

namespace Microwave.Infrastructure.Data.Repositories
{
    public class HeatingProgramRepository(MicrowaveContext context) : IHeatingProgramRepository
    {
        public async Task<bool> CheckCharacterAsync(char character, CancellationToken cancellationToken = default)
        {
            try
            {
                var heatinProgram = await context.HeatingPrograms.FirstOrDefaultAsync(x => x.Character == character, cancellationToken);
                return heatinProgram != null;
            }
            catch (Exception ex)
            {
                throw new UnexpectedException(innerException: ex);
            }
        }

        public async Task<HeatingProgramEntity> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                var heatingProgram = await context.HeatingPrograms.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
                return heatingProgram ?? throw new NotFoundException("Programa não encontrado");
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

        public async Task<List<HeatingProgramEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await context.HeatingPrograms.ToListAsync(cancellationToken);
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
                var heatingProgram = await context.HeatingPrograms.FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
                    ?? throw new NotFoundException("Programa não encontrado");

                context.HeatingPrograms.Remove(heatingProgram);
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

        public async Task UpdateAsync(HeatingProgramEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                var heatingProgram = await context.HeatingPrograms.FirstOrDefaultAsync(x => x.Id == entity.Id, cancellationToken)
                    ?? throw new NotFoundException("Programa não encontrado");

                context.Entry(heatingProgram).CurrentValues.SetValues(entity);
                context.HeatingPrograms.Entry(heatingProgram).State = EntityState.Modified;
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
    }
}
