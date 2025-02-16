using MediatR;
using Microwave.Application.UseCases.HeatingProgram.Commons;

namespace Microwave.Application.UseCases.HeatingProgram.GetHeatingProgram
{
    public class GetHeatingProgramRequest(Guid heatingProgramId) : IRequest<HeatingProgramResponse>
    {
        public Guid HeatingProgramId { get; } = heatingProgramId;
    }
}
