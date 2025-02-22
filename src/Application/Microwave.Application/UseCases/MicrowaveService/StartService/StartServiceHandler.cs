using Microwave.Application.Services;
using Microwave.Application.UseCases.MicrowaveService.Commons;
using Microwave.Domain.Entities;
using Microwave.Domain.Repositories;

namespace Microwave.Application.UseCases.MicrowaveService.StartService
{
    public class StartServiceHandler(
        IHeatingProgramRepository heatingProgramRepository,
        ICountdownBackgroundService countdownService) : IStartServiceHandler
    {
        public async Task<MicrowaveServiceResponse> Handle(StartServiceRequest request, CancellationToken cancellationToken)
        {
            if (request.HeatingProgramId != null)
            {
                await heatingProgramRepository.FindAsync(
                    (Guid)request.HeatingProgramId,
                    cancellationToken);
            }

            var heatingProgram = new HeatingProgramEntity();
            var microwaveService = new MicrowaveServiceEntity(heatingProgram);
            await countdownService.StartAsync(microwaveService, cancellationToken);
            return MicrowaveServiceResponse.FromEntity(microwaveService);
        }
    }
}
