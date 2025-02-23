using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microwave.Application.UseCases.HeatingProgram.Commons;
using Microwave.Application.UseCases.HeatingProgram.CreateHeatingProgram;
using Microwave.Application.UseCases.HeatingProgram.GetListHeatingPrograms;
using Microwave.Application.UseCases.HeatingProgram.RemoveHeatingProgram;
using Microwave.Application.UseCases.HeatingProgram.UpdateHeatingProgram;
using Microwave.Presentation.API.Filters;

namespace Microwave.Presentation.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[CustomAuthorize()]
    public class HeatingProgramController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(HeatingProgramResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(
            [FromBody] CreateHeatingProgramRequest request,
            CancellationToken cancellationToken = default)
        {
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyList<HeatingProgramResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var request = new GetListHeatingProgramsRequest();
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("id:Guid/remove")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Remove(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default)
        {
            var request = new RemoveHeatingProgramRequest(heatingProgramId: id);
            await mediator.Send(request, cancellationToken);
            return StatusCode(204);
        }

        [HttpPut]
        [ProducesResponseType(typeof(HeatingProgramResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(
            [FromBody] UpdateHeatingProgramRequest request,
            CancellationToken cancellationToken = default)
        {
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
