using Microwave.Application.Services;
using Microwave.Application.UseCases.MicrowaveService.Commons;
using Microwave.Domain.Entities;

namespace Microwave.Application.UseCases.MicrowaveService.StartService
{
    public class StartServiceHandler(ICountdownBackgroundService counterdownService) : IStartServiceHandler
    {
        public async Task<MicrowaveServiceResponse> Handle(StartServiceRequest request, CancellationToken cancellationToken)
        {
            var heatingProgram = new HeatingProgramEntity(
                seconds: request.Seconds,
                power: request.Power);

            var microwaveService = new MicrowaveServiceEntity(heatingProgram);
            await counterdownService.StartAsync(microwaveService, cancellationToken);

            return MicrowaveServiceResponse.FromEntity(
                microwaveService: microwaveService,
                heatingProgram: heatingProgram);
        }
    }
}
