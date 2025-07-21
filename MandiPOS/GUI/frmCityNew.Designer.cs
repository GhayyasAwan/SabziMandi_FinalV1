namespace MandiPOS.GUI
{
    partial class frmCityNew
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
            this.components = new System.ComponentModel.Container();
            Janus.Windows.Common.JanusColorScheme janusColorScheme1 = new Janus.Windows.Common.JanusColorScheme();
            Janus.Windows.GridEX.GridEXLayout dgv_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCityNew));
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new Janus.Windows.GridEX.EditControls.EditBox();
            this.visualStyleManager1 = new Janus.Windows.Common.VisualStyleManager(this.components);
            this.btnSave = new Janus.Windows.EditControls.UIButton();
            this.dgv = new Janus.Windows.GridEX.GridEX();
            this.tblCityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCityBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(930, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "شہر کا نام";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(136, 56);
            this.txtName.Name = "txtName";
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.Size = new System.Drawing.Size(860, 48);
            this.txtName.TabIndex = 1;
            this.txtName.VisualStyleManager = this.visualStyleManager1;
            // 
            // visualStyleManager1
            // 
            janusColorScheme1.HighlightTextColor = System.Drawing.SystemColors.HighlightText;
            janusColorScheme1.Name = "Scheme0";
            janusColorScheme1.OfficeCustomColor = System.Drawing.Color.Empty;
            janusColorScheme1.VisualStyle = Janus.Windows.Common.VisualStyle.Office2007;
            this.visualStyleManager1.ColorSchemes.Add(janusColorScheme1);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::MandiPOS.Properties.Resources.save_close_48px;
            this.btnSave.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.AfterText;
            this.btnSave.ImageSize = new System.Drawing.Size(32, 32);
            this.btnSave.Location = new System.Drawing.Point(12, 56);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(118, 40);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "محفوظ کریں";
            this.btnSave.VisualStyleManager = this.visualStyleManager1;
            // 
            // dgv
            // 
            this.dgv.AllowColumnDrag = false;
            this.dgv.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.dgv.AlternatingColors = true;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnAutoResize = true;
            this.dgv.DataSource = this.tblCityBindingSource;
            dgv_DesignTimeLayout.LayoutString = resources.GetString("dgv_DesignTimeLayout.LayoutString");
            this.dgv.DesignTimeLayout = dgv_DesignTimeLayout;
            this.dgv.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.GroupByBoxVisible = false;
            this.dgv.Location = new System.Drawing.Point(12, 104);
            this.dgv.Name = "dgv";
            this.dgv.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgv.Size = new System.Drawing.Size(984, 613);
            this.dgv.TabIndex = 3;
            // 
            // tblCityBindingSource
            // 
            this.tblCityBindingSource.DataSource = typeof(MandiPOS.CLasses.tblCity);
            // 
            // frmCityNew
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "frmCityNew";
            this.Text = "City";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCityBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource tblCityBindingSource;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.GridEX.EditControls.EditBox txtName;
        private Janus.Windows.Common.VisualStyleManager visualStyleManager1;
        private Janus.Windows.EditControls.UIButton btnSave;
        private Janus.Windows.GridEX.GridEX dgv;
    }
}