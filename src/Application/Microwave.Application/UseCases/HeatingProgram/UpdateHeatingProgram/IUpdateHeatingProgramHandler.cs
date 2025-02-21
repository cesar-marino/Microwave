using MediatR;
using Microwave.Application.UseCases.HeatingProgram.Commons;

namespace Microwave.Application.UseCases.HeatingProgram.UpdateHeatingProgram
{
    public interface IUpdateHeatingProgramHandler : IRequestHandler<UpdateHeatingProgramRequest, HeatingProgramResponse>
    {
    }
}
