
namespace Microwave.Domain.Exceptions
{
    public class ActionNotPermittedException(
        string code = "action-not-permitted",
        string? message = "Ação não permitida",
        Exception? innerException = null) : DomainException(code, message, innerException)
    {
    }
}
