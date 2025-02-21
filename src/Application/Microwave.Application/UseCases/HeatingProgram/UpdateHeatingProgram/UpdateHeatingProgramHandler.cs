using Microwave.Application.UseCases.HeatingProgram.Commons;

namespace Microwave.Application.UseCases.HeatingProgram.UpdateHeatingProgram
{
    public class UpdateHeatingProgramHandler : IUpdateHeatingProgramHandler
    {
        public Task<HeatingProgramResponse> Handle(UpdateHeatingProgramRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
