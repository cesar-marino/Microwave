
namespace Microwave.Domain.Exceptions
{
    public class InvalidPasswordException(
        string? message = null,
        Exception? innerException = null) : DomainException("invalid-password", message, innerException)
    {
    }
}
