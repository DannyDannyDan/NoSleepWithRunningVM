using System.Diagnostics;
using Microsoft.AspNetCore.SignalR;
using NoSleepWithRunningVM.Api;

namespace NoSleepWithRunningVM.Hubs;

public class CommandHub : Hub
{
    public Task SendMessage(string user, string message)
    {
        return Clients.All.SendAsync("ReceiveMessage",user, message);
    }
    public Task SendCommand(Keys key)
    {
        if ((int)key < (int)Keys.VolumeMute || (int)key > (int)Keys.MediaPlayPause)
            //return Task.FromResult(new HookedKeyResponseModel() { IsReceived = true });
            return Clients.All.SendAsync("ReceiveCommand", $"SendKey request denied {(key)}.");

        Console.WriteLine($"SendKey Requested: {(int)key}");
        Debug.WriteLine($"SendKey Requested: {(int)key}");

        Task.Run(() => SendKey(key));

        return Clients.All.SendAsync("ReceiveCommand", $"SendKey approved {(key)}.");
    }
    public async void SendKey(Keys keyCode)
    {
        //var hWnd = form.Handle;
        var hWnd = WinApi.GetShellWindow();

        switch (keyCode)
        {
            case Keys.VolumeMute:
                await Task.FromResult(WinApi.SendMessage(hWnd, Api.WinApi.WM_APPCOMMAND, hWnd, (IntPtr)Api.WinApi.APPCOMMAND_VOLUME_MUTE));
                break;
            case Keys.VolumeUp:
                await Task.FromResult(WinApi.SendMessage(hWnd, Api.WinApi.WM_APPCOMMAND, hWnd, (IntPtr)Api.WinApi.APPCOMMAND_VOLUME_UP));
                break;
            case Keys.VolumeDown:
                await Task.FromResult(WinApi.SendMessage(hWnd, Api.WinApi.WM_APPCOMMAND, hWnd, (IntPtr)Api.WinApi.APPCOMMAND_VOLUME_DOWN));
                break;
            case Keys.MediaStop:
                await Task.FromResult(WinApi.SendMessage(hWnd, WinApi.WM_APPCOMMAND, hWnd, (IntPtr)WinApi.APPCOMMAND_MEDIA_STOP));
                break;
            case Keys.MediaPlayPause:
                await Task.FromResult(WinApi.SendMessage(hWnd, WinApi.WM_APPCOMMAND, hWnd, (IntPtr)WinApi.APPCOMMAND_MEDIA_PLAY_PAUSE));
                break;
            case Keys.MediaNextTrack:
                await Task.FromResult(WinApi.SendMessage(hWnd, WinApi.WM_APPCOMMAND, hWnd, (IntPtr)WinApi.APPCOMMAND_MEDIA_NEXTTRACK));
                break;
            case Keys.MediaPreviousTrack:
                await Task.FromResult(WinApi.SendMessage(hWnd, WinApi.WM_APPCOMMAND, hWnd, (IntPtr)WinApi.APPCOMMAND_MEDIA_PREVIOUSTRACK));
                break;
        }
    }
}
