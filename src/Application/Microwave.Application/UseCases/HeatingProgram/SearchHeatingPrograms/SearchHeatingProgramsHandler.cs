using Microwave.Application.UseCases.HeatingProgram.Commons;
using Microwave.Domain.Repositories;

namespace Microwave.Application.UseCases.HeatingProgram.SearchHeatingPrograms
{
    public class SearchHeatingProgramsHandler(IHeatingProgramRepository heatingProgramRepository) : ISearchHeatingProgramsHandler
    {
        public async Task<SearchHeatingProgramsResponse<HeatingProgramResponse>> Handle(
            SearchHeatingProgramsRequest request,
            CancellationToken cancellationToken)
        {
            var heatingPrograms = await heatingProgramRepository.SearchAsync(
                  name: request.Name,
                  food: request.Food,
                  cancellationToken);

            return new(items: [.. heatingPrograms.Select(HeatingProgramResponse.FromEntity)]);
        }
    }
}
