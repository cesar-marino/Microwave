using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Microwave.Application.UseCases.HeatingProgram.RemoveHeatingProgram
{
    public class RemoveHeatingProgramRequest(Guid heatingProgramId) : IRequest
    {
        [Required]
        public Guid HeatingProgramId { get; } = heatingProgramId;
    }
}
