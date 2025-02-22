using Microwave.Application.UseCases.User.Commons;

namespace Microwave.Application.UseCases.User.Authentication
{
    public class AuthenticationHandler : IAuthenticationHandler
    {
        public Task<UserResponse> Handle(AuthenticationRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
