using Grpc.Core;
using Microsoft.Extensions.Logging;
using NoSleepWithRunningVM.Api;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static System.Runtime.CompilerServices.RuntimeHelpers;


namespace NoSleepWithRunningVM.Services
{
    public class HookedKeyService : HookedKey.HookedKeyBase
    {
        private readonly ILogger<HookedKeyService> _logger;
        //private Forms.DummySendKeysForm sendKeyForm = new Forms.DummySendKeysForm();

        public HookedKeyService(ILogger<HookedKeyService> logger)
        {
            _logger = logger;
        }

        public override async Task<HookedKeyResponseModel> SendHookedKey(HookedKeySendModel request, ServerCallContext context)
        {
            if (request.KeyCode < (int)Keys.VolumeMute || request.KeyCode > (int)Keys.MediaPlayPause)
                return await Task.FromResult(new HookedKeyResponseModel() { IsReceived = true });

            Console.WriteLine($"SendKey Requested: {request.KeyCode}");
            Debug.WriteLine($"SendKey Requested: {request.KeyCode}");
                       
            //Task.Run(() => sendKeyForm.SendKey((Keys)request.KeyCode));
            Task.Run(() => SendKey((Keys)request.KeyCode));

            return await Task.FromResult(new HookedKeyResponseModel() { IsReceived = true });
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
}
