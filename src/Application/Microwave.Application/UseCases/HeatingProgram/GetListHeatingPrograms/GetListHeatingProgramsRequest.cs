using MediatR;
using Microwave.Application.UseCases.HeatingProgram.Commons;

namespace Microwave.Application.UseCases.HeatingProgram.GetListHeatingPrograms
{
    public class GetListHeatingProgramsRequest : IRequest<List<HeatingProgramResponse>>
    {
    }
}
