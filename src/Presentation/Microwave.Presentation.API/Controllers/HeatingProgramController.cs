using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microwave.Application.UseCases.HeatingProgram.Commons;
using Microwave.Application.UseCases.HeatingProgram.CreateHeatingProgram;
using Microwave.Application.UseCases.HeatingProgram.GetHeatingProgram;
using Microwave.Application.UseCases.HeatingProgram.RemoveHeatingProgram;
using Microwave.Application.UseCases.HeatingProgram.SearchHeatingPrograms;
using Microwave.Application.UseCases.HeatingProgram.UpdateHeatingProgram;

namespace Microwave.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeatingProgramController(IMediator mediator) : ControllerBase
    {
        [HttpPost("create")]
        [ProducesResponseType(typeof(HeatingProgramResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(
            [FromBody] CreateHeatingProgramReequest request,
            CancellationToken cancellationToken = default)
        {
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(HeatingProgramResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default)
        {
            var request = new GetHeatingProgramRequest(heatingProgramId: id);
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("{id:Guid}/remove")]
        [ProducesResponseType(typeof(Task), StatusCodes.Status204NoContent)]
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

        [HttpGet("search")]
        [ProducesResponseType(typeof(List<HeatingProgramResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Search(
            [FromQuery] string? name,
            [FromQuery] string? food,
            CancellationToken cancellationToken = default)
        {
            var request = new SearchHeatingProgramsRequest(
                name: name,
                food: food);

            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPut("update")]
        [ProducesResponseType(typeof(HeatingProgramResponse), StatusCodes.Status200OK)]
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
