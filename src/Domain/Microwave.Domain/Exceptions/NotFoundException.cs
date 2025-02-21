namespace Microwave.Domain.Exceptions
{
    public class NotFoundException(
        string? message = "",
        Exception? innerException = null) : DomainException("not-found", message, innerException)
    {
    }
}
