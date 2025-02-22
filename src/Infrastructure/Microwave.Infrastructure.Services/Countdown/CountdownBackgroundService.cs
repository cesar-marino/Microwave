using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microwave.Application.Services;
using Microwave.Domain.Entities;
using Microwave.Domain.Enums;
using Microwave.Domain.Exceptions;

namespace Microwave.Infrastructure.Services.Countdown
{
    public class CountdownBackgroundService(ILogger<CountdownBackgroundService> logger) : BackgroundService, ICountdownBackgroundService
    {
        private MicrowaveServiceEntity? _microwaveService;

        public async Task StartAsync(MicrowaveServiceEntity microwaveService, CancellationToken cancellationToken = default)
        {
            try
            {
                _microwaveService = microwaveService;
                logger.LogInformation("Start service.........");
                await base.StartAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new UnexpectedException(innerException: ex);
            }
        }

        public async Task<MicrowaveServiceEntity> StopAsync(Guid microwaveServiceId, CancellationToken cancellationToken = default)
        {
            try
            {
                if (microwaveServiceId != _microwaveService?.Id)
                    throw new NotFoundException("Service não encontrado");

                _microwaveService.Stop();
                logger.LogInformation("Stop service........");
                await base.StopAsync(cancellationToken);
                return _microwaveService;
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
                    _microwaveService?.Process();
                    logger.LogInformation("Processando ..............");
                }

                await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
            }
        }
    }
}
