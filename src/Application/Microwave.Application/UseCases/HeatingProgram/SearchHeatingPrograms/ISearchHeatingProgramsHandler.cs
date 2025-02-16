using MediatR;
using Microwave.Application.UseCases.HeatingProgram.Commons;

namespace Microwave.Application.UseCases.HeatingProgram.SearchHeatingPrograms
{
    public interface ISearchHeatingProgramsHandler : 
        IRequestHandler<SearchHeatingProgramsRequest, SearchHeatingProgramsResponse<HeatingProgramResponse>>
    {
    }
}
