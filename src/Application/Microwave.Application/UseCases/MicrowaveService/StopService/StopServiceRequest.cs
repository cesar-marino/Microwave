using MediatR;
using Microwave.Application.UseCases.MicrowaveService.Commons;

namespace Microwave.Application.UseCases.MicrowaveService.StopService
{
    public class StopServiceRequest(Guid microwaveServiceId) : IRequest<MicrowaveServiceResponse>
    {
        public Guid MicrowaveServiceId { get; } = microwaveServiceId;
    }
}
