using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microwave.Application.UseCases.HeatingProgram.CreateHeatingProgram;
using Microwave.Application.UseCases.HeatingProgram.GetListHeatingPrograms;
using Microwave.Application.UseCases.HeatingProgram.RemoveHeatingProgram;
using Microwave.Application.UseCases.HeatingProgram.UpdateHeatingProgram;

namespace Microwave.Presentation.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HeatingProgramController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateHeatingProgramRequest request,
            CancellationToken cancellationToken = default)
        {
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var request = new GetListHeatingProgramsRequest();
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("id:Guid/remove")]
        public async Task<IActionResult> Remove(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default)
        {
            var request = new RemoveHeatingProgramRequest(heatingProgramId: id);
            await mediator.Send(request, cancellationToken);
            return StatusCode(204);
        }

        [HttpPut]
        public async Task<IActionResult> Update(
            [FromBody] UpdateHeatingProgramRequest request,
            CancellationToken cancellationToken = default)
        {
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
