﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NoSleepWithRunningVM.Models
{
    internal class SleepSettingsModel
    {
        public bool IfVmWareRunning { get; set; }
        public bool VmWareGuestRunning { get; set; }
    }
}