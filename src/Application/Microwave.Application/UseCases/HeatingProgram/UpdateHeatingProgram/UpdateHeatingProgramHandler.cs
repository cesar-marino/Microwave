using Microwave.Application.UseCases.HeatingProgram.Commons;
using Microwave.Domain.Exceptions;
using Microwave.Domain.Repositories;

namespace Microwave.Application.UseCases.HeatingProgram.UpdateHeatingProgram
{
    public class UpdateHeatingProgramHandler(IHeatingProgramRepository heatingProgramRepository) : IUpdateHeatingProgramHandler
    {
        public async Task<HeatingProgramResponse> Handle(UpdateHeatingProgramRequest request, CancellationToken cancellationToken)
        {
            var heatingProgram = await heatingProgramRepository.FindAsync(request.HeatingProgramId, cancellationToken);
            if (heatingProgram.Predefined)
                throw new ActionNotPermittedException("Não é permitido alterar um programa predefinido");

            throw new NotImplementedException();
        }
    }
}
