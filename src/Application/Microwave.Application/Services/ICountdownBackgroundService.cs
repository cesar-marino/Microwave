using Microwave.Domain.Entities;

namespace Microwave.Application.Services
{
    public interface ICountdownBackgroundService
    {
        Task StartAsync(MicrowaveServiceEntity microwaveService, CancellationToken cancellationToken = default);
        Task StopAsync(Guid microwaveServiceId, CancellationToken cancellationToken = default);
    }
}
