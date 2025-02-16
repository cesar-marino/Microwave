using MediatR;
using Microwave.Application.UseCases.MicrowaveService.Commons;

namespace Microwave.Application.UseCases.MicrowaveService.StartService
{
    public class StartServiceRequest(
        int? seconds,
        int? power) : IRequest<MicrowaveServiceResponse>
    {
        public int? Seconds { get; } = seconds;
        public int? Power { get; } = power;
    }
}
