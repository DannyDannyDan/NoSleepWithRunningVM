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

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            notifyIcon = new NotifyIcon();
            notifyIcon.ContextMenuStrip = Helpers.SystemTrayHelper.GetContextMenu();
            notifyIcon.Icon = Properties.Resources.Keyboard_light;
            notifyIcon.Visible = true;

            // setup keyboard hook
            var kh = new KeyboardHook(true);
            kh.KeyDown += Kh_KeyDown;

            ConnectGrpcServer();

            Application.Run();
        }

        private static async void ConnectGrpcServer()
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

            IsConnected = await GrpcClientService.CanConnectAsync();

            if (IsConnected == false)
                MessageBox.Show("Unable to connect");
        }

        private static async void Kh_KeyDown(Keys key, bool Shift, bool Ctrl, bool Alt)
        {
            if (_settingsForm != null)
                return;

            if (!IsConnected)
                IsConnected = await GrpcClientService.CanConnectAsync();

            if (IsConnected)
                try
                {
                    if (key < Keys.VolumeMute || key > Keys.MediaPlayPause)
                        return;

                    Debug.WriteLine($"SendHookedKeyAsync {key} ({(int)key})", "KeyHooker");

                    var reply = await GrpcClientService.Client.SendHookedKeyAsync(new HookedKeySendModel { KeyCode = (int)key });
                }
                catch (Exception ex)
                {
                    Debug.Print($"{ex.Message}.");
                }
        }
    }
}