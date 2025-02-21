using Microwave.Domain.Exceptions;
using Microwave.Domain.Repositories;

namespace Microwave.Application.UseCases.HeatingProgram.RemoveHeatingProgram
{
    public class RemoveHeatingProgramHandler(IHeatingProgramRepository heatingProgramRepository) : IRemoveHeatingProgramHandler
    {
        public async Task Handle(RemoveHeatingProgramRequest request, CancellationToken cancellationToken)
        {
            var heatingProgram = await heatingProgramRepository.FindAsync(request.HeatingProgramId, cancellationToken);
            if (heatingProgram.Predefined)
                throw new ActionNotPermittedException(message: "Não é permitido excluir um programa predefinido");

            throw new NotImplementedException();
        }
    }
}
