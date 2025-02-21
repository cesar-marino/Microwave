namespace Microwave.Domain.Exceptions
{
    public class NotFoundException(
        string code = "not-found",
        string? message = "",
        Exception? innerException = null) : DomainException(code, message, innerException)
    {
    }
}
