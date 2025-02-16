using MediatR;
using Microwave.Application.UseCases.HeatingProgram.Commons;

namespace Microwave.Application.UseCases.HeatingProgram.GetHeatingProgram
{
    public interface IGetHeatingProgramHandler : IRequestHandler<GetHeatingProgramRequest, HeatingProgramResponse>
    {
    }
}
