namespace Microwave.Application.Services
{
    public interface IEncryptionService
    {
        Task<bool> CompareAsync(string value, string hash, CancellationToken cancellationToken = default);
        Task<string> EncyptAsync(string value, CancellationToken cancellationToken = default);
    }
}
