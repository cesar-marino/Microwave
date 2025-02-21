
namespace Microwave.Domain.Exceptions
{
    public class UnexpectedException(
        string code = "unexpected",
        string? message = "Erro inexperado",
        Exception? innerException = null) : DomainException(code, message, innerException)
    {
    }
}
