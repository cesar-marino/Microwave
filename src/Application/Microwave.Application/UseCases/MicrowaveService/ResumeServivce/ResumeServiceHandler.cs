using Microwave.Application.UseCases.MicrowaveService.Commons;

namespace Microwave.Application.UseCases.MicrowaveService.ResumeServivce
{
    public class ResumeServiceHandler : IResumeServiceHandler
    {
        public Task<MicrowaveServiceResponse> Handle(ResumeServiceRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
