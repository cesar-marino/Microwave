using Microwave.Application.UseCases.HeatingProgram.Commons;
using Microwave.Domain.Repositories;

namespace Microwave.Application.UseCases.HeatingProgram.GetListHeatingPrograms
{
    public class GetListHeatingProgramsHandler(IHeatingProgramRepository heatingProgramRepository) : IGetListHeatingProgramsHandler
    {
        public async Task<List<HeatingProgramResponse>> Handle(GetListHeatingProgramsRequest request, CancellationToken cancellationToken)
        {
            await heatingProgramRepository.GetAllAsync(cancellationToken);

            throw new NotImplementedException();
        }
    }
}
