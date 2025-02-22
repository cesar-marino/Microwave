using Microwave.Application.Services;
using Microwave.Application.UseCases.User.Commons;
using Microwave.Domain.Repositories;

namespace Microwave.Application.UseCases.User.Authentication
{
    public class AuthenticationHandler(
        IUserRepository userRepository,
        IEncryptionService encryptionService) : IAuthenticationHandler
    {
        public async Task<UserResponse> Handle(AuthenticationRequest request, CancellationToken cancellationToken)
        {
            var user = await userRepository.FindByUsernameAsync(request.Username, cancellationToken);
            await encryptionService.CompareAsync(request.Password, user.Password, cancellationToken);


            throw new NotImplementedException();
        }
    }
}
