using Microwave.Application.UseCases.HeatingProgram.Commons;
using Microwave.Domain.Entities;
using Microwave.Domain.Repositories;
using Microwave.Domain.SeedWork;

namespace Microwave.Application.UseCases.HeatingProgram.CreateHeatingProgram
{
    public class CreateHeatingProgramHandler(
        IHeatingProgramRepository heatingProgramRepository,
        IUnitOfWork unitOfWork) : ICreateHeatingProgramHandler
    {
        public async Task<HeatingProgramResponse> Handle(CreateHeatingProgramReequest request, CancellationToken cancellationToken)
        {
            var heatingProgram = new HeatingProgramEntity(
                seconds: request.Seconds,
                power: request.Power,
                name: request.Name,
                food: request.Food,
                character: request.Character,
                instructions: request.Instructions);

            await heatingProgramRepository.InsertAsync(heatingProgram, cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);
            return HeatingProgramResponse.FromEntity(heatingProgram);
        }
    }
}
