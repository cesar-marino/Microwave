
namespace Microwave.Domain.Exceptions
{
    public class UnexpectedException(
        string? message = "Erro inesperado",
        Exception? innerException = null) : DomainException("unexpected", message, innerException)
    {
    }
}
