namespace NoSleepWithRunningVM.Forms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            chkGuestVmIsRunning = new CheckBox();
            chkVmWareIsRunning = new CheckBox();
            OkButton = new Button();
            CancelButton = new Button();
            groupBox2 = new GroupBox();
            chkEnableSignalRServer = new CheckBox();
            txtServerPort = new TextBox();
            label2 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(chkGuestVmIsRunning);
            groupBox1.Controls.Add(chkVmWareIsRunning);
            groupBox1.Location = new Point(9, 9);
            groupBox1.Margin = new Padding(0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(481, 92);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Prevent Sleep When:";
            // 
            // chkGuestVmIsRunning
            // 
            chkGuestVmIsRunning.AutoSize = true;
            chkGuestVmIsRunning.Location = new Point(33, 59);
            chkGuestVmIsRunning.Name = "chkGuestVmIsRunning";
            chkGuestVmIsRunning.Size = new Size(174, 25);
            chkGuestVmIsRunning.TabIndex = 1;
            chkGuestVmIsRunning.Text = "and guest is running.";
            chkGuestVmIsRunning.UseVisualStyleBackColor = true;
            // 
            // chkVmWareIsRunning
            // 
            chkVmWareIsRunning.AutoSize = true;
            chkVmWareIsRunning.Location = new Point(12, 28);
            chkVmWareIsRunning.Name = "chkVmWareIsRunning";
            chkVmWareIsRunning.Size = new Size(251, 25);
            chkVmWareIsRunning.TabIndex = 0;
            chkVmWareIsRunning.Text = "VMWare Workstation is running";
            chkVmWareIsRunning.UseVisualStyleBackColor = true;
            chkVmWareIsRunning.CheckedChanged += chkVmWareIsRunning_CheckedChanged;
            // 
            // OkButton
            // 
            OkButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            OkButton.Location = new Point(330, 219);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(77, 30);
            OkButton.TabIndex = 2;
            OkButton.Text = "OK";
            OkButton.UseVisualStyleBackColor = true;
            OkButton.Click += OkButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CancelButton.Location = new Point(413, 219);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(77, 30);
            CancelButton.TabIndex = 2;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(chkEnableSignalRServer);
            groupBox2.Controls.Add(txtServerPort);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(9, 106);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(481, 104);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "SignalR Server (Listens for Volume & Media Keys from Guest)";
            // 
            // chkEnableSignalRServer
            // 
            chkEnableSignalRServer.AutoSize = true;
            chkEnableSignalRServer.Location = new Point(12, 30);
            chkEnableSignalRServer.Name = "chkEnableSignalRServer";
            chkEnableSignalRServer.Size = new Size(124, 25);
            chkEnableSignalRServer.TabIndex = 5;
            chkEnableSignalRServer.Text = "Enable Server";
            chkEnableSignalRServer.UseVisualStyleBackColor = true;
            chkEnableSignalRServer.CheckedChanged += chkEnableSignalRServer_CheckedChanged;
            // 
            // txtServerPort
            // 
            txtServerPort.Enabled = false;
            txtServerPort.Location = new Point(79, 61);
            txtServerPort.Name = "txtServerPort";
            txtServerPort.Size = new Size(69, 29);
            txtServerPort.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 64);
            label2.Name = "label2";
            label2.Size = new Size(41, 21);
            label2.TabIndex = 3;
            label2.Text = "Port:";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 261);
            Controls.Add(groupBox2);
            Controls.Add(OkButton);
            Controls.Add(groupBox1);
            Controls.Add(CancelButton);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimumSize = new Size(465, 300);
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "No-Sleep Settings";
            Load += SettingsForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private CheckBox chkGuestVmIsRunning;
        private CheckBox chkVmWareIsRunning;
        private Button OkButton;
        private Button CancelButton;
        private GroupBox groupBox2;
        private CheckBox chkEnableSignalRServer;
        private TextBox txtServerPort;
        private Label label2;
    }
}