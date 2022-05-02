using System.Diagnostics;
using System.Windows.Forms;
using System.Threading.Tasks;
using Grpc.Net.Client;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using GuestKeyHooker.Services;

namespace GuestKeyHooker
{
    internal static class Program
    {
        static NotifyIcon? notifyIcon;
        private static bool IsConnected;
        private static Forms.SettingsForm? _settingsForm = null;
        public static Services.SignalRClientService? SignalRClientService = null;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // exit if already running for this user
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName)
                .Where((p) => p.SessionId == Process.GetCurrentProcess().SessionId)
                .Count() > 1)
            {
                MessageBox.Show("Already Running", "Guest Key Hooker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return; // this is hit
            }

            ApplicationConfiguration.Initialize();

            notifyIcon = new NotifyIcon();
            notifyIcon.ContextMenuStrip = Helpers.SystemTrayHelper.GetContextMenu();
            notifyIcon.Icon = Properties.Resources.Keyboard_light;
            notifyIcon.Visible = true;

            // setup keyboard hook
            var kh = new KeyboardHook(true);
            kh.KeyDown += Kh_KeyDown;

            ConnectHostServer();

            Application.Run();

            // remove icon from system tray
            notifyIcon.Visible = false;
        }

        private static void ConnectHostServer()
        {
            if (Properties.Settings.Default.ServiceIp == "" || Properties.Settings.Default.ServicePort == "")
            {
                // show settings form
                _settingsForm = new Forms.SettingsForm();
                var dlgResult = _settingsForm.ShowDialog();
                _settingsForm = null;

                if (dlgResult == DialogResult.Cancel)
                    return;
            }

            //SignalRClientService = new SignalRClientService($"https://{Properties.Settings.Default.ServiceIp}:{Properties.Settings.Default.ServicePort}/commandhub");

            SignalRClientService = new SignalRClientService($"http://{Properties.Settings.Default.ServiceIp}:{Properties.Settings.Default.ServicePort}/commandhub");

            //Task.Run(() => {
            IsConnected = SignalRClientService.IsConnected;
            //System.Threading.Thread.Sleep(3000);
            for (int i = 0; i < 10 && !IsConnected; i++)
            {
                IsConnected = SignalRClientService.IsConnected;
                System.Threading.Thread.Sleep(100);
                Application.DoEvents();
            }
            //}).Wait();

            IsConnected = SignalRClientService.IsConnected;

            //IsConnected = await GrpcClientService.CanConnectAsync();

            //if (IsConnected == false)
            //    MessageBox.Show("Unable to connect");
        }

        private static async void Kh_KeyDown(Keys key, bool Shift, bool Ctrl, bool Alt)
        {
            if (_settingsForm != null)
                return;

            if (!IsConnected)
                //IsConnected = await GrpcClientService.CanConnectAsync();
                IsConnected = SignalRClientService.IsConnected;

            if (IsConnected)
                try
                {
                    if (key < Keys.VolumeMute || key > Keys.MediaPlayPause)
                        return;

                    Debug.WriteLine($"SendHookedKeyAsync {key} ({(int)key})", "KeyHooker");

                    SignalRClientService.SendCommand(key);

                    //var reply = await GrpcClientService.Client.SendHookedKeyAsync(new HookedKeySendModel { KeyCode = (int)key });
                }
                catch (Exception ex)
                {
                    Debug.Print($"{ex.Message}.");
                }
        }
    }
}