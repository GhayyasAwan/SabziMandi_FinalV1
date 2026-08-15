namespace MandiPOS.GUI
{
    partial class frmBardanaReport
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
            Janus.Windows.GridEX.GridEXLayout dgv_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBardanaReport));
            this.label1 = new System.Windows.Forms.Label();
            this.dtp1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.dtp2 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.cmbItems = new System.Windows.Forms.ComboBox();
            this.tblItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgv = new Janus.Windows.GridEX.GridEX();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tblItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(895, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "تاریخ";
            // 
            // dtp1
            // 
            this.dtp1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtp1.CustomFormat = "dd-MM-yyyy";
            this.dtp1.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtp1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007;
            this.dtp1.Location = new System.Drawing.Point(805, 39);
            this.dtp1.Name = "dtp1";
            this.dtp1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtp1.Size = new System.Drawing.Size(124, 35);
            this.dtp1.TabIndex = 1;
            this.dtp1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007;
            // 
            // dtp2
            // 
            this.dtp2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtp2.CustomFormat = "dd-MM-yyyy";
            this.dtp2.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtp2.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007;
            this.dtp2.Location = new System.Drawing.Point(675, 39);
            this.dtp2.Name = "dtp2";
            this.dtp2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtp2.Size = new System.Drawing.Size(124, 35);
            this.dtp2.TabIndex = 2;
            this.dtp2.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007;
            // 
            // cmbItems
            // 
            this.cmbItems.DataSource = this.tblItemsBindingSource;
            this.cmbItems.DisplayMember = "ItemTitle";
            this.cmbItems.FormattingEnabled = true;
            this.cmbItems.Location = new System.Drawing.Point(319, 39);
            this.cmbItems.Name = "cmbItems";
            this.cmbItems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbItems.Size = new System.Drawing.Size(350, 35);
            this.cmbItems.TabIndex = 3;
            this.cmbItems.ValueMember = "ID";
            // 
            // tblItemsBindingSource
            // 
            this.tblItemsBindingSource.DataSource = typeof(MandiPOS.CLasses.tblItems);
            // 
            // dgv
            // 
            this.dgv.AllowColumnDrag = false;
            this.dgv.AlternatingColors = true;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoEdit = true;
            this.dgv.ColumnAutoResize = true;
            this.dgv.DataSource = this.bs;
            dgv_DesignTimeLayout.LayoutString = resources.GetString("dgv_DesignTimeLayout.LayoutString");
            this.dgv.DesignTimeLayout = dgv_DesignTimeLayout;
            this.dgv.DynamicFiltering = true;
            this.dgv.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.dgv.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.dgv.GroupByBoxVisible = false;
            this.dgv.Location = new System.Drawing.Point(12, 80);
            this.dgv.Name = "dgv";
            this.dgv.OfficeColorScheme = Janus.Windows.GridEX.OfficeColorScheme.Blue;
            this.dgv.RecordNavigator = true;
            this.dgv.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgv.Size = new System.Drawing.Size(917, 582);
            this.dgv.TabIndex = 5;
            this.dgv.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.dgv.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.dgv.UpdateMode = Janus.Windows.GridEX.UpdateMode.CellUpdate;
            this.dgv.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // bs
            // 
            this.bs.DataSource = typeof(MandiPOS.CLasses.vw_BardanaLedger);
            // 
            // uiButton1
            // 
            this.uiButton1.Location = new System.Drawing.Point(188, 39);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(125, 35);
            this.uiButton1.TabIndex = 4;
            this.uiButton1.Text = "ریکارڈ چیک کریں";
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(635, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 27);
            this.label2.TabIndex = 6;
            this.label2.Text = "اشیاء";
            // 
            // frmBardanaReport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(941, 674);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.cmbItems);
            this.Controls.Add(this.dtp2);
            this.Controls.Add(this.dtp1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmBardanaReport";
            this.Text = "باردانہ رپورٹ";
            ((System.ComponentModel.ISupportInitialize)(this.tblItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Janus.Windows.CalendarCombo.CalendarCombo dtp1;
        private Janus.Windows.CalendarCombo.CalendarCombo dtp2;
        private System.Windows.Forms.ComboBox cmbItems;
        private Janus.Windows.GridEX.GridEX dgv;
        private System.Windows.Forms.BindingSource bs;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private System.Windows.Forms.BindingSource tblItemsBindingSource;
        private System.Windows.Forms.Label label2;
    }
}