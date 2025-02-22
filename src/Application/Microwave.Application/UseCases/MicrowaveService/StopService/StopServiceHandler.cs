using Microwave.Application.Services;
using Microwave.Application.UseCases.MicrowaveService.Commons;

namespace Microwave.Application.UseCases.MicrowaveService.StopService
{
    public class StopServiceHandler(ICountdownBackgroundService countdownService) : IStopServiceHandler
    {
        public async Task<MicrowaveServiceResponse> Handle(StopServiceRequest request, CancellationToken cancellationToken)
        {
            var microwaveService = await countdownService.StopAsync(request.MicrowaveServiceId, cancellationToken);
            return MicrowaveServiceResponse.FromEntity(microwaveService);
        }
    }
}
