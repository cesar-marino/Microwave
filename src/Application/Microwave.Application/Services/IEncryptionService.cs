namespace Microwave.Application.Services
{
    public interface IEncryptionService
    {
        Task<string> EncyptAsync(string value, CancellationToken cancellationToken = default);
    }
}
