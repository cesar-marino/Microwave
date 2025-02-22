using Microwave.Domain.Entities;

namespace Microwave.Application.UseCases.User.Commons
{
    public class UserResponse(
        Guid userId,
        string username,
        string? token)
    {
        public Guid UserId { get; } = userId;
        public string Username { get; } = username;
        public string? Token { get; } = token;

        public static UserResponse FromEntity(UserEntity user) => new(
            userId: user.Id,
            username: user.Username,
            token: user.Token);
    }
}
