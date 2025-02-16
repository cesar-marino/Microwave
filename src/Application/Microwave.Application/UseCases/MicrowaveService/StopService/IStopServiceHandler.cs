using MediatR;
using Microwave.Application.UseCases.MicrowaveService.Commons;

namespace Microwave.Application.UseCases.MicrowaveService.StopService
{
    public interface IStopServiceHandler : IRequestHandler<StopServiceRequest, MicrowaveServiceResponse>
    {
    }
}
