using MediatR;
using Microwave.Application.UseCases.MicrowaveService.Commons;
using System.ComponentModel.DataAnnotations;

namespace Microwave.Application.UseCases.MicrowaveService.ResumeServivce
{
    public class ResumeServiceRequest(Guid microwaveServiceId) : IRequest<MicrowaveServiceResponse>
    {
        [Required]
        public Guid MicrowaveServiceId { get; } = microwaveServiceId;
    }
}
