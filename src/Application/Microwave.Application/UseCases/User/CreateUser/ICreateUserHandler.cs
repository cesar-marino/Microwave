using MediatR;
using Microwave.Application.UseCases.User.Commons;

namespace Microwave.Application.UseCases.User.CreateUser
{
    public interface ICreateUserHandler : IRequestHandler<CreateUserRequest, UserResponse>
    {
    }
}
