using MediatR;
using Microwave.Application.UseCases.MicrowaveService.Commons;

namespace Microwave.Application.UseCases.MicrowaveService.ResumeServivce
{
    public class ResumeServiceRequest(Guid microwaveServiceId) : IRequest<MicrowaveServiceResponse>
    {
        public Guid MicrowaveServiceId { get; } = microwaveServiceId;
    }
}
