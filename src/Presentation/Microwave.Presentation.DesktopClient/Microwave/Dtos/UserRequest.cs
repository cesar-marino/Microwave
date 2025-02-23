namespace Microwave.Presentation.DesktopClient.Microwave.Dtos
{
    public class UserRequest(
        string username,
        string password)
    {
        public string Username { get; } = username;
        public string Password { get; } = password;
    }
}
