using MediatR;
using Microwave.Application.UseCases.HeatingProgram.Commons;

namespace Microwave.Application.UseCases.HeatingProgram.RemoveHeatingProgram
{
    public interface IRemoveHeatingProgramHandler : IRequestHandler<RemoveHeatingProgramRequest>
    {
    }
}
