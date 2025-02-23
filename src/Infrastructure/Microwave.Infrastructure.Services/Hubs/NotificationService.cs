using Microsoft.AspNetCore.SignalR;

namespace Microwave.Infrastructure.Services.Hubs
{
    public class NotificationService(IHubContext<HeatingNotificationHab> hubContext)
    {
        public async Task NotificationAsync(string message, CancellationToken cancellationToken = default)
        {
            await hubContext.Clients.All.SendAsync("HeatingNotification", message, cancellationToken);
        }
    }
}
