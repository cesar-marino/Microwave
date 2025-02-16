namespace Microwave.Application.UseCases.HeatingProgram.SearchHeatingPrograms
{
    public class SearchHeatingProgramsResponse<TResponse>(IReadOnlyList<TResponse> items)
    {
        public IReadOnlyList<TResponse> Items { get; } = items;
    }
}
