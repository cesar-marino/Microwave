using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Microwave.Application.UseCases.HeatingProgram.RemoveHeatingProgram
{
    public class RemoveHeatingProgramRequest(Guid heatingProgramId) : IRequest
    {
        public Guid HeatingProgramId { get; } = heatingProgramId;
    }
}
