using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuestKeyHooker.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private async void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            //var gRpcClient = new Services.GrpcClientService(Properties.Settings.Default.ServiceIp);
            bool isConnected = await Services.GrpcClientService.CanConnectAsync(txtServerIp.Text, txtServerPort.Text);

            if (!isConnected)
            {
                var dlgResult = MessageBox.Show("Unable to connect", "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Properties.Settings.Default.ServiceIp = txtServerIp.Text;
                Properties.Settings.Default.ServicePort = txtServerPort.Text;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();

                this.Close();
            }
        }
    }
}
