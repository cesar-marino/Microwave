using MediatR;
using Microwave.Application.UseCases.MicrowaveService.Commons;

namespace Microwave.Application.UseCases.MicrowaveService.StartService
{
    public interface IStartServiceHandler : IRequestHandler<StartServiceRequest, MicrowaveServiceResponse>
    {
    }
}
