using Microwave.Application.UseCases.MicrowaveService.Commons;

namespace Microwave.Application.UseCases.MicrowaveService.StartService
{
    public class StartServiceHandler : IStartServiceHandler
    {
        public Task<MicrowaveServiceResponse> Handle(StartServiceRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
