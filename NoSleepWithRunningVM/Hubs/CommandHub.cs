using Microsoft.AspNetCore.SignalR;

namespace NoSleepWithRunningVM.Hubs;

public class CommandHub : Hub
{
    public Task SendMessage(string user, string message)
    {
        return Clients.All.SendAsync("ReceiveMessage",user, message);
    }
}
