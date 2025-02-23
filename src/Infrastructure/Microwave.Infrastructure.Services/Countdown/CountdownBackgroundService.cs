using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microwave.Application.Services;
using Microwave.Domain.Entities;
using Microwave.Domain.Enums;
using Microwave.Domain.Exceptions;
using Microwave.Infrastructure.Services.Hubs;

namespace Microwave.Infrastructure.Services.Countdown
{
    public class CountdownBackgroundService(
        ILogger<CountdownBackgroundService> logger,
        NotificationService notificationService) : BackgroundService, ICountdownBackgroundService
    {
        private MicrowaveServiceEntity? _microwaveService;

        public async Task<MicrowaveServiceEntity> ResumeAsync(Guid microwaveServiceId, CancellationToken cancellationToken = default)
        {
            if (microwaveServiceId != _microwaveService?.Id)
                throw new NotFoundException("Service não encontrado");

            _microwaveService.Resume();
            await base.StartAsync(cancellationToken);
            return _microwaveService;
        }

        public async Task StartAsync(MicrowaveServiceEntity microwaveService, CancellationToken cancellationToken = default)
        {
            try
            {
                _microwaveService = microwaveService;
                await base.StartAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new UnexpectedException(innerException: ex);
            }
        }

        public Task<MicrowaveServiceEntity> StopAsync(Guid microwaveServiceId, CancellationToken cancellationToken = default)
        {
            try
            {
                if (microwaveServiceId != _microwaveService?.Id)
                    throw new NotFoundException("Service não encontrado");

                _microwaveService.Stop();
                return Task.FromResult(_microwaveService);
            }
            catch (Exception ex)
            {
                throw new UnexpectedException(innerException: ex);
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_microwaveService?.Status == MicrowaveServiceStatus.Canceled
                    || _microwaveService?.Status == MicrowaveServiceStatus.Completed)
                    await base.StopAsync(stoppingToken);

                if (_microwaveService?.Status == MicrowaveServiceStatus.InProgress)
                {
                    var processResult = _microwaveService?.Process();
                    await notificationService.NotificationAsync(processResult ?? "Sem mensagem", stoppingToken);
                    logger.LogInformation($"{processResult} - tempo: {_microwaveService?.HeatingProgram.Seconds}");
                }

                await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
            }
        }
    }
}
