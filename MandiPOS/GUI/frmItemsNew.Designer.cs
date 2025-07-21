namespace MandiPOS.GUI
{
    partial class frmItemsNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmItemsNew));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbItemType = new Janus.Windows.EditControls.UIComboBox();
            this.itemTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.visualStyleManager1 = new Janus.Windows.Common.VisualStyleManager(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new Janus.Windows.GridEX.EditControls.EditBox();
            this.txtName = new Janus.Windows.GridEX.EditControls.EditBox();
            this.txtLaga = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.txtKaraya = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.txtmazdoori = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgv = new Janus.Windows.GridEX.GridEX();
            this.tblItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.itemTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblItemsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(885, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "اشیاء کی قسم منتخب کریں";
            // 
            // cmbItemType
            // 
            this.cmbItemType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbItemType.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cmbItemType.DataSource = this.itemTypesBindingSource;
            this.cmbItemType.DisplayMember = "Title";
            this.cmbItemType.HoverMode = Janus.Windows.EditControls.HoverMode.Highlight;
            this.cmbItemType.Location = new System.Drawing.Point(521, 9);
            this.cmbItemType.Name = "cmbItemType";
            this.cmbItemType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbItemType.SelectInDataSource = true;
            this.cmbItemType.Size = new System.Drawing.Size(358, 40);
            this.cmbItemType.TabIndex = 1;
            this.cmbItemType.ValueMember = "ID";
            this.cmbItemType.VisualStyleManager = this.visualStyleManager1;
            // 
            // itemTypesBindingSource
            // 
            this.itemTypesBindingSource.DataSource = typeof(MandiPOS.CLasses.ItemTypes);
            // 
            // visualStyleManager1
            // 
            janusColorScheme1.HighlightTextColor = System.Drawing.SystemColors.HighlightText;
            janusColorScheme1.Name = "Scheme0";
            janusColorScheme1.OfficeCustomColor = System.Drawing.Color.Empty;
            janusColorScheme1.VisualStyle = Janus.Windows.Common.VisualStyle.Office2007;
            this.visualStyleManager1.ColorSchemes.Add(janusColorScheme1);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(966, 54);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(30, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "کوڈ";
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(909, 98);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(87, 40);
            this.txtCode.TabIndex = 3;
            this.txtCode.TabStop = false;
            this.txtCode.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.txtCode.VisualStyleManager = this.visualStyleManager1;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(330, 98);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(573, 40);
            this.txtName.TabIndex = 4;
            this.txtName.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
            this.txtName.VisualStyleManager = this.visualStyleManager1;
            // 
            // txtLaga
            // 
            this.txtLaga.Location = new System.Drawing.Point(224, 98);
            this.txtLaga.Name = "txtLaga";
            this.txtLaga.Size = new System.Drawing.Size(100, 40);
            this.txtLaga.TabIndex = 5;
            this.txtLaga.Text = "0.00";
            this.txtLaga.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.txtLaga.Value = 0D;
            this.txtLaga.ValueType = Janus.Windows.GridEX.NumericEditValueType.Double;
            this.txtLaga.VisualStyleManager = this.visualStyleManager1;
            // 
            // txtKaraya
            // 
            this.txtKaraya.Location = new System.Drawing.Point(118, 98);
            this.txtKaraya.Name = "txtKaraya";
            this.txtKaraya.Size = new System.Drawing.Size(100, 40);
            this.txtKaraya.TabIndex = 6;
            this.txtKaraya.Text = "0.00";
            this.txtKaraya.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.txtKaraya.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtKaraya.VisualStyleManager = this.visualStyleManager1;
            // 
            // txtmazdoori
            // 
            this.txtmazdoori.Location = new System.Drawing.Point(12, 98);
            this.txtmazdoori.Name = "txtmazdoori";
            this.txtmazdoori.Size = new System.Drawing.Size(100, 40);
            this.txtmazdoori.TabIndex = 7;
            this.txtmazdoori.Text = "0.00";
            this.txtmazdoori.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.txtmazdoori.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtmazdoori.VisualStyleManager = this.visualStyleManager1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(856, 54);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(53, 32);
            this.label3.TabIndex = 8;
            this.label3.Text = "نام اشیاء";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(298, 54);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(32, 32);
            this.label4.TabIndex = 9;
            this.label4.Text = "لاگا";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(182, 54);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(42, 32);
            this.label5.TabIndex = 10;
            this.label5.Text = "کرایہ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(61, 54);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(57, 32);
            this.label6.TabIndex = 11;
            this.label6.Text = "مزدوری";
            // 
            // dgv
            // 
            this.dgv.AllowColumnDrag = false;
            this.dgv.ColumnAutoResize = true;
            this.dgv.DataSource = this.tblItemsBindingSource;
            dgv_DesignTimeLayout.LayoutString = resources.GetString("dgv_DesignTimeLayout.LayoutString");
            this.dgv.DesignTimeLayout = dgv_DesignTimeLayout;
            this.dgv.GroupByBoxVisible = false;
            this.dgv.Location = new System.Drawing.Point(13, 144);
            this.dgv.Name = "dgv";
            this.dgv.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgv.Size = new System.Drawing.Size(983, 573);
            this.dgv.TabIndex = 12;
            this.dgv.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.dgv.VisualStyleManager = this.visualStyleManager1;
            // 
            // tblItemsBindingSource
            // 
            this.tblItemsBindingSource.DataSource = typeof(MandiPOS.CLasses.tblItems);
            // 
            // frmItemsNew
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtmazdoori);
            this.Controls.Add(this.txtKaraya);
            this.Controls.Add(this.txtLaga);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbItemType);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "frmItemsNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmItemsNew";
            ((System.ComponentModel.ISupportInitialize)(this.itemTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblItemsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Janus.Windows.EditControls.UIComboBox cmbItemType;
        private Janus.Windows.Common.VisualStyleManager visualStyleManager1;
        private System.Windows.Forms.BindingSource itemTypesBindingSource;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.GridEX.EditControls.EditBox txtCode;
        private Janus.Windows.GridEX.EditControls.EditBox txtName;
        private Janus.Windows.GridEX.EditControls.NumericEditBox txtLaga;
        private Janus.Windows.GridEX.EditControls.NumericEditBox txtKaraya;
        private Janus.Windows.GridEX.EditControls.NumericEditBox txtmazdoori;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Janus.Windows.GridEX.GridEX dgv;
        private System.Windows.Forms.BindingSource tblItemsBindingSource;
    }
}