using Microwave.Application.UseCases.HeatingProgram.Commons;

namespace Microwave.Application.UseCases.HeatingProgram.CreateHeatingProgram
{
    public class CreateHeatingProgramHandler : ICreateHeatingProgramHandler
    {
        public Task<HeatingProgramResponse> Handle(CreateHeatingProgramRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
