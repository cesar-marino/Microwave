using Microsoft.EntityFrameworkCore;
using Microwave.Domain.Entities;
using Microwave.Infrastructure.Data.Configurations;

namespace Microwave.Infrastructure.Data.Contexts
{
    public class MicrowaveContext(DbContextOptions<MicrowaveContext> options) : DbContext(options)
    {
        public DbSet<HeatingProgramEntity> HeatingPrograms { get; private set; }
        public DbSet<UserEntity> Users { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HeatingProgramConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
