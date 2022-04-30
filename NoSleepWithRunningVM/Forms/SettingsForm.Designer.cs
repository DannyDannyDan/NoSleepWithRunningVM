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
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.chkGuestVmIsRunning = new System.Windows.Forms.CheckBox();
            this.chkVmWareIsRunning = new System.Windows.Forms.CheckBox();
            this.btnTestSendKeys = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTestSendKeys);
            this.groupBox1.Controls.Add(this.OkButton);
            this.groupBox1.Controls.Add(this.CancelButton);
            this.groupBox1.Controls.Add(this.chkGuestVmIsRunning);
            this.groupBox1.Controls.Add(this.chkVmWareIsRunning);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(349, 235);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prevent Sleep When:";
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.Location = new System.Drawing.Point(183, 193);
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
            this.CancelButton.Location = new System.Drawing.Point(266, 193);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(77, 30);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
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
            // 
            // btnTestSendKeys
            // 
            this.btnTestSendKeys.Location = new System.Drawing.Point(12, 125);
            this.btnTestSendKeys.Name = "btnTestSendKeys";
            this.btnTestSendKeys.Size = new System.Drawing.Size(92, 34);
            this.btnTestSendKeys.TabIndex = 1;
            this.btnTestSendKeys.Text = "Send Keys";
            this.btnTestSendKeys.UseVisualStyleBackColor = true;
            this.btnTestSendKeys.Click += new System.EventHandler(this.btnTestSendKeys_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 235);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "No-Sleep Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private CheckBox chkGuestVmIsRunning;
        private CheckBox chkVmWareIsRunning;
        private Button OkButton;
        private Button CancelButton;
        private Button btnTestSendKeys;
    }
}