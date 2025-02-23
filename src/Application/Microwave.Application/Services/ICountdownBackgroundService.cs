using Microwave.Domain.Entities;

namespace Microwave.Application.Services
{
    public interface ICountdownBackgroundService
    {
        Task<MicrowaveServiceEntity> ResumeAsync(Guid microwaveServiceId, CancellationToken cancellationToken = default);
        Task StartAsync(MicrowaveServiceEntity microwaveService, CancellationToken cancellationToken = default);
        Task<MicrowaveServiceEntity> StopAsync(Guid microwaveServiceId, CancellationToken cancellationToken = default);
    }
}
