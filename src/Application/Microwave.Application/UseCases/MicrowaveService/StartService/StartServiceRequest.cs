using MediatR;
using Microwave.Application.UseCases.MicrowaveService.Commons;

namespace Microwave.Application.UseCases.MicrowaveService.StartService
{
    public class StartServiceRequest(
        Guid heatingProgramId,
        int seconds,
        int power) : IRequest<MicrowaveServiceResponse>
    {
        public Guid HeatingProgramId { get; } = heatingProgramId;
        public int Seconds { get; } = seconds;
        public int Power { get; } = power;
    }
}
