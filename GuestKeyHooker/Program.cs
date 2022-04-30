using System.Diagnostics;
using System.Windows.Forms;
using System.Threading.Tasks;
using Grpc.Net.Client;
using NoSleepWithRunningVM;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Net.Sockets;

namespace GuestKeyHooker
{
    internal static class Program
    {
        static NotifyIcon? notifyIcon;
        private static HookedKey.HookedKeyClient? _client;

        private static HookedKey.HookedKeyClient Client { 
            get { 
                if (_client == null)
                {
                    var handler = new HttpClientHandler();
                    handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                    var httpClient = new HttpClient(handler);

                    //var channel = GrpcChannel.ForAddress("https://Ryzen1:50443/", new GrpcChannelOptions
                    var channel = GrpcChannel.ForAddress("https://Ryzen1:50443/", new GrpcChannelOptions
                    {
                        HttpClient = httpClient
                    });

                    _client = new HookedKey.HookedKeyClient(channel);
                }
                return _client;
            }             
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
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

            // connect client on startup
            _ = Client.SendHookedKeyAsync(new HookedKeySendModel());

            Application.Run();
        }

        private static async void Kh_KeyDown(Keys key, bool Shift, bool Ctrl, bool Alt)
        {
            try
            {
                if (key < Keys.VolumeMute || key > Keys.MediaPlayPause)
                    return;

                Debug.WriteLine($"SendHookedKeyAsync {key} ({(int)key})", "KeyHooker");

                var reply = await Client.SendHookedKeyAsync(new HookedKeySendModel { KeyCode = (int)key });
            }
            catch (Exception ex)
            {
                Debug.Print($"{ex.Message}.");
            }
        }
    }
}