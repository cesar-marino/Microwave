
namespace Microwave.Domain.Exceptions
{
    public class UnexpectedException(
        string code = "unexpected",
        string? message = "Ocorreu um erro inexperado, tente novamente",
        Exception? innerException = null) : DomainException(code, message, innerException)
    {
    }
}
