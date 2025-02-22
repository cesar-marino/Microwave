using Microsoft.EntityFrameworkCore;
using Microwave.Domain.Entities;
using Microwave.Domain.Exceptions;
using Microwave.Domain.SeedWork;
using Microwave.Infrastructure.Data.Configurations;

namespace Microwave.Infrastructure.Data.Contexts
{
    public class MicrowaveContext : DbContext, IUnitOfWork
    {
        public DbSet<HeatingProgramEntity> HeatingPrograms { get; private set; }
        public DbSet<UserEntity> Users { get; private set; }

        public MicrowaveContext(DbContextOptions<MicrowaveContext> options) : base(options)
        {
            //start predefined programs
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new UnexpectedException(innerException: ex);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HeatingProgramConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
