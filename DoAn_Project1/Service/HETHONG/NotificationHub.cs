using AutoDependencyRegistration.Attributes;
using Microsoft.AspNetCore.SignalR;
using MODELS.BASE;

namespace REPONSITORY.HETHONG
{
    [RegisterClassAsTransient]
    public class NotificationHub : Hub, INotificationHub 
    {
        protected IHubContext<NotificationHub> _context;

        public NotificationHub(IHubContext<NotificationHub> context)
        {
            _context = context;
        }

        public async Task SendMessage(MODELNotification model)
        {
            await _context.Clients.All.SendAsync("ReceiveMessage", Newtonsoft.Json.JsonConvert.SerializeObject(model));
        }
    }

    public interface INotificationHub
    {
        public Task SendMessage(MODELNotification model);
    }
}
