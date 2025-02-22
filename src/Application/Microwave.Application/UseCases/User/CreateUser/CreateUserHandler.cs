using Microwave.Application.UseCases.User.Commons;
using Microwave.Domain.Exceptions;
using Microwave.Domain.Repositories;

namespace Microwave.Application.UseCases.User.CreateUser
{
    public class CreateUserHandler(IUserRepository userRepository) : ICreateUserHandler
    {
        public async Task<UserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var usernameInUse = await userRepository.CheckUsernameAsync(request.Username, cancellationToken);
            if (usernameInUse)
                throw new UsernameInUseException("Username já cadastrado para outro usuário");

            throw new NotImplementedException();
        }
    }
}
