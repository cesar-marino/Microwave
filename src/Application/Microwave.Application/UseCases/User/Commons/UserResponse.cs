namespace Microwave.Application.UseCases.User.Commons
{
    public class UserResponse(
        Guid userId,
        string username)
    {
        public Guid UserId { get; } = userId;
        public string Username { get; } = username;
    }
}
