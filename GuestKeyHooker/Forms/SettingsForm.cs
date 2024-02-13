using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GuestKeyHooker.Services;

namespace GuestKeyHooker.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            txtServerIp.Text = GuestKeyHooker.Properties.Settings.Default.ServiceIp;
            txtServerPort.Text = GuestKeyHooker.Properties.Settings.Default.ServicePort;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            try
            {
                GuestKeyHooker.Properties.Settings.Default.ServiceIp = txtServerIp.Text;
                GuestKeyHooker.Properties.Settings.Default.ServicePort = txtServerPort.Text;
                GuestKeyHooker.Properties.Settings.Default.Save();
                GuestKeyHooker.Properties.Settings.Default.Reload();

                Program.SignalRClientService = new SignalRClientService($"http://{txtServerIp.Text}:{txtServerPort.Text}/commandhub");
                this.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
