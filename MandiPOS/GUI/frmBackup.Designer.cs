namespace MandiPOS.GUI
{
    partial class frmBackup
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
            this.uiRadioButton2 = new Janus.Windows.EditControls.UIRadioButton();
            this.rbDefault = new Janus.Windows.EditControls.UIRadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.txtTargetLoation = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uiButton2 = new Janus.Windows.EditControls.UIButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.rbRemoveable = new Janus.Windows.EditControls.UIRadioButton();
            this.comboBoxDrives = new Janus.Windows.EditControls.UIComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.comboBoxDrives);
            this.groupBox1.Controls.Add(this.rbRemoveable);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.uiRadioButton2);
            this.groupBox1.Controls.Add(this.rbDefault);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(10, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(439, 193);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Backup Setting";
            // 
            // uiRadioButton2
            // 
            this.uiRadioButton2.Location = new System.Drawing.Point(110, 17);
            this.uiRadioButton2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uiRadioButton2.Name = "uiRadioButton2";
            this.uiRadioButton2.Size = new System.Drawing.Size(127, 19);
            this.uiRadioButton2.TabIndex = 1;
            this.uiRadioButton2.Text = "Selected Location";
            this.uiRadioButton2.CheckedChanged += new System.EventHandler(this.uiRadioButton2_CheckedChanged);
            // 
            // rbDefault
            // 
            this.rbDefault.Checked = true;
            this.rbDefault.Location = new System.Drawing.Point(4, 17);
            this.rbDefault.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbDefault.Name = "rbDefault";
            this.rbDefault.Size = new System.Drawing.Size(100, 19);
            this.rbDefault.TabIndex = 0;
            this.rbDefault.TabStop = true;
            this.rbDefault.Text = "Default Location";
            this.rbDefault.CheckedChanged += new System.EventHandler(this.uiRadioButton1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.uiButton1);
            this.groupBox2.Controls.Add(this.txtTargetLoation);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(3, 66);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(431, 93);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Backup Location";
            // 
            // uiButton1
            // 
            this.uiButton1.Location = new System.Drawing.Point(362, 57);
            this.uiButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(68, 31);
            this.uiButton1.TabIndex = 2;
            this.uiButton1.Text = "Browse";
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // txtTargetLoation
            // 
            this.txtTargetLoation.Location = new System.Drawing.Point(8, 34);
            this.txtTargetLoation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTargetLoation.Name = "txtTargetLoation";
            this.txtTargetLoation.Size = new System.Drawing.Size(422, 20);
            this.txtTargetLoation.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selected Path";
            // 
            // uiButton2
            // 
            this.uiButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uiButton2.Location = new System.Drawing.Point(376, 213);
            this.uiButton2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(68, 31);
            this.uiButton2.TabIndex = 3;
            this.uiButton2.Text = "Backup";
            this.uiButton2.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.uiButton2.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(4, 163);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(137, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Open Backup Directory";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // rbRemoveable
            // 
            this.rbRemoveable.Location = new System.Drawing.Point(241, 17);
            this.rbRemoveable.Margin = new System.Windows.Forms.Padding(2);
            this.rbRemoveable.Name = "rbRemoveable";
            this.rbRemoveable.Size = new System.Drawing.Size(127, 19);
            this.rbRemoveable.TabIndex = 2;
            this.rbRemoveable.Text = "To Removeable Drive";
            // 
            // comboBoxDrives
            // 
            this.comboBoxDrives.Location = new System.Drawing.Point(241, 41);
            this.comboBoxDrives.Name = "comboBoxDrives";
            this.comboBoxDrives.Size = new System.Drawing.Size(193, 20);
            this.comboBoxDrives.TabIndex = 3;
            // 
            // frmBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 254);
            this.Controls.Add(this.uiButton2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBackup";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backup";
            this.Load += new System.EventHandler(this.frmBackup_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Janus.Windows.EditControls.UIRadioButton rbDefault;
        private Janus.Windows.EditControls.UIRadioButton uiRadioButton2;
        private System.Windows.Forms.GroupBox groupBox2;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private Janus.Windows.GridEX.EditControls.EditBox txtTargetLoation;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.EditControls.UIButton uiButton2;
        private System.Windows.Forms.CheckBox checkBox1;
        private Janus.Windows.EditControls.UIRadioButton rbRemoveable;
        private Janus.Windows.EditControls.UIComboBox comboBoxDrives;
    }
}