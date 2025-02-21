using Microwave.Domain.Repositories;

namespace Microwave.Application.UseCases.HeatingProgram.RemoveHeatingProgram
{
    public class RemoveHeatingProgramHandler(IHeatingProgramRepository heatingProgramRepository) : IRemoveHeatingProgramHandler
    {
        public async Task Handle(RemoveHeatingProgramRequest request, CancellationToken cancellationToken)
        {
            await heatingProgramRepository.FindAsync(request.HeatingProgramId, cancellationToken);
            throw new NotImplementedException();
        }
    }
}
