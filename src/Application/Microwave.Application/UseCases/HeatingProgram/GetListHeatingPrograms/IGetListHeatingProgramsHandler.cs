using MediatR;
using Microwave.Application.UseCases.HeatingProgram.Commons;

namespace Microwave.Application.UseCases.HeatingProgram.GetListHeatingPrograms
{
    public interface IGetListHeatingProgramsHandler : IRequestHandler<GetListHeatingProgramsRequest, List<HeatingProgramResponse>>
    {
    }
}
