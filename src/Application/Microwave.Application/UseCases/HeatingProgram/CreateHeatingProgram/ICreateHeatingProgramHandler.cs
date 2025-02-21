using MediatR;
using Microwave.Application.UseCases.HeatingProgram.Commons;

namespace Microwave.Application.UseCases.HeatingProgram.CreateHeatingProgram
{
    public interface ICreateHeatingProgramHandler : IRequestHandler<CreateHeatingProgramRequest, HeatingProgramResponse>
    {
    }
}
