using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microwave.Application.UseCases.User.Authentication;
using Microwave.Application.UseCases.User.CreateUser;

namespace Microwave.Presentation.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController(IMediator mediator) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateUserRequest request,
            CancellationToken cancellationToken = default)
        {
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost("auth")]
        public async Task<IActionResult> Auth(
            [FromBody] AuthenticationRequest request,
            CancellationToken cancellationToken = default)
        {
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
