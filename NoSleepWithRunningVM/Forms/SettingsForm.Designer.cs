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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkGuestVmIsRunning = new System.Windows.Forms.CheckBox();
            this.chkVmWareIsRunning = new System.Windows.Forms.CheckBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkEnableGrpcServer = new System.Windows.Forms.CheckBox();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkGuestVmIsRunning);
            this.groupBox1.Controls.Add(this.chkVmWareIsRunning);
            this.groupBox1.Location = new System.Drawing.Point(9, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prevent Sleep When:";
            // 
            // chkGuestVmIsRunning
            // 
            this.chkGuestVmIsRunning.AutoSize = true;
            this.chkGuestVmIsRunning.Location = new System.Drawing.Point(33, 59);
            this.chkGuestVmIsRunning.Name = "chkGuestVmIsRunning";
            this.chkGuestVmIsRunning.Size = new System.Drawing.Size(174, 25);
            this.chkGuestVmIsRunning.TabIndex = 1;
            this.chkGuestVmIsRunning.Text = "and guest is running.";
            this.chkGuestVmIsRunning.UseVisualStyleBackColor = true;
            // 
            // chkVmWareIsRunning
            // 
            this.chkVmWareIsRunning.AutoSize = true;
            this.chkVmWareIsRunning.Location = new System.Drawing.Point(12, 28);
            this.chkVmWareIsRunning.Name = "chkVmWareIsRunning";
            this.chkVmWareIsRunning.Size = new System.Drawing.Size(251, 25);
            this.chkVmWareIsRunning.TabIndex = 0;
            this.chkVmWareIsRunning.Text = "VMWare Workstation is running";
            this.chkVmWareIsRunning.UseVisualStyleBackColor = true;
            this.chkVmWareIsRunning.CheckedChanged += new System.EventHandler(this.chkVmWareIsRunning_CheckedChanged);
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.Location = new System.Drawing.Point(283, 219);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(77, 30);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(366, 219);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(77, 30);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chkEnableGrpcServer);
            this.groupBox2.Controls.Add(this.txtServerPort);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(9, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(434, 104);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "gRPC Server (Listens for Volume & Media Keys from Guest)";
            // 
            // chkEnableGrpcServer
            // 
            this.chkEnableGrpcServer.AutoSize = true;
            this.chkEnableGrpcServer.Location = new System.Drawing.Point(12, 30);
            this.chkEnableGrpcServer.Name = "chkEnableGrpcServer";
            this.chkEnableGrpcServer.Size = new System.Drawing.Size(124, 25);
            this.chkEnableGrpcServer.TabIndex = 5;
            this.chkEnableGrpcServer.Text = "Enable Server";
            this.chkEnableGrpcServer.UseVisualStyleBackColor = true;
            this.chkEnableGrpcServer.CheckedChanged += new System.EventHandler(this.chkEnableGrpcServer_CheckedChanged);
            // 
            // txtServerPort
            // 
            this.txtServerPort.Enabled = false;
            this.txtServerPort.Location = new System.Drawing.Point(79, 61);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(69, 29);
            this.txtServerPort.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port:";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 261);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CancelButton);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(465, 300);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "No-Sleep Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private CheckBox chkGuestVmIsRunning;
        private CheckBox chkVmWareIsRunning;
        private Button OkButton;
        private Button CancelButton;
        private GroupBox groupBox2;
        private CheckBox chkEnableGrpcServer;
        private TextBox txtServerPort;
        private Label label2;
    }
}