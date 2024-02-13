using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSleepWithRunningVM.Helpers
{
    internal static class SleepSettingsHelper
    {
        private static string vmRunPath;

        public static string VmRunPath
        {
            get
            {
                if (vmRunPath == null || vmRunPath == "")
                {
                    vmRunPath = GetVmRunPath();
                }
                return vmRunPath;
            }
            set
            {
                vmRunPath = value;
            }
        }

        internal static Models.SleepSettingsModel LoadSettings()
        {
            Models.SleepSettingsModel sleepSettings;
            if (Properties.Settings.Default.UpgradeNeeded)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
                Properties.Settings.Default.UpgradeNeeded = false;
                Properties.Settings.Default.Save();
            }

            if (Properties.Settings.Default.SleepSettings == null || Properties.Settings.Default.SleepSettings == "")
            {
                sleepSettings = new Models.SleepSettingsModel()
                {
                    VmWareRunning = true,
                    VmWareGuestRunning = true,
                    SignalRServerEnabled = false,
                    SignalRServerPort = "50443"
                };
                Properties.Settings.Default.SleepSettings = JsonConvert.SerializeObject(sleepSettings);
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }
            else
            {
                sleepSettings = JsonConvert.DeserializeObject<Models.SleepSettingsModel>(Properties.Settings.Default.SleepSettings);
            }

            return sleepSettings;
        }
        internal static void SaveSettings(Models.SleepSettingsModel sleepSettings)
        {
            Properties.Settings.Default.SleepSettings = JsonConvert.SerializeObject(sleepSettings);
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
        }
        internal static bool DoPreventSleep()
        {
            try
            {
                var sleepSettings = Helpers.SleepSettingsHelper.LoadSettings();
                if (sleepSettings == null)
                    return false;
                if (sleepSettings.VmWareRunning == false)
                    return false;
                if (sleepSettings.VmWareGuestRunning == true && IsVmWareGuestRunning() == false)
                    return false;

                return IsVmWareRunning();
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private static bool IsVmWareRunning()
        {
            var currentSessionID = Process.GetCurrentProcess().SessionId;
            var vmWareProcs = Process.GetProcessesByName("vmware-vmx").Where(p => p.SessionId == currentSessionID);
            return vmWareProcs.Count() > 0;
        }
        private static bool IsVmWareGuestRunning()
        {
            var vmRunPath = VmRunPath;
            if (vmRunPath == null || VmRunPath == "")
                return false;

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = vmRunPath,
                    Arguments = "list",
                    WorkingDirectory = new FileInfo(vmRunPath).Directory.FullName,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                // First line of output expected from vmrun.exe is: "Total running VMs: n", where n = number of running VMs.
                string line = proc.StandardOutput.ReadLine();
                //Console.WriteLine(line);
                Debug.WriteLine(line);

                if (line.Contains("Total running VMs:"))
                {
                    var totalVMsParts = line.Split(':');
                    if (totalVMsParts.Length > 1)
                    {
                        return Convert.ToInt32(totalVMsParts[1].Trim()) > 0;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public static string GetVmRunPath()
        {
            var vmrunPaths = Directory.GetFiles($@"C:\Program Files (x86)\VMware\", "vmrun.exe", SearchOption.AllDirectories);
            if (vmrunPaths.Length > 0)
            {
                return vmrunPaths[0];
            }

            vmrunPaths = Directory.GetFiles($@"C:\Program Files\VMware\", "vmrun.exe", SearchOption.AllDirectories);
            if (vmrunPaths.Length > 0)
            {
                return vmrunPaths[0];
            }

            throw new Exception("vmrun.exe not found");
            return "";
        }

    }
}
