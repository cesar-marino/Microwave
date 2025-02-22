using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microwave.Domain.Entities;

namespace Microwave.Infrastructure.Data.Configurations
{
    public class HeatingProgramConfiguration : IEntityTypeConfiguration<HeatingProgramEntity>
    {
        public void Configure(EntityTypeBuilder<HeatingProgramEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(x => x.Predefined)
                .IsRequired();

            builder.Property(x => x.Seconds)
                .IsRequired();

            builder.Property(x => x.Power)
                .IsRequired();

            builder.Property(x => x.Character)
                .IsRequired();

            builder.Property(x => x.Instructions)
                .ValueGeneratedNever();
        }
    }
}
