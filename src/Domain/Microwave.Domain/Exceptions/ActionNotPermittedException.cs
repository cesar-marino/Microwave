
namespace Microwave.Domain.Exceptions
{
    public class ActionNotPermittedException(
        string? message = "Ação não permitida",
        Exception? innerException = null) : DomainException("action-not-permitted", message, innerException)
    {
    }
}
