using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GuestKeyHooker.Services;
public class SignalRClientService: IAsyncDisposable
{
    private HubConnection? hubConnection;
    private List<string> messages = new();

    public SignalRClientService(string url)
    {
        hubConnection = new HubConnectionBuilder()
            .WithUrl(url)
            .WithAutomaticReconnect()
            .Build();

        hubConnection.StartAsync();
    }

    public async Task SendCommand(Keys key)
    {
        if (hubConnection is not null)
        {
            await hubConnection.SendAsync("SendCommand", key);
        }
    }

    public bool IsConnected
    {
        get
        {
            return hubConnection?.State == HubConnectionState.Connected;
        }
    }

    public async ValueTask DisposeAsync()
    {
        if(hubConnection is not null)
        {
            await hubConnection.DisposeAsync();
        }
    }
}
