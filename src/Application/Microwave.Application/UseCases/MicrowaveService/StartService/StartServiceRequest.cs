using MediatR;
using Microwave.Application.UseCases.MicrowaveService.Commons;
using System.ComponentModel.DataAnnotations;

namespace Microwave.Application.UseCases.MicrowaveService.StartService
{
    public class StartServiceRequest(
        Guid? heatingProgramId,
        int? seconds,
        int? power) : IRequest<MicrowaveServiceResponse>
    {
        [Required]
        public Guid? HeatingProgramId { get; } = heatingProgramId;

        [Required]
        [MinLength(1)]
        [MaxLength(120)]
        public int? Seconds { get; } = seconds;

        [Required]
        [MinLength(1)]
        [MaxLength(10)]
        public int? Power { get; } = power;
    }
}
