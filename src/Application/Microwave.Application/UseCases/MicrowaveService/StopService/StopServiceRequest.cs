using MediatR;
using Microwave.Application.UseCases.MicrowaveService.Commons;
using System.ComponentModel.DataAnnotations;

namespace Microwave.Application.UseCases.MicrowaveService.StopService
{
    public class StopServiceRequest(Guid microwaveServiceId) : IRequest<MicrowaveServiceResponse>
    {
        [Required]
        public Guid MicrowaveServiceId { get; } = microwaveServiceId;
    }
}
