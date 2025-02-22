using Microwave.Domain.SeedWork;

namespace Microwave.Domain.Entities
{
    public class UserEntity(
        string username,
        string password) : EntityBase
    {
        public string Username { get; } = username;
        public string Password { get; } = password;
    }
}
