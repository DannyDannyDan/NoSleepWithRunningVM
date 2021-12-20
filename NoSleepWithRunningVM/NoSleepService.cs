using Microsoft.Win32;
using NoSleepWithRunningVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSleepWithRunningVM
{
    internal class NoSleepService
    {
        System.Timers.Timer _stayAwakeTimer;
        private readonly SleepSettingsModel _sleepSettings;
        public event EventHandler<bool> PreventingSleep;
        public NoSleepService()
        {
            _stayAwakeTimer = new System.Timers.Timer(6 * 1000);
            _stayAwakeTimer.Elapsed += _stayAwakeTimer_Elapsed;
        }


        private void _stayAwakeTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            UpdateSleepMode();
        }


        internal void PreventSleep()
        {
            UpdateSleepMode();

            _stayAwakeTimer.Start();
        }

        private void UpdateSleepMode()
        {
            if (Helpers.SleepSettingsHelper.DoPreventSleep())
            {
                // TODO: add code here to prevent sleep!
                Helpers.PreventSleepHelper.PreventSleep();
                PreventingSleep?.Invoke(this, true);
            }
            else
            {
                Helpers.PreventSleepHelper.AllowSleep();
                PreventingSleep?.Invoke(this, false);
            }

        }

    }
}
