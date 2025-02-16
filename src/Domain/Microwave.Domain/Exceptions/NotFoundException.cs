
namespace Microwave.Domain.Exceptions
{
    public class NotFoundException(
        string code = "not-found",
        string? message = null,
        Exception? innerException = null) : DomainException(code, message, innerException)
    {
    }
}
