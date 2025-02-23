using Microwave.Application.Services;
using Microwave.Application.UseCases.MicrowaveService.Commons;

namespace Microwave.Application.UseCases.MicrowaveService.ResumeServivce
{
    public class ResumeServiceHandler(ICountdownBackgroundService countdownService) : IResumeServiceHandler
    {
        public async Task<MicrowaveServiceResponse> Handle(ResumeServiceRequest request, CancellationToken cancellationToken)
        {
            var microwaveService = await countdownService.ResumeAsync(request.MicrowaveServiceId, cancellationToken);
            return MicrowaveServiceResponse.FromEntity(microwaveService);
        }
    }
}
