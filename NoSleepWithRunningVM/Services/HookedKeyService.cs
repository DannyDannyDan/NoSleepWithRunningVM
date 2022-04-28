using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static System.Runtime.CompilerServices.RuntimeHelpers;


namespace NoSleepWithRunningVM.Services
{
    public class HookedKeyService : HookedKey.HookedKeyBase
    {
        //public const int KEYEVENTF_EXTENTEDKEY = 1;
        //public const int KEYEVENTF_KEYUP = 0;
        //public const int VK_MEDIA_NEXT_TRACK = 0xB0;
        //public const int VK_MEDIA_PLAY_PAUSE = 0xB3;
        //public const int VK_MEDIA_PREV_TRACK = 0xB1;

        //[DllImport("user32.dll")]
        //public static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);

        private readonly ILogger<HookedKeyService> _logger;
        private Forms.DummySendKeysForm sendKeyForm = new Forms.DummySendKeysForm();

        public HookedKeyService(ILogger<HookedKeyService> logger)
        {
            _logger = logger;
        }

        public override Task<HookedKeyResponseModel> SendHookedKey(HookedKeySendModel request, ServerCallContext context)
        {
            if (request.KeyCode < (int)Keys.VolumeMute || request.KeyCode > (int)Keys.MediaPlayPause)
                return Task.FromResult(new HookedKeyResponseModel() { IsReceived = true });

            Console.WriteLine($"SendKey Requested: {request.KeyCode}");
            Debug.WriteLine($"SendKey Requested: {request.KeyCode}");
                       

            //Forms.DummySendKeysForm sendKeyForm = null;
            //if (sendKeyForm == null)
            //{
            //    sendKeyForm = new Forms.DummySendKeysForm();
            //}
            //if (!sendKeyForm.Visible)
            //    sendKeyForm.Show();

            //sendKeyForm.Show();
            sendKeyForm.SendKey((Keys)request.KeyCode);
            //SendKeysFunction((Keys)request.KeyCode);
            
            
            //keybd_event(VK_MEDIA_PLAY_PAUSE, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);    // Play/Pause
            
            
            //keybd_event((byte)request.KeyCode, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);


            return Task.FromResult(new HookedKeyResponseModel() { IsReceived = true });
        }

        //public const byte VK_F8 = 0x77;

        //public void SendKeysFunction(Keys key)
        //{
        //    //keybd_event((byte)key, 0x45, 0, 0);
        //    keybd_event((byte)key, 0x0, 0, 0);
        //}
    }
}
