using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NoSleepWithRunningVM.Models
{
    internal class SleepSettingsModel
    {
        public bool VmWareRunning { get; set; }
        public bool VmWareGuestRunning { get; set; }
        public bool GrpcServerEnabled { get; set; }
        public string GrpcServerPort { get; set; } = "";
    }
}
