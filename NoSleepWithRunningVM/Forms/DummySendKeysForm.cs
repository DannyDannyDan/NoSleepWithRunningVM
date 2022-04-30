using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using NoSleepWithRunningVM.Api;

namespace NoSleepWithRunningVM.Forms
{
    public partial class DummySendKeysForm : Form
    {
        public const int KEYEVENTF_EXTENTEDKEY = 1;
        public const int KEYEVENTF_KEYUP = 0;
        public const int VK_MEDIA_NEXT_TRACK = 0xB0;
        public const int VK_MEDIA_PLAY_PAUSE = 0xB3;
        public const int VK_MEDIA_PREV_TRACK = 0xB1;
        public const int VK_CONTROL = 0x11;
        public const int VK_SEPARATOR = 0x6C;
        public const int VK_MENU = 0x12;


        [DllImport("user32.dll")]
        public static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public DummySendKeysForm()
        {
            InitializeComponent();

            //this.Size = new System.Drawing.Size(0, 0);
            //Show();
        }

        public async void SendKey(Keys keyCode)
        {
            switch (keyCode)
            {
                case Keys.VolumeMute:
                    Api.WinApi.SendMessage(this.Handle, Api.WinApi.WM_APPCOMMAND, this.Handle, (IntPtr)Api.WinApi.APPCOMMAND_VOLUME_MUTE);
                    break;
                case Keys.VolumeUp:
                    Api.WinApi.SendMessage(this.Handle, Api.WinApi.WM_APPCOMMAND, this.Handle, (IntPtr)Api.WinApi.APPCOMMAND_VOLUME_UP);
                    break;
                case Keys.VolumeDown:
                    Api.WinApi.SendMessage(this.Handle, Api.WinApi.WM_APPCOMMAND, this.Handle, (IntPtr)Api.WinApi.APPCOMMAND_VOLUME_DOWN);
                    break;
                case Keys.MediaStop:
                    WinApi.SendMessage(this.Handle, WinApi.WM_APPCOMMAND, this.Handle, (IntPtr)WinApi.APPCOMMAND_MEDIA_STOP);
                    break;
                case Keys.MediaPlayPause:
                    WinApi.SendMessage(this.Handle, WinApi.WM_APPCOMMAND, this.Handle, (IntPtr)WinApi.APPCOMMAND_MEDIA_PLAY_PAUSE);
                    break;
                case Keys.MediaNextTrack:
                    WinApi.SendMessage(this.Handle, WinApi.WM_APPCOMMAND, this.Handle, (IntPtr)WinApi.APPCOMMAND_MEDIA_NEXTTRACK);
                    break;
                case Keys.MediaPreviousTrack:
                    WinApi.SendMessage(this.Handle, WinApi.WM_APPCOMMAND, this.Handle, (IntPtr)WinApi.APPCOMMAND_MEDIA_PREVIOUSTRACK);
                    break;
            }
            //try
            //{


            //    var hwnd = Api.WinApi.GetShellWindow();
            //    IntPtr code = (IntPtr)keyCode;
            //    var hwnd2 = (IntPtr)10204;
            //    var hwnd3 = (IntPtr)20202;
            //    var hwnd4 = (IntPtr)10206;

            //    var hwnd5 = Api.WinApi.FindWindow(null, "UniversalDev - VMware Workstation");

            //    Api.WinApi.SendMessage(hwnd, (int)Api.WinApi.WM_KEYDOWN, code, IntPtr.Zero);
            //    Api.WinApi.SendMessage(hwnd, (int)Api.WinApi.WM_KEYUP, code, IntPtr.Zero);

            //    Api.WinApi.SendMessage(hwnd2, (int)Api.WinApi.WM_KEYDOWN, code, IntPtr.Zero);
            //    Api.WinApi.SendMessage(hwnd2, (int)Api.WinApi.WM_KEYUP, code, IntPtr.Zero);

            //    Api.WinApi.SendMessage(hwnd3, (int)Api.WinApi.WM_KEYDOWN, code, IntPtr.Zero);
            //    Api.WinApi.SendMessage(hwnd3, (int)Api.WinApi.WM_KEYUP, code, IntPtr.Zero);

            //    Api.WinApi.SendMessage(hwnd4, (int)Api.WinApi.WM_KEYDOWN, code, IntPtr.Zero);
            //    Api.WinApi.SendMessage(hwnd4, (int)Api.WinApi.WM_KEYUP, code, IntPtr.Zero);


            //    Api.WinApi.PostMessage(hwnd, Api.WinApi.WM_KEYDOWN, code, IntPtr.Zero);
            //    Api.WinApi.PostMessage(hwnd, Api.WinApi.WM_KEYUP, code, IntPtr.Zero);

            //    Api.WinApi.PostMessage(hwnd2, Api.WinApi.WM_KEYDOWN, code, IntPtr.Zero);
            //    Api.WinApi.PostMessage(hwnd2, Api.WinApi.WM_KEYUP, code, IntPtr.Zero);

            //    Api.WinApi.PostMessage(hwnd3, Api.WinApi.WM_KEYDOWN, code, IntPtr.Zero);
            //    Api.WinApi.PostMessage(hwnd3, Api.WinApi.WM_KEYUP, code, IntPtr.Zero);

            //    Api.WinApi.PostMessage(hwnd4, Api.WinApi.WM_KEYDOWN, code, IntPtr.Zero);
            //    Api.WinApi.PostMessage(hwnd4, Api.WinApi.WM_KEYUP, code, IntPtr.Zero);

            //    return;

            //    var oldCursorPosition = Cursor.Position;
            //    //MoveMouse(new Point(0, 0));
            //    //RelaseVmwareControl();
            //    //Cursor.Position = new Point(0,0);
            //    MoveCursor(new Point(0, 0));
            //    MoveCursor(new Point(1, 1));
            //    MoveCursor(new Point(2, 2));
            //    //Application.DoEvents();
            //    System.Threading.Thread.Sleep(300);
            //    this.Show();
            //    //RelaseVmwareControl();

            //    this.Focus();
            //    //RelaseVmwareControl();

            //    System.Threading.Thread.Sleep(300);
            //    this.TopMost = true;
            //    //RelaseVmwareControl();

            //    System.Threading.Thread.Sleep(300);
            //    SetForegroundWindow(this.Handle);
            //    System.Threading.Thread.Sleep(300);
            //    //Task.Run(() => keybd_event((byte)keyCode, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero));
            //    //keybd_event((byte)keyCode, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);
            //    keybd_event(VK_MEDIA_PLAY_PAUSE, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);
            //    keybd_event((byte)Keys.VolumeMute, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);
            //    SendKeys.Send(keyCode.ToString());
            //    System.Threading.Thread.Sleep(500);
            //    //Cursor.Position = oldCursorPosition;
            //    this.Close();
            //    System.Threading.Thread.Sleep(300);

            //    //if (this.InvokeRequired)
            //    //    this.Invoke(() => { 
            //    //        SendKeys.Send(keyCode.ToString());                
            //    //    });
            //    //else
            //    //    SendKeys.Send(keyCode.ToString());


            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    Debug.WriteLine(ex.Message);
            //    this.Close();
            //}
        }
        private void MoveCursor(Point point)
        {
            // Set the Current cursor, move the cursor's Position,
            // and set its clipping rectangle to the form. 

            this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = point;
            //Cursor.Clip = new Rectangle(this.Location, this.Size);
            Cursor.Clip = Screen.PrimaryScreen.Bounds;
        }
        private void RelaseVmwareControl()
        {
            // Simulating a Ctrl+Alt keystrokes
            keybd_event(VK_CONTROL, 0x9d, 0, IntPtr.Zero); //Alt Press
            keybd_event(VK_MENU, 0xb8, 0, IntPtr.Zero); // Tab Press
            keybd_event(VK_MENU, 0xb8, KEYEVENTF_KEYUP, IntPtr.Zero); // Tab Release
            keybd_event(VK_CONTROL, 0x9d, KEYEVENTF_KEYUP, IntPtr.Zero); // Alt Release
        }

        private void MoveMouse(Point point)
        {
            while (Cursor.Position.X < point.X)
                Cursor.Position = new Point(Cursor.Position.X + 1, Cursor.Position.Y);
            while (Cursor.Position.X > point.X)
                Cursor.Position = new Point(Cursor.Position.X - 1, Cursor.Position.Y);
            while (Cursor.Position.Y < point.Y)
                Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y + 1);
            while (Cursor.Position.Y > point.Y)
                Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y - 1);


        }

        private void DummySendKeysForm_Load(object sender, EventArgs e)
        {

        }
    }
}
