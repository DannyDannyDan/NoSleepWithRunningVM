using System.Diagnostics;
using System.Windows.Forms;
using System.Threading.Tasks;
using Grpc.Net.Client;
using NoSleepWithRunningVM;
using System.Net;
using System.Runtime.ConstrainedExecution;
//using GuestKeyHooker;

namespace GuestKeyHooker
{
    internal static class Program
    {
        static NotifyIcon? notifyIcon;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            notifyIcon = new NotifyIcon();
            notifyIcon.ContextMenuStrip = Helpers.SystemTrayHelper.GetContextMenu();
            notifyIcon.Icon = Properties.Resources.Keyboard_light;
            notifyIcon.Visible = true;

            // setup keyboard hook
            var kh = new KeyboardHook(true);
            kh.KeyDown += Kh_KeyDown;

            //await ConnectGreater();

            Application.Run();
        }

        private static async void Kh_KeyDown(Keys key, bool Shift, bool Ctrl, bool Alt)
        {
            Debug.WriteLine($"KeyDown {key} ({(int)key})", "KeyHooker");
            try
            {
                if (key < Keys.VolumeMute || key > Keys.MediaPlayPause)
                    return;

                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                //handler.ServerCertificateCustomValidationCallback += (o, c, ch, er) => true;
                var httpClient = new HttpClient(handler);

                var channel = GrpcChannel.ForAddress("https://Ryzen1:50443/", new GrpcChannelOptions
                {
                    HttpClient = httpClient
                });

                GuestKeyHooker.Helpers.KeyHelper.RelaseVmwareControl();
                var client = new HookedKey.HookedKeyClient(channel);
                var reply = await client.SendHookedKeyAsync(new HookedKeySendModel { KeyCode = (int)key });



            }
            catch (Exception ex)
            {
                //Debug.Print($"{ex.Message}: {ex.StackTrace}");
                Debug.Print($"{ex.Message}.");
            }
        }
    }
}