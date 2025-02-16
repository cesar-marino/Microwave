
namespace Microwave.Domain.Exceptions
{
    public class EntityValidationException(
        string code = "invalid-entity",
        string? message = "",
        Exception? innerException = null) : DomainException(code, message, innerException)
    {
    }
}
