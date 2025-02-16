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

        public MicrowaveContext(DbContextOptions<MicrowaveContext> options) : base(options) => InicializarDados();

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
            base.OnModelCreating(modelBuilder);
        }

        private void InicializarDados()
        {
            HeatingPrograms.AddRange(
                [new HeatingProgramEntity(
                    heatingProgramId: Guid.NewGuid(),
                    seconds: 180,
                    predefined: true,
                    power: 7,
                    name: "Pipoca",
                    food: "Pipoca (de micro-ondas)",
                    character: 'p',
                    instructions: "Observar o barulho de estouros do milho, caso houver um intervalo de mais de 10 segundos entre um estouro e outro, interrompa o aquecimento.")
                ,
                new HeatingProgramEntity(
                    heatingProgramId: Guid.NewGuid(),
                    seconds: 300,
                    predefined: true,
                    power: 5,
                    name: "Leite",
                    food: "Leite",
                    character: 'l',
                    instructions: "Cuidado com aquecimento de líquidos, o choque térmico aliado ao movimento do recipiente pode causar fervura imediata causando risco de queimaduras.")
                ,
                new HeatingProgramEntity(
                    heatingProgramId: Guid.NewGuid(),
                    seconds: 840,
                    predefined: true,
                    power: 4,
                    name: "Carnes de boi",
                    food: "Cane em pedaço ou fatias",
                    character: 'c',
                    instructions: "Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para o descongelamento uniforme.")
                ,
                new HeatingProgramEntity(
                    heatingProgramId: Guid.NewGuid(),
                    seconds: 480,
                    predefined: true,
                    power: 7,
                    name: "Frango",
                    food: "Frango (qualquer corte)",
                    character: 'f',
                    instructions: "Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para o descongelamento uniforme.")
                ,
                new HeatingProgramEntity(
                    heatingProgramId: Guid.NewGuid(),
                    seconds: 480,
                    predefined: true,
                    power: 9,
                    name: "Feijão",
                    food: "Feijão congelado",
                    character: 'e',
                    instructions: "Deixe o recipiente destampado e em casos de plástico, cuidado ao retirar o recipiente pois o mesmo pode perder resistência em altas temperaturas.")
                ]);

            SaveChanges();
        }
    }
}
