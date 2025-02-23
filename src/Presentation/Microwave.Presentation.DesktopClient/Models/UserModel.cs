namespace Microwave.Presentation.DesktopClient.Models
{
    public class UserModel(
        Guid userId,
        string username,
        string password) : ModelBase(userId)
    {
        public string Username { get; } = username;
        public string Password { get; } = password;
    }
}
