using MediatR;
using Microwave.Application.UseCases.User.Commons;
using System.ComponentModel.DataAnnotations;

namespace Microwave.Application.UseCases.User.Authentication
{
    public class AuthenticationRequest(
        string username,
        string password) : IRequest<UserResponse>
    {
        [Required]
        public string Username { get; } = username;

        [Required]
        public string Password { get; } = password;
    }
}
