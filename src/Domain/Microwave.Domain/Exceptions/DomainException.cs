namespace Microwave.Domain.Exceptions
{
    public class DomainException(
        string code,
        string? message,
        Exception? innerException) : Exception(message, innerException)
    {
        public string Code { get; } = code;
    }
}
