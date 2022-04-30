using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoSleepWithRunningVM.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            var sleepSettings = JsonConvert.DeserializeObject<Models.SleepSettingsModel>(Properties.Settings.Default.SleepSettings);
            chkVmWareIsRunning.Checked = sleepSettings.VmWareRunning;
            chkGuestVmIsRunning.Checked = sleepSettings.VmWareGuestRunning;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Helpers.SleepSettingsHelper.SaveSettings(new Models.SleepSettingsModel()
            {
                VmWareRunning = chkVmWareIsRunning.Checked,
                VmWareGuestRunning = chkGuestVmIsRunning.Checked
            });
            this.Close();
        }

        private void chkVmWareIsRunning_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVmWareIsRunning.Checked == false)
            {
                chkGuestVmIsRunning.Checked = false;
            }
            chkGuestVmIsRunning.Enabled = chkVmWareIsRunning.Checked;
        }
    }
}
