using Microsoft.EntityFrameworkCore;
using Microwave.Domain.Entities;
using Microwave.Domain.Exceptions;
using Microwave.Domain.Repositories;
using Microwave.Infrastructure.Data.Contexts;

namespace Microwave.Infrastructure.Data.Repositories
{
    public class UserRepository(MicrowaveContext context) : IUserRepository
    {
        public async Task<bool> CheckUsernameAsync(
            string username,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.Username == username, cancellationToken);
                return user != null;
            }
            catch (Exception ex)
            {
                throw new UnexpectedException(innerException: ex);
            }
        }

        public async Task<UserEntity> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
                return user ?? throw new NotFoundException("Usuário não encontrado");
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

        public async Task<UserEntity> FindByUsernameAsync(string username, CancellationToken cancellationToken = default)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.Username == username, cancellationToken);
                return user ?? throw new NotFoundException("Usuário não encontrado");
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

        public async Task InsertAsync(UserEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                await context.Users.AddAsync(entity, cancellationToken);
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
                var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
                    ?? throw new NotFoundException("Usuário não encontrado");

                context.Users.Remove(user);
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

        public async Task UpdateAsync(UserEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.Id == entity.Id, cancellationToken: cancellationToken)
                    ?? throw new NotFoundException("Usuário não encontrado");

                context.Entry(user).CurrentValues.SetValues(entity);
                context.Users.Entry(user).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw new UnexpectedException(innerException: ex);
            }
        }
    }
}
