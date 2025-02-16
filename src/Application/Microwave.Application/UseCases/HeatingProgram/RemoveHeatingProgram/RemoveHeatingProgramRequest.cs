using MediatR;
using Microwave.Application.UseCases.HeatingProgram.Commons;

namespace Microwave.Application.UseCases.HeatingProgram.RemoveHeatingProgram
{
    public class RemoveHeatingProgramRequest(Guid heatingProgramId) : IRequest
    {
        public Guid HeatingProgramId { get; } = heatingProgramId;
    }
}
