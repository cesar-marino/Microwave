
namespace Microwave.Domain.Exceptions
{
    public class UnexpectedException(
        string? message = "Erro inexperado",
        Exception? innerException = null) : DomainException("unexpected", message, innerException)
    {
    }
}
