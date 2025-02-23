using Microsoft.AspNetCore.SignalR;

namespace Microwave.Infrastructure.Services.Hubs
{
    public class HeatingNotificationHab : Hub
    {
        public async Task SendAsync(string message, CancellationToken cancellationToken = default)
        {
            await Clients.All.SendAsync("HeatingNotification", message, cancellationToken);
        }
    }
}
