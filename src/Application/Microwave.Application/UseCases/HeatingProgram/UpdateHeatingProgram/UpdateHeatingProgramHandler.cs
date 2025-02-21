using Microwave.Application.UseCases.HeatingProgram.Commons;
using Microwave.Domain.Exceptions;
using Microwave.Domain.Repositories;
using Microwave.Domain.SeedWork;

namespace Microwave.Application.UseCases.HeatingProgram.UpdateHeatingProgram
{
    public class UpdateHeatingProgramHandler(
        IHeatingProgramRepository heatingProgramRepository,
        IUnitOfWork unitOfWork) : IUpdateHeatingProgramHandler
    {
        public async Task<HeatingProgramResponse> Handle(UpdateHeatingProgramRequest request, CancellationToken cancellationToken)
        {
            var heatingProgram = await heatingProgramRepository.FindAsync(request.HeatingProgramId, cancellationToken);
            if (heatingProgram.Predefined)
                throw new ActionNotPermittedException("Não é permitido alterar um programa predefinido");

            heatingProgram.Update(
                seconds: request.Seconds,
                power: request.Power,
                character: request.Character,
                name: request.Name,
                food: request.Food,
                instructions: request.Instructions);

            await heatingProgramRepository.UpdateAsync(heatingProgram, cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);
            return HeatingProgramResponse.FromEntity(heatingProgram);
        }
    }
}
