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
            this.uiRadioButton1 = new Janus.Windows.EditControls.UIRadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.editBox1 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uiButton2 = new Janus.Windows.EditControls.UIButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uiRadioButton2);
            this.groupBox1.Controls.Add(this.uiRadioButton1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 65);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Backup Setting";
            // 
            // uiRadioButton2
            // 
            this.uiRadioButton2.Location = new System.Drawing.Point(146, 21);
            this.uiRadioButton2.Name = "uiRadioButton2";
            this.uiRadioButton2.Size = new System.Drawing.Size(218, 23);
            this.uiRadioButton2.TabIndex = 1;
            this.uiRadioButton2.Text = "Selected Location";
            this.uiRadioButton2.CheckedChanged += new System.EventHandler(this.uiRadioButton2_CheckedChanged);
            // 
            // uiRadioButton1
            // 
            this.uiRadioButton1.Checked = true;
            this.uiRadioButton1.Location = new System.Drawing.Point(6, 21);
            this.uiRadioButton1.Name = "uiRadioButton1";
            this.uiRadioButton1.Size = new System.Drawing.Size(134, 23);
            this.uiRadioButton1.TabIndex = 0;
            this.uiRadioButton1.TabStop = true;
            this.uiRadioButton1.Text = "Default Location";
            this.uiRadioButton1.CheckedChanged += new System.EventHandler(this.uiRadioButton1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.uiButton1);
            this.groupBox2.Controls.Add(this.editBox1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(19, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(579, 114);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Backup Location";
            // 
            // uiButton1
            // 
            this.uiButton1.Location = new System.Drawing.Point(482, 70);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(91, 38);
            this.uiButton1.TabIndex = 2;
            this.uiButton1.Text = "Browse";
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // editBox1
            // 
            this.editBox1.Location = new System.Drawing.Point(10, 42);
            this.editBox1.Name = "editBox1";
            this.editBox1.Size = new System.Drawing.Size(563, 22);
            this.editBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selected Path";
            // 
            // uiButton2
            // 
            this.uiButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uiButton2.Location = new System.Drawing.Point(501, 202);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(91, 38);
            this.uiButton2.TabIndex = 3;
            this.uiButton2.Text = "Backup";
            this.uiButton2.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.uiButton2.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(19, 202);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(168, 20);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Open Backup Directory";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // frmBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 252);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.uiButton2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBackup";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backup";
            this.Load += new System.EventHandler(this.frmBackup_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Janus.Windows.EditControls.UIRadioButton uiRadioButton1;
        private Janus.Windows.EditControls.UIRadioButton uiRadioButton2;
        private System.Windows.Forms.GroupBox groupBox2;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private Janus.Windows.GridEX.EditControls.EditBox editBox1;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.EditControls.UIButton uiButton2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}