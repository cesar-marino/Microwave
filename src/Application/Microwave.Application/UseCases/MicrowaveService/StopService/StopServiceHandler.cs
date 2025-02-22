using Microwave.Application.UseCases.MicrowaveService.Commons;

namespace Microwave.Application.UseCases.MicrowaveService.StopService
{
    public class StopServiceHandler : IStopServiceHandler
    {
        public Task<MicrowaveServiceResponse> Handle(StopServiceRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
