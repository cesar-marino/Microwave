
namespace Microwave.Domain.Exceptions
{
    public class EntityValidationException(
        string code = "entity-validation",
        string? message = null,
        Exception? innerException = null) : DomainException(code, message, innerException)
    {
    }
}
