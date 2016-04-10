using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Web.Hubs
{
    [HubName("notificationHub")]
    public class NotificationHub : Hub
    {
        [HubMethodName("onNewMessage")]
        public void Send(string message)
        {
            var hubWrraper = new ChatHubWrraper();
            hubWrraper.Send(message);
        }
    }

    public class ChatHubWrraper
    {
        private readonly IHubContext _hubContext;

        public ChatHubWrraper()
        {
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
        }

        public void Send(string message)
        {
            _hubContext.Clients.All.onNewMessage(message);
        }
    }
}