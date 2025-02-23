using Microwave.Application.Services;
using Microwave.Application.UseCases.MicrowaveService.Commons;

namespace Microwave.Application.UseCases.MicrowaveService.ResumeServivce
{
    public class ResumeServiceHandler(ICountdownBackgroundService countdownService) : IResumeServiceHandler
    {
        public async Task<MicrowaveServiceResponse> Handle(ResumeServiceRequest request, CancellationToken cancellationToken)
        {
            await countdownService.ResumeAsync(request.MicrowaveServiceId, cancellationToken);
            throw new NotImplementedException();
        }
    }
}
