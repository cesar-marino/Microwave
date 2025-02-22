using Microwave.Domain.SeedWork;

namespace Microwave.Domain.Entities
{
    public class UserEntity : EntityBase
    {
        public string Username { get; }
        public string Password { get; }
        public string? Token { get; private set; }

        public UserEntity(
            string username,
            string password,
            string? token = null)
        {
            Username = username;
            Password = password;
            Token = token;
        }

        public UserEntity(
            Guid userId,
            string username,
            string password,
            string? token) : base(userId)
        {
            Username = username;
            Password = password;
            Token = token;
        }

        public void ChangeToken(string token) => Token = token;
    }
}
