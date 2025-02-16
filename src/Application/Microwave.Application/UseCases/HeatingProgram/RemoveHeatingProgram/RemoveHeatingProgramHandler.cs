using Microwave.Application.UseCases.HeatingProgram.Commons;
using Microwave.Domain.Repositories;
using Microwave.Domain.SeedWork;

namespace Microwave.Application.UseCases.HeatingProgram.RemoveHeatingProgram
{
    public class RemoveHeatingProgramHandler(
        IHeatingProgramRepository heatingProgramRepository,
        IUnitOfWork unitOfWork) : IRemoveHeatingProgramHandler
    {
        public async Task Handle(RemoveHeatingProgramRequest request, CancellationToken cancellationToken)
        {
            await heatingProgramRepository.RemoveAsync(request.HeatingProgramId, cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);
            await Task.CompletedTask;
        }
    }
}
