using Microwave.Application.UseCases.MicrowaveService.Commons;
using Microwave.Domain.Repositories;

namespace Microwave.Application.UseCases.MicrowaveService.StartService
{
    public class StartServiceHandler(IHeatingProgramRepository heatingProgramRepository) : IStartServiceHandler
    {
        public async Task<MicrowaveServiceResponse> Handle(StartServiceRequest request, CancellationToken cancellationToken)
        {
            if (request.HeatingProgramId != null)
            {
                await heatingProgramRepository.FindAsync(
                    (Guid)request.HeatingProgramId,
                    cancellationToken);
            }

            throw new NotImplementedException();
        }
    }
}
