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
            HeatingProgramEntity heatingProgram;
            if (request.HeatingProgramId != null)
            {
                heatingProgram = await heatingProgramRepository.FindAsync(
                    (Guid)request.HeatingProgramId,
                    cancellationToken);
            }
            else
            {
                heatingProgram = new HeatingProgramEntity(seconds: request.Seconds ?? 30, power: request.Power ?? 10);
            }

            var microwaveService = new MicrowaveServiceEntity(heatingProgram);
            await countdownService.StartAsync(microwaveService, cancellationToken);
            return MicrowaveServiceResponse.FromEntity(microwaveService);
        }
    }
}
