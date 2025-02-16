using Microwave.Application.UseCases.HeatingProgram.Commons;
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
            heatingProgram.Update(
                name: request.Name,
                food: request.Food,
                instructions: request.Instructions,
                character: request.Character,
                seconds: request.Seconds,
                power: request.Power);

            await heatingProgramRepository.UpdateAsync(heatingProgram, cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);
            return HeatingProgramResponse.FromEntity(heatingProgram);
        }
    }
}
