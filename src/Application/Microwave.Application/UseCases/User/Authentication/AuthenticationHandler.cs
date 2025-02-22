using Microwave.Application.UseCases.User.Commons;
using Microwave.Domain.Repositories;

namespace Microwave.Application.UseCases.User.Authentication
{
    public class AuthenticationHandler(IUserRepository userRepository) : IAuthenticationHandler
    {
        public async Task<UserResponse> Handle(AuthenticationRequest request, CancellationToken cancellationToken)
        {
            await userRepository.FindByUsernameAsync(request.Username, cancellationToken);
            throw new NotImplementedException();
        }
    }
}
