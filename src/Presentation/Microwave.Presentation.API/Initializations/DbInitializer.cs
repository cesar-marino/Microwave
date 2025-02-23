using Microsoft.EntityFrameworkCore;
using Microwave.Infrastructure.Data.Contexts;
using System;

namespace Microwave.Presentation.API.Initializations
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new MicrowaveContext(serviceProvider.GetRequiredService<DbContextOptions<MicrowaveContext>>());

            if (context.HeatingPrograms.Any())
                return;

            context.HeatingPrograms.AddRange(
                new(
                heatingProgramId: Guid.NewGuid(),
                predefined: true,
                seconds: 180,
                power: 7,
                character: 'a',
                name: "Pipoca",
                food: "Pipoca (de micro-ondas)",
                instructions: "Observar o barulho de estouros do milho, caso houver um intervalo de mais de 10 segundos entre um estouro e outro, interrompa o aquecimento."),
            new(
                heatingProgramId: Guid.NewGuid(),
                predefined: true,
                seconds: 300,
                power: 5,
                character: 'b',
                name: "Leite",
                food: "Leite",
                instructions: "Cuidado com aquecimento de líquidos, o choque térmico aliado ao movimento do recipiente pode causar fervura imediata causando risco de queimaduras."),
            new(
                heatingProgramId: Guid.NewGuid(),
                predefined: true,
                seconds: 840,
                power: 4,
                character: 'c',
                name: "Carne de boi",
                food: "Carne em pedaços ou fatias",
                instructions: "Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para o descongelamento uniforme."),
            new(
                heatingProgramId: Guid.NewGuid(),
                predefined: true,
                seconds: 480,
                power: 7,
                character: 'd',
                name: "Frango",
                food: "Frango qualquer corte",
                instructions: "Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para o descongelamento uniforme."),
            new(
                heatingProgramId: Guid.NewGuid(),
                predefined: true,
                seconds: 480,
                power: 9,
                character: 'e',
                name: "Feijão",
                food: "Feijão congelado",
                instructions: "Deixe o recipiente destampado e em casos de plástico, cuidado ao retirar o recipiente pois o mesmo pode perder resistência em altas temperaturas.")
            );

            context.SaveChanges();
        }
    }
}
