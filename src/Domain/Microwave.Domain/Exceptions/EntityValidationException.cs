
namespace Microwave.Domain.Exceptions
{
    public class EntityValidationException(
        string code = "entity-validation",
        string? message = "Erro na validação de entidade",
        Exception? innerException = null) : DomainException(code, message, innerException)
    {
    }
}
