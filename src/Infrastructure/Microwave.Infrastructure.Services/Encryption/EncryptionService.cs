using Microwave.Application.Services;
using Microwave.Domain.Exceptions;

namespace Microwave.Infrastructure.Services.Encryption
{
    public class EncryptionService : IEncryptionService
    {
        public Task<bool> CompareAsync(string value, string hash, CancellationToken cancellationToken = default)
        {
            try
            {
                return Task.FromResult(BCrypt.Net.BCrypt.EnhancedVerify(value, hash, BCrypt.Net.HashType.SHA512));
            }
            catch (Exception ex)
            {
                throw new UnexpectedException(innerException: ex);
            }
        }

        public Task<string> EncyptAsync(string value, CancellationToken cancellationToken = default)
        {
            try
            {
                return Task.FromResult(BCrypt.Net.BCrypt.EnhancedHashPassword(value, 13, BCrypt.Net.HashType.SHA512));
            }
            catch (Exception ex)
            {
                throw new UnexpectedException(innerException: ex);
            }
        }
    }
}
