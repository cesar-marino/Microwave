namespace Microwave.Domain.Exceptions
{
    public abstract class DomainException(
        string code,
        string? message,
        Exception? innerException) : Exception(message, innerException)
    {
        public string Code { get; } = code;
    }
}
