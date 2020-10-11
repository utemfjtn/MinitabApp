namespace YAN_MinitabMenu {
    partial class FormAbout {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            this.label1 = new System.Windows.Forms.Label();
            this.tB_AddInPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tB_AppPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tB_Handle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tB_LastError = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tB_Version = new System.Windows.Forms.TextBox();
            this.bt_Cancel = new System.Windows.Forms.Button();
            this.bt_OK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cB_UserControl = new System.Windows.Forms.CheckBox();
            this.tB_Status = new System.Windows.Forms.TextBox();
            this.cB_Visible = new System.Windows.Forms.CheckBox();
            this.cB_Interactive = new System.Windows.Forms.CheckBox();
            this.cB_DisplayAlerts = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cB_DefaultOutputFileType = new System.Windows.Forms.ComboBox();
            this.tB_ClientMissingValueDateTime = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tB_ClientMissingValueNumeric = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tB_DefaultFilePath = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "AddInPath ";
            // 
            // tB_AddInPath
            // 
            this.tB_AddInPath.Location = new System.Drawing.Point(96, 36);
            this.tB_AddInPath.Name = "tB_AddInPath";
            this.tB_AddInPath.ReadOnly = true;
            this.tB_AddInPath.Size = new System.Drawing.Size(586, 25);
            this.tB_AddInPath.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "AppPath ";
            // 
            // tB_AppPath
            // 
            this.tB_AppPath.Location = new System.Drawing.Point(96, 68);
            this.tB_AppPath.Name = "tB_AppPath";
            this.tB_AppPath.ReadOnly = true;
            this.tB_AppPath.Size = new System.Drawing.Size(586, 25);
            this.tB_AppPath.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Handle";
            // 
            // tB_Handle
            // 
            this.tB_Handle.Location = new System.Drawing.Point(96, 100);
            this.tB_Handle.Name = "tB_Handle";
            this.tB_Handle.ReadOnly = true;
            this.tB_Handle.Size = new System.Drawing.Size(179, 25);
            this.tB_Handle.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "LastError";
            // 
            // tB_LastError
            // 
            this.tB_LastError.Location = new System.Drawing.Point(96, 132);
            this.tB_LastError.Name = "tB_LastError";
            this.tB_LastError.ReadOnly = true;
            this.tB_LastError.Size = new System.Drawing.Size(179, 25);
            this.tB_LastError.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Version";
            // 
            // tB_Version
            // 
            this.tB_Version.Location = new System.Drawing.Point(96, 164);
            this.tB_Version.Name = "tB_Version";
            this.tB_Version.ReadOnly = true;
            this.tB_Version.Size = new System.Drawing.Size(179, 25);
            this.tB_Version.TabIndex = 1;
            // 
            // bt_Cancel
            // 
            this.bt_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_Cancel.Location = new System.Drawing.Point(107, 490);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.Size = new System.Drawing.Size(113, 52);
            this.bt_Cancel.TabIndex = 2;
            this.bt_Cancel.Text = "&Cancel";
            this.bt_Cancel.UseVisualStyleBackColor = true;
            this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
            // 
            // bt_OK
            // 
            this.bt_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_OK.Location = new System.Drawing.Point(521, 490);
            this.bt_OK.Name = "bt_OK";
            this.bt_OK.Size = new System.Drawing.Size(113, 52);
            this.bt_OK.TabIndex = 2;
            this.bt_OK.Text = "&OK";
            this.bt_OK.UseVisualStyleBackColor = true;
            this.bt_OK.Click += new System.EventHandler(this.bt_OK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cB_UserControl);
            this.groupBox1.Controls.Add(this.tB_Status);
            this.groupBox1.Controls.Add(this.cB_Visible);
            this.groupBox1.Controls.Add(this.tB_Version);
            this.groupBox1.Controls.Add(this.cB_Interactive);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cB_DisplayAlerts);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tB_AddInPath);
            this.groupBox1.Controls.Add(this.tB_LastError);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tB_Handle);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tB_AppPath);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(14, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(688, 262);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "System";
            // 
            // cB_UserControl
            // 
            this.cB_UserControl.AutoSize = true;
            this.cB_UserControl.Location = new System.Drawing.Point(549, 168);
            this.cB_UserControl.Name = "cB_UserControl";
            this.cB_UserControl.Size = new System.Drawing.Size(117, 19);
            this.cB_UserControl.TabIndex = 2;
            this.cB_UserControl.Text = "UserControl";
            this.cB_UserControl.UseVisualStyleBackColor = true;
            // 
            // tB_Status
            // 
            this.tB_Status.Location = new System.Drawing.Point(96, 198);
            this.tB_Status.Name = "tB_Status";
            this.tB_Status.ReadOnly = true;
            this.tB_Status.Size = new System.Drawing.Size(179, 25);
            this.tB_Status.TabIndex = 1;
            // 
            // cB_Visible
            // 
            this.cB_Visible.AutoSize = true;
            this.cB_Visible.Enabled = false;
            this.cB_Visible.Location = new System.Drawing.Point(549, 199);
            this.cB_Visible.Name = "cB_Visible";
            this.cB_Visible.Size = new System.Drawing.Size(85, 19);
            this.cB_Visible.TabIndex = 2;
            this.cB_Visible.Text = "Visible";
            this.cB_Visible.UseVisualStyleBackColor = true;
            // 
            // cB_Interactive
            // 
            this.cB_Interactive.AutoSize = true;
            this.cB_Interactive.Location = new System.Drawing.Point(549, 137);
            this.cB_Interactive.Name = "cB_Interactive";
            this.cB_Interactive.Size = new System.Drawing.Size(117, 19);
            this.cB_Interactive.TabIndex = 2;
            this.cB_Interactive.Text = "Interactive";
            this.cB_Interactive.UseVisualStyleBackColor = true;
            // 
            // cB_DisplayAlerts
            // 
            this.cB_DisplayAlerts.AutoSize = true;
            this.cB_DisplayAlerts.Location = new System.Drawing.Point(549, 106);
            this.cB_DisplayAlerts.Name = "cB_DisplayAlerts";
            this.cB_DisplayAlerts.Size = new System.Drawing.Size(133, 19);
            this.cB_DisplayAlerts.TabIndex = 2;
            this.cB_DisplayAlerts.Text = "DisplayAlerts";
            this.cB_DisplayAlerts.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 203);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "Status";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cB_DefaultOutputFileType);
            this.groupBox3.Controls.Add(this.tB_ClientMissingValueDateTime);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.tB_ClientMissingValueNumeric);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.tB_DefaultFilePath);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Location = new System.Drawing.Point(14, 292);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(688, 173);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Options";
            // 
            // cB_DefaultOutputFileType
            // 
            this.cB_DefaultOutputFileType.FormattingEnabled = true;
            this.cB_DefaultOutputFileType.Location = new System.Drawing.Point(228, 129);
            this.cB_DefaultOutputFileType.Name = "cB_DefaultOutputFileType";
            this.cB_DefaultOutputFileType.Size = new System.Drawing.Size(253, 23);
            this.cB_DefaultOutputFileType.TabIndex = 2;
            // 
            // tB_ClientMissingValueDateTime
            // 
            this.tB_ClientMissingValueDateTime.Location = new System.Drawing.Point(228, 30);
            this.tB_ClientMissingValueDateTime.Name = "tB_ClientMissingValueDateTime";
            this.tB_ClientMissingValueDateTime.Size = new System.Drawing.Size(454, 25);
            this.tB_ClientMissingValueDateTime.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(215, 15);
            this.label12.TabIndex = 0;
            this.label12.Text = "ClientMissingValueDateTime";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 65);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(207, 15);
            this.label15.TabIndex = 0;
            this.label15.Text = "ClientMissingValueNumeric";
            // 
            // tB_ClientMissingValueNumeric
            // 
            this.tB_ClientMissingValueNumeric.Location = new System.Drawing.Point(228, 62);
            this.tB_ClientMissingValueNumeric.Name = "tB_ClientMissingValueNumeric";
            this.tB_ClientMissingValueNumeric.Size = new System.Drawing.Size(454, 25);
            this.tB_ClientMissingValueNumeric.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 129);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(175, 15);
            this.label16.TabIndex = 0;
            this.label16.Text = "DefaultOutputFileType";
            // 
            // tB_DefaultFilePath
            // 
            this.tB_DefaultFilePath.Location = new System.Drawing.Point(228, 94);
            this.tB_DefaultFilePath.Name = "tB_DefaultFilePath";
            this.tB_DefaultFilePath.Size = new System.Drawing.Size(454, 25);
            this.tB_DefaultFilePath.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 97);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(127, 15);
            this.label17.TabIndex = 0;
            this.label17.Text = "DefaultFilePath";
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 570);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bt_OK);
            this.Controls.Add(this.bt_Cancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About            Addin Powered by YAN.Qian 2020-10-09";
            this.Load += new System.EventHandler(this.FormAbout_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormAbout_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tB_AddInPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tB_AppPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tB_Handle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tB_LastError;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tB_Version;
        private System.Windows.Forms.Button bt_Cancel;
        private System.Windows.Forms.Button bt_OK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tB_ClientMissingValueDateTime;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tB_ClientMissingValueNumeric;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tB_DefaultFilePath;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tB_Status;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox cB_UserControl;
        private System.Windows.Forms.CheckBox cB_Visible;
        private System.Windows.Forms.CheckBox cB_Interactive;
        private System.Windows.Forms.CheckBox cB_DisplayAlerts;
        private System.Windows.Forms.ComboBox cB_DefaultOutputFileType;
    }
}