using Microwave.Application.UseCases.HeatingProgram.Commons;
using Microwave.Domain.Entities;
using Microwave.Domain.Exceptions;
using Microwave.Domain.Repositories;

namespace Microwave.Application.UseCases.HeatingProgram.CreateHeatingProgram
{
    public class CreateHeatingProgramHandler(IHeatingProgramRepository heatingProgramRepository) : ICreateHeatingProgramHandler
    {
        public async Task<HeatingProgramResponse> Handle(CreateHeatingProgramRequest request, CancellationToken cancellationToken)
        {
            var characterInUse = await heatingProgramRepository.CheckCharacterAsync(request.Character, cancellationToken);
            if (characterInUse)
                throw new ActionNotPermittedException(message: "Caractere de aquecimento em uso");

            var heatingProgram = new HeatingProgramEntity(
                seconds: request.Seconds,
                power: request.Power,
                character: request.Character,
                name: request.Name,
                food: request.Food,
                instructions: request.Instructions);

            await heatingProgramRepository.InsertAsync(heatingProgram, cancellationToken);
            throw new NotImplementedException();
        }
    }
}
