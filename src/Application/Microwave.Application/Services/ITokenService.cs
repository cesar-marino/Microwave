namespace Microwave.Application.Services
{
    public interface ITokenService
    {
        Task<string> GenerateTokenAsync(
            Guid id,
            string username,
            CancellationToken cancellationToken = default);
    }
}
