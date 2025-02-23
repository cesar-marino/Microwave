using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microwave.Application.UseCases.MicrowaveService.ResumeServivce;
using Microwave.Application.UseCases.MicrowaveService.StartService;
using Microwave.Application.UseCases.MicrowaveService.StopService;
using Microwave.Presentation.API.Filters;

namespace Microwave.Presentation.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MicrowaveServiceController(IMediator mediator) : ControllerBase
    {
        [HttpPost("start")]
        [CustomAuthorize()]
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

        [HttpPost("resume")]
        public async Task<IActionResult> Resume(
            [FromBody] ResumeServiceRequest request,
            CancellationToken cancellationToken = default)
        {
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
