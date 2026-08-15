namespace MandiPOS.GUI
{
    partial class frmSecurityPasswords
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
            this.label2 = new System.Windows.Forms.Label();
            this.p1 = new System.Windows.Forms.TextBox();
            this.p2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.p3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.label5 = new System.Windows.Forms.Label();
            this.urduScrollingLabel1 = new UrduScrollingLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(667, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "یہاں پاسورڈ تبدیل کریں";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(547, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 35);
            this.label2.TabIndex = 2;
            this.label2.Text = "مال فروخت سیکیوریٹی";
            // 
            // p1
            // 
            this.p1.Location = new System.Drawing.Point(12, 82);
            this.p1.Name = "p1";
            this.p1.PasswordChar = '⁕';
            this.p1.Size = new System.Drawing.Size(529, 43);
            this.p1.TabIndex = 3;
            this.p1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // p2
            // 
            this.p2.Location = new System.Drawing.Point(12, 131);
            this.p2.Name = "p2";
            this.p2.PasswordChar = '⁕';
            this.p2.Size = new System.Drawing.Size(529, 43);
            this.p2.TabIndex = 5;
            this.p2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(547, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 35);
            this.label3.TabIndex = 4;
            this.label3.Text = "تفصیلات سیکیوریٹی";
            // 
            // p3
            // 
            this.p3.Location = new System.Drawing.Point(12, 180);
            this.p3.Name = "p3";
            this.p3.PasswordChar = '⁕';
            this.p3.Size = new System.Drawing.Size(529, 43);
            this.p3.TabIndex = 7;
            this.p3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(341, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 35);
            this.label4.TabIndex = 6;
            this.label4.Text = "پاسورڈ 1";
            this.label4.Visible = false;
            // 
            // uiButton1
            // 
            this.uiButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uiButton1.Location = new System.Drawing.Point(12, 240);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(129, 46);
            this.uiButton1.TabIndex = 8;
            this.uiButton1.Text = "محفوظ کریں";
            this.uiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(547, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 35);
            this.label5.TabIndex = 9;
            this.label5.Text = "ووچر سیکیوریٹی";
            // 
            // urduScrollingLabel1
            // 
            this.urduScrollingLabel1.AutoSize = true;
            this.urduScrollingLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.urduScrollingLabel1.Location = new System.Drawing.Point(0, 0);
            this.urduScrollingLabel1.Name = "urduScrollingLabel1";
            this.urduScrollingLabel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.urduScrollingLabel1.Size = new System.Drawing.Size(0, 35);
            this.urduScrollingLabel1.TabIndex = 0;
            this.urduScrollingLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmSecurityPasswords
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(667, 298);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.p3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.p2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.p1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.urduScrollingLabel1);
            this.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmSecurityPasswords";
            this.Text = "Security Password Change";
            this.Load += new System.EventHandler(this.frmSecurityPasswords_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UrduScrollingLabel urduScrollingLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox p1;
        private System.Windows.Forms.TextBox p2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox p3;
        private System.Windows.Forms.Label label4;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private System.Windows.Forms.Label label5;
    }
}