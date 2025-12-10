namespace MandiPOS.GUI
{
    partial class frmDateChanger
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
            this.label1 = new System.Windows.Forms.Label();
            this.calendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.calendarCombo2 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label2 = new System.Windows.Forms.Label();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(234, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "موجودہ تاریخ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // calendarCombo1
            // 
            this.calendarCombo1.CustomFormat = "dd-MMM-yyyy";
            this.calendarCombo1.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            this.calendarCombo1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calendarCombo1.Location = new System.Drawing.Point(88, 18);
            this.calendarCombo1.Name = "calendarCombo1";
            this.calendarCombo1.ReadOnly = true;
            this.calendarCombo1.Size = new System.Drawing.Size(140, 27);
            this.calendarCombo1.TabIndex = 1;
            // 
            // calendarCombo2
            // 
            this.calendarCombo2.CustomFormat = "dd-MMM-yyyy";
            this.calendarCombo2.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            this.calendarCombo2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calendarCombo2.Location = new System.Drawing.Point(88, 65);
            this.calendarCombo2.Name = "calendarCombo2";
            this.calendarCombo2.Size = new System.Drawing.Size(140, 27);
            this.calendarCombo2.TabIndex = 3;
            this.calendarCombo2.ValueChanged += new System.EventHandler(this.calendarCombo2_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(234, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 47);
            this.label2.TabIndex = 2;
            this.label2.Text = "موجودہ تاریخ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiButton1
            // 
            this.uiButton1.Enabled = false;
            this.uiButton1.Location = new System.Drawing.Point(88, 106);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(140, 45);
            this.uiButton1.TabIndex = 4;
            this.uiButton1.Text = "تاریخ تبدیل کریں";
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // frmDateChanger
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(346, 163);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.calendarCombo2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.calendarCombo1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmDateChanger";
            this.Text = "frmDateChanger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Janus.Windows.CalendarCombo.CalendarCombo calendarCombo1;
        private Janus.Windows.CalendarCombo.CalendarCombo calendarCombo2;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.EditControls.UIButton uiButton1;
    }
}