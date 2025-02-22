using Microwave.Application.UseCases.User.Commons;
using Microwave.Domain.Repositories;

namespace Microwave.Application.UseCases.User.CreateUser
{
    public class CreateUserHandler(IUserRepository userRepository) : ICreateUserHandler
    {
        public async Task<UserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            await userRepository.CheckUsernameAsync(request.Username, cancellationToken);

            throw new NotImplementedException();
        }
    }
}
