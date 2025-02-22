using MediatR;
using Microwave.Application.UseCases.User.Commons;

namespace Microwave.Application.UseCases.User.Authentication
{
    public interface IAuthenticationHandler : IRequestHandler<AuthenticationRequest, UserResponse>
    {
    }
}
