using Microwave.Domain.Exceptions;
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
            var heatingProgram = await heatingProgramRepository.FindAsync(request.HeatingProgramId, cancellationToken);
            if (heatingProgram.Predefined)
                throw new ActionNotPermittedException(message: "Não é permitido excluir um programa predefinido");

            await heatingProgramRepository.RemoveAsync(heatingProgram.Id, cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);

            throw new NotImplementedException();
        }
    }
}
