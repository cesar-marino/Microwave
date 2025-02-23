using MediatR;
using Microwave.Application.UseCases.MicrowaveService.Commons;

namespace Microwave.Application.UseCases.MicrowaveService.ResumeServivce
{
    public interface IResumeServiceHandler : IRequestHandler<ResumeServiceRequest, MicrowaveServiceResponse>
    {
    }
}
