using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace GuestKeyHooker.Services;
public class SignalRClientService: IAsyncDisposable
{
    private HubConnection? hubConnection;
    private List<string> messages = new();
    //private string? userInput;
    //private string? messageInput;

    public SignalRClientService(string url)
    {
        hubConnection = new HubConnectionBuilder()
            //.WithUrl("https://Ryzen1:50443")
            .WithUrl(url)
            .WithAutomaticReconnect()
            .Build();

        // Listen for message from server if we want to
        hubConnection.On<string, string>("ReceiveMessage", (user, message) => 
        {
            var formattedMessage = $"{user}: {message}";
            messages.Add(formattedMessage);
            //InvokeAsync(StateHasChanged);
        });

        hubConnection.StartAsync();
    }

    public async Task SendCommand(string username, string password)
    {
        if (hubConnection is not null)
        {
            await hubConnection.SendAsync("SendMessage", username, password);
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
