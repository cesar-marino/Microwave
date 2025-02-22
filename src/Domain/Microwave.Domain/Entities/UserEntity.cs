using Microwave.Domain.SeedWork;

namespace Microwave.Domain.Entities
{
    public class UserEntity(
        string username,
        string password,
        string? token = null) : EntityBase
    {
        public string Username { get; } = username;
        public string Password { get; } = password;
        public string? Token { get; private set; } = token;

        public void ChangeToken(string token) => Token = token;
    }
}
