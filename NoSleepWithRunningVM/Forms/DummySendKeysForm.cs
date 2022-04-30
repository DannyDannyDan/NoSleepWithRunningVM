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
        public DummySendKeysForm()
        {
            InitializeComponent();
        }

        //public async void SendKey(Keys keyCode)
        //{
        //    switch (keyCode)
        //    {
        //        case Keys.VolumeMute:
        //            await Task.FromResult(WinApi.SendMessage(this.Handle, Api.WinApi.WM_APPCOMMAND, this.Handle, (IntPtr)Api.WinApi.APPCOMMAND_VOLUME_MUTE));
        //            break;
        //        case Keys.VolumeUp:
        //            await Task.FromResult(WinApi.SendMessage(this.Handle, Api.WinApi.WM_APPCOMMAND, this.Handle, (IntPtr)Api.WinApi.APPCOMMAND_VOLUME_UP));
        //            break;
        //        case Keys.VolumeDown:
        //            await Task.FromResult(WinApi.SendMessage(this.Handle, Api.WinApi.WM_APPCOMMAND, this.Handle, (IntPtr)Api.WinApi.APPCOMMAND_VOLUME_DOWN));
        //            break;
        //        case Keys.MediaStop:
        //            await Task.FromResult(WinApi.SendMessage(this.Handle, WinApi.WM_APPCOMMAND, this.Handle, (IntPtr)WinApi.APPCOMMAND_MEDIA_STOP));
        //            break;
        //        case Keys.MediaPlayPause:
        //            await Task.FromResult(WinApi.SendMessage(this.Handle, WinApi.WM_APPCOMMAND, this.Handle, (IntPtr)WinApi.APPCOMMAND_MEDIA_PLAY_PAUSE));
        //            break;
        //        case Keys.MediaNextTrack:
        //            await Task.FromResult(WinApi.SendMessage(this.Handle, WinApi.WM_APPCOMMAND, this.Handle, (IntPtr)WinApi.APPCOMMAND_MEDIA_NEXTTRACK));
        //            break;
        //        case Keys.MediaPreviousTrack:
        //            await Task.FromResult(WinApi.SendMessage(this.Handle, WinApi.WM_APPCOMMAND, this.Handle, (IntPtr)WinApi.APPCOMMAND_MEDIA_PREVIOUSTRACK));
        //            break;
        //    }
        //}
    }
}
