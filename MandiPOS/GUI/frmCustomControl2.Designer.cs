namespace MandiPOS.GUI
{
    partial class frmCustomControl2
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
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.pb1 = new System.Windows.Forms.PictureBox();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.uiButton2 = new Janus.Windows.EditControls.UIButton();
            this.uiButton3 = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).BeginInit();
            this.SuspendLayout();
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiGroupBox1.Controls.Add(this.pb1);
            this.uiGroupBox1.Location = new System.Drawing.Point(13, 13);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(360, 258);
            this.uiGroupBox1.TabIndex = 0;
            this.uiGroupBox1.Text = "Custom Label";
            // 
            // pb1
            // 
            this.pb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb1.Location = new System.Drawing.Point(3, 27);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(354, 228);
            this.pb1.TabIndex = 0;
            this.pb1.TabStop = false;
            // 
            // uiButton1
            // 
            this.uiButton1.Location = new System.Drawing.Point(16, 277);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Custom;
            this.uiButton1.OfficeCustomColor = System.Drawing.Color.PaleGreen;
            this.uiButton1.Size = new System.Drawing.Size(112, 39);
            this.uiButton1.TabIndex = 1;
            this.uiButton1.Text = "Select";
            this.uiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // uiButton2
            // 
            this.uiButton2.Location = new System.Drawing.Point(137, 277);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Custom;
            this.uiButton2.OfficeCustomColor = System.Drawing.Color.LightCoral;
            this.uiButton2.Size = new System.Drawing.Size(112, 39);
            this.uiButton2.TabIndex = 2;
            this.uiButton2.Text = "Remove";
            this.uiButton2.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.uiButton2.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // uiButton3
            // 
            this.uiButton3.Location = new System.Drawing.Point(258, 277);
            this.uiButton3.Name = "uiButton3";
            this.uiButton3.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Custom;
            this.uiButton3.OfficeCustomColor = System.Drawing.Color.ForestGreen;
            this.uiButton3.Size = new System.Drawing.Size(112, 39);
            this.uiButton3.TabIndex = 3;
            this.uiButton3.Text = "Save";
            this.uiButton3.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.uiButton3.Click += new System.EventHandler(this.uiButton3_Click);
            // 
            // frmCustomControl2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(385, 331);
            this.Controls.Add(this.uiButton3);
            this.Controls.Add(this.uiButton2);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.uiGroupBox1);
            this.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustomControl2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Custom Label";
            this.Load += new System.EventHandler(this.frmCustomControl2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private System.Windows.Forms.PictureBox pb1;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private Janus.Windows.EditControls.UIButton uiButton2;
        private Janus.Windows.EditControls.UIButton uiButton3;
    }
}