using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microwave.Application.UseCases.MicrowaveService.StartService;
using Microwave.Application.UseCases.MicrowaveService.StopService;

namespace Microwave.Presentation.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MicrowaveServiceController(IMediator mediator) : ControllerBase
    {
        [HttpPost("start")]
        public async Task<IActionResult> Start(
            [FromBody] StartServiceRequest request,
            CancellationToken cancellationToken = default)
        {
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost("stop")]
        public async Task<IActionResult> Stop(
            [FromBody] StopServiceRequest request,
            CancellationToken cancellationToken = default)
        {
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
