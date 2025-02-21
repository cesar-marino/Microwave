using Microwave.Application.UseCases.HeatingProgram.Commons;
using Microwave.Domain.Repositories;

namespace Microwave.Application.UseCases.HeatingProgram.CreateHeatingProgram
{
    public class CreateHeatingProgramHandler(IHeatingProgramRepository heatingProgramRepository) : ICreateHeatingProgramHandler
    {
        public async Task<HeatingProgramResponse> Handle(CreateHeatingProgramRequest request, CancellationToken cancellationToken)
        {
            await heatingProgramRepository.CheckCharacterAsync(request.Character, cancellationToken);

            throw new NotImplementedException();
        }
    }
}
