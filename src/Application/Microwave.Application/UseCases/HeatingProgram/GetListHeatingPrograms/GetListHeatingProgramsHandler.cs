using Microwave.Application.UseCases.HeatingProgram.Commons;

namespace Microwave.Application.UseCases.HeatingProgram.GetListHeatingPrograms
{
    public class GetListHeatingProgramsHandler : IGetListHeatingProgramsHandler
    {
        public Task<List<HeatingProgramResponse>> Handle(GetListHeatingProgramsRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
