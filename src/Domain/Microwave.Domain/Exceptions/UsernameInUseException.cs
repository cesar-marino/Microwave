namespace Microwave.Domain.Exceptions
{
    public class UsernameInUseException(
        string? message = null,
        Exception? innerException = null) : DomainException("username-in-use", message, innerException)
    {
    }
}
