namespace Microwave.Application.Hubs
{
    public interface IHeatingNotificationHub
    {
        Task SendNotification(string processedResult);
    }
}
