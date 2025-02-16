using Microwave.Application.UseCases.HeatingProgram.Commons;
using Microwave.Domain.Repositories;

namespace Microwave.Application.UseCases.HeatingProgram.GetHeatingProgram
{
    public class GetHeatingProgramHandler(IHeatingProgramRepository heatingProgramRepository) : IGetHeatingProgramHandler
    {
        public async Task<HeatingProgramResponse> Handle(GetHeatingProgramRequest request, CancellationToken cancellationToken)
        {
            var heatingProgram = await heatingProgramRepository.FindAsync(id: request.HeatingProgramId, cancellationToken);
            return HeatingProgramResponse.FromEntity(heatingProgram);
        }
    }
}
