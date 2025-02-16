using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microwave.Application.Hubs;
using Microwave.Application.Services;
using Microwave.Domain.Entities;
using Microwave.Domain.Exceptions;

namespace Microwave.Infrastructure.Services.Countdown
{
    public class CountdownBackgroundService(
        ILogger<CountdownBackgroundService> logger,
        IHubContext<HeatingNotificationHub, IHeatingNotificationHub> notification) : BackgroundService, ICountdownBackgroundService
    {
        private readonly ILogger<CountdownBackgroundService> _logger = logger;
        private MicrowaveServiceEntity? _microwaveService;

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

        public async Task<MicrowaveServiceEntity> StopAsync(Guid microwaveServiceId, CancellationToken cancellationToken = default)
        {
            try
            {
                if (_microwaveService?.Id == microwaveServiceId)
                {
                    return await Task.Run(() =>
                    {
                        _microwaveService.Stop();
                        return _microwaveService;
                    });
                }

                throw new NotFoundException("Serviço não encontrado");
            }
            catch (Exception ex)
            {
                throw new UnexpectedException(innerException: ex);
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    if (_microwaveService != null)
                    {
                        switch (_microwaveService.Status)
                        {
                            case Domain.Enums.MicrowaveServiceStatus.InProgress:
                                var processedResult = _microwaveService.Heat();
                                _logger.LogInformation($"Processada || resultado: {processedResult} - tempo: {_microwaveService.HeatingProgram.Seconds}");

                                await notification.Clients.All.SendNotification("Notifica porra");

                                //await notification.Clients.All.SendAsync(
                                //    "ReceiveMessage",
                                //     $"Processada || resultado: {processedResult} - tempo: {_microwaveService.HeatingProgram.Seconds}",
                                //     cancellationToken: stoppingToken);
                                break;
                            case Domain.Enums.MicrowaveServiceStatus.Paused:
                                break;
                            case Domain.Enums.MicrowaveServiceStatus.Canceled:
                            case Domain.Enums.MicrowaveServiceStatus.Completed:
                                _microwaveService = null;
                                await base.StopAsync(stoppingToken);
                                break;
                            default:
                                break;
                        }
                    }

                    await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
                }
            }
            catch (TaskCanceledException)
            {
                _logger.LogInformation("Task cancelada");
            }
        }
    }
}