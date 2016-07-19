namespace MultiWiiVJoy
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnConnect = new System.Windows.Forms.Button();
            this.cbxPortNames = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cbxBaudRate = new System.Windows.Forms.ComboBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.timerRc = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelVJoy = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxThrottle = new System.Windows.Forms.CheckBox();
            this.cbxYaw = new System.Windows.Forms.CheckBox();
            this.cbxPitch = new System.Windows.Forms.CheckBox();
            this.cbxRoll = new System.Windows.Forms.CheckBox();
            this.cbxInterval = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkExpoFC = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblRateYaw = new System.Windows.Forms.Label();
            this.lblRatePitch = new System.Windows.Forms.Label();
            this.lblRateRoll = new System.Windows.Forms.Label();
            this.displayRcValueRoll = new MultiWiiVJoy.DisplayRcValue();
            this.displayRcValuePitch = new MultiWiiVJoy.DisplayRcValue();
            this.displayRcValueYaw = new MultiWiiVJoy.DisplayRcValue();
            this.displayRcValueThrottle = new MultiWiiVJoy.DisplayRcValue();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(11, 11);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(83, 23);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cbxPortNames
            // 
            this.cbxPortNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPortNames.FormattingEnabled = true;
            this.cbxPortNames.Location = new System.Drawing.Point(120, 12);
            this.cbxPortNames.Margin = new System.Windows.Forms.Padding(2);
            this.cbxPortNames.Name = "cbxPortNames";
            this.cbxPortNames.Size = new System.Drawing.Size(92, 21);
            this.cbxPortNames.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(216, 11);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(56, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cbxBaudRate
            // 
            this.cbxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBaudRate.FormattingEnabled = true;
            this.cbxBaudRate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "57600",
            "115200"});
            this.cbxBaudRate.Location = new System.Drawing.Point(276, 13);
            this.cbxBaudRate.Margin = new System.Windows.Forms.Padding(2);
            this.cbxBaudRate.Name = "cbxBaudRate";
            this.cbxBaudRate.Size = new System.Drawing.Size(92, 21);
            this.cbxBaudRate.TabIndex = 4;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(11, 11);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(2);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(83, 23);
            this.btnDisconnect.TabIndex = 5;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Visible = false;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // timerRc
            // 
            this.timerRc.Interval = 10;
            this.timerRc.Tick += new System.EventHandler(this.timerRc_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 103);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Throttle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 123);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Yaw";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 143);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Pitch";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 163);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Roll";
            // 
            // panelVJoy
            // 
            this.panelVJoy.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelVJoy.Location = new System.Drawing.Point(79, 47);
            this.panelVJoy.Margin = new System.Windows.Forms.Padding(2);
            this.panelVJoy.Name = "panelVJoy";
            this.panelVJoy.Size = new System.Drawing.Size(15, 16);
            this.panelVJoy.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 50);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "vJoy Ready";
            // 
            // cbxThrottle
            // 
            this.cbxThrottle.AutoSize = true;
            this.cbxThrottle.Location = new System.Drawing.Point(248, 101);
            this.cbxThrottle.Margin = new System.Windows.Forms.Padding(2);
            this.cbxThrottle.Name = "cbxThrottle";
            this.cbxThrottle.Size = new System.Drawing.Size(15, 14);
            this.cbxThrottle.TabIndex = 21;
            this.cbxThrottle.UseVisualStyleBackColor = true;
            // 
            // cbxYaw
            // 
            this.cbxYaw.AutoSize = true;
            this.cbxYaw.Location = new System.Drawing.Point(248, 121);
            this.cbxYaw.Margin = new System.Windows.Forms.Padding(2);
            this.cbxYaw.Name = "cbxYaw";
            this.cbxYaw.Size = new System.Drawing.Size(15, 14);
            this.cbxYaw.TabIndex = 22;
            this.cbxYaw.UseVisualStyleBackColor = true;
            // 
            // cbxPitch
            // 
            this.cbxPitch.AutoSize = true;
            this.cbxPitch.Location = new System.Drawing.Point(248, 141);
            this.cbxPitch.Margin = new System.Windows.Forms.Padding(2);
            this.cbxPitch.Name = "cbxPitch";
            this.cbxPitch.Size = new System.Drawing.Size(15, 14);
            this.cbxPitch.TabIndex = 23;
            this.cbxPitch.UseVisualStyleBackColor = true;
            // 
            // cbxRoll
            // 
            this.cbxRoll.AutoSize = true;
            this.cbxRoll.Location = new System.Drawing.Point(248, 161);
            this.cbxRoll.Margin = new System.Windows.Forms.Padding(2);
            this.cbxRoll.Name = "cbxRoll";
            this.cbxRoll.Size = new System.Drawing.Size(15, 14);
            this.cbxRoll.TabIndex = 24;
            this.cbxRoll.UseVisualStyleBackColor = true;
            // 
            // cbxInterval
            // 
            this.cbxInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxInterval.FormattingEnabled = true;
            this.cbxInterval.Items.AddRange(new object[] {
            "10",
            "100",
            "200",
            "500"});
            this.cbxInterval.Location = new System.Drawing.Point(276, 45);
            this.cbxInterval.Margin = new System.Windows.Forms.Padding(2);
            this.cbxInterval.Name = "cbxInterval";
            this.cbxInterval.Size = new System.Drawing.Size(92, 21);
            this.cbxInterval.TabIndex = 25;
            this.cbxInterval.SelectedIndexChanged += new System.EventHandler(this.cbxInterval_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(208, 50);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Interval (ms)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(9, 190);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 9);
            this.label7.TabIndex = 27;
            this.label7.Text = "bitWorking 2014";
            // 
            // chkExpoFC
            // 
            this.chkExpoFC.AutoSize = true;
            this.chkExpoFC.Checked = true;
            this.chkExpoFC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExpoFC.Location = new System.Drawing.Point(11, 78);
            this.chkExpoFC.Name = "chkExpoFC";
            this.chkExpoFC.Size = new System.Drawing.Size(125, 17);
            this.chkExpoFC.TabIndex = 28;
            this.chkExpoFC.Text = "Enable Expo from FC";
            this.chkExpoFC.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(234, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Reverse";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(287, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Rate (deg/sec)";
            // 
            // lblRateYaw
            // 
            this.lblRateYaw.AutoSize = true;
            this.lblRateYaw.Location = new System.Drawing.Point(311, 121);
            this.lblRateYaw.Name = "lblRateYaw";
            this.lblRateYaw.Size = new System.Drawing.Size(13, 13);
            this.lblRateYaw.TabIndex = 32;
            this.lblRateYaw.Text = "0";
            // 
            // lblRatePitch
            // 
            this.lblRatePitch.AutoSize = true;
            this.lblRatePitch.Location = new System.Drawing.Point(311, 141);
            this.lblRatePitch.Name = "lblRatePitch";
            this.lblRatePitch.Size = new System.Drawing.Size(13, 13);
            this.lblRatePitch.TabIndex = 33;
            this.lblRatePitch.Text = "0";
            // 
            // lblRateRoll
            // 
            this.lblRateRoll.AutoSize = true;
            this.lblRateRoll.Location = new System.Drawing.Point(311, 161);
            this.lblRateRoll.Name = "lblRateRoll";
            this.lblRateRoll.Size = new System.Drawing.Size(13, 13);
            this.lblRateRoll.TabIndex = 34;
            this.lblRateRoll.Text = "0";
            // 
            // displayRcValueRoll
            // 
            this.displayRcValueRoll.BackColor = System.Drawing.SystemColors.ControlDark;
            this.displayRcValueRoll.Centered = true;
            this.displayRcValueRoll.Location = new System.Drawing.Point(79, 160);
            this.displayRcValueRoll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.displayRcValueRoll.Name = "displayRcValueRoll";
            this.displayRcValueRoll.Size = new System.Drawing.Size(152, 16);
            this.displayRcValueRoll.TabIndex = 14;
            this.displayRcValueRoll.Value = 0;
            // 
            // displayRcValuePitch
            // 
            this.displayRcValuePitch.BackColor = System.Drawing.SystemColors.ControlDark;
            this.displayRcValuePitch.Centered = true;
            this.displayRcValuePitch.Location = new System.Drawing.Point(79, 140);
            this.displayRcValuePitch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.displayRcValuePitch.Name = "displayRcValuePitch";
            this.displayRcValuePitch.Size = new System.Drawing.Size(152, 16);
            this.displayRcValuePitch.TabIndex = 13;
            this.displayRcValuePitch.Value = 0;
            // 
            // displayRcValueYaw
            // 
            this.displayRcValueYaw.BackColor = System.Drawing.SystemColors.ControlDark;
            this.displayRcValueYaw.Centered = true;
            this.displayRcValueYaw.Location = new System.Drawing.Point(79, 120);
            this.displayRcValueYaw.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.displayRcValueYaw.Name = "displayRcValueYaw";
            this.displayRcValueYaw.Size = new System.Drawing.Size(152, 16);
            this.displayRcValueYaw.TabIndex = 12;
            this.displayRcValueYaw.Value = 0;
            // 
            // displayRcValueThrottle
            // 
            this.displayRcValueThrottle.BackColor = System.Drawing.SystemColors.ControlDark;
            this.displayRcValueThrottle.Centered = false;
            this.displayRcValueThrottle.Location = new System.Drawing.Point(79, 100);
            this.displayRcValueThrottle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.displayRcValueThrottle.Name = "displayRcValueThrottle";
            this.displayRcValueThrottle.Size = new System.Drawing.Size(152, 16);
            this.displayRcValueThrottle.TabIndex = 11;
            this.displayRcValueThrottle.Value = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 203);
            this.Controls.Add(this.lblRateRoll);
            this.Controls.Add(this.lblRatePitch);
            this.Controls.Add(this.lblRateYaw);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chkExpoFC);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxInterval);
            this.Controls.Add(this.cbxRoll);
            this.Controls.Add(this.cbxPitch);
            this.Controls.Add(this.cbxYaw);
            this.Controls.Add(this.cbxThrottle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panelVJoy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.displayRcValueRoll);
            this.Controls.Add(this.displayRcValuePitch);
            this.Controls.Add(this.displayRcValueYaw);
            this.Controls.Add(this.displayRcValueThrottle);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.cbxBaudRate);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cbxPortNames);
            this.Controls.Add(this.btnConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "KissFC vJoy";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cbxPortNames;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cbxBaudRate;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Timer timerRc;
        private DisplayRcValue displayRcValueThrottle;
        private DisplayRcValue displayRcValueYaw;
        private DisplayRcValue displayRcValuePitch;
        private DisplayRcValue displayRcValueRoll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelVJoy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbxThrottle;
        private System.Windows.Forms.CheckBox cbxYaw;
        private System.Windows.Forms.CheckBox cbxPitch;
        private System.Windows.Forms.CheckBox cbxRoll;
        private System.Windows.Forms.ComboBox cbxInterval;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkExpoFC;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblRateYaw;
        private System.Windows.Forms.Label lblRatePitch;
        private System.Windows.Forms.Label lblRateRoll;
    }
}

