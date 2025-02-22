using MediatR;
using Microwave.Application.UseCases.User.Commons;

namespace Microwave.Application.UseCases.User.CreateUser
{
    public class CreateUserRequest(
        string username,
        string password) : IRequest<UserResponse>
    {
        public string Username { get; } = username;
        public string Password { get; } = password;
    }
}
