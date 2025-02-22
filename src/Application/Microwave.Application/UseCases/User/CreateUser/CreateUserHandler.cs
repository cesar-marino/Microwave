using Microwave.Application.UseCases.User.Commons;

namespace Microwave.Application.UseCases.User.CreateUser
{
    public class CreateUserHandler : ICreateUserHandler
    {
        public Task<UserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
