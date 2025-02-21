
namespace Microwave.Domain.Exceptions
{
    public class EntityValidationException(
        string? message = "Erro na validação de entidade",
        Exception? innerException = null) : DomainException("entity-validation", message, innerException)
    {
    }
}
