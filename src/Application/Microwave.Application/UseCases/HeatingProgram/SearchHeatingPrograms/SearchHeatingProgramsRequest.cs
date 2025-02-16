using MediatR;
using Microwave.Application.UseCases.HeatingProgram.Commons;

namespace Microwave.Application.UseCases.HeatingProgram.SearchHeatingPrograms
{
    public class SearchHeatingProgramsRequest(
        string? name,
        string? food) : IRequest<SearchHeatingProgramsResponse<HeatingProgramResponse>>
    {
        public string? Name { get; } = name;
        public string? Food { get; } = food;
    }
}
