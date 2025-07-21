namespace MandiPOS.GUI
{
    partial class frmJournalVoucher
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
            Janus.Windows.GridEX.GridEXLayout gridEX1_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJournalVoucher));
            this.dt = new System.Windows.Forms.DateTimePicker();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.cmbParty = new DevExpress.XtraEditors.LookUpEdit();
            this.bsAccounts = new System.Windows.Forms.BindingSource(this.components);
            this.txtNarration = new DevExpress.XtraEditors.TextEdit();
            this.Dr = new DevExpress.XtraEditors.TextEdit();
            this.Cr = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbParty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNarration.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            this.SuspendLayout();
            // 
            // dt
            // 
            this.dt.CustomFormat = "dd-MMM-yyyy";
            this.dt.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt.Location = new System.Drawing.Point(12, 19);
            this.dt.Name = "dt";
            this.dt.Size = new System.Drawing.Size(161, 29);
            this.dt.TabIndex = 0;
            this.dt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dt_KeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 14.25F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(179, 18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(26, 32);
            this.labelControl1.TabIndex = 17;
            this.labelControl1.Text = "تاریخ";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 14.25F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(1064, 75);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(14, 32);
            this.labelControl2.TabIndex = 18;
            this.labelControl2.Text = "کوڈ";
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.EnterMoveNextControl = true;
            this.txtCode.Location = new System.Drawing.Point(1024, 113);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Appearance.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Properties.Appearance.Options.UseFont = true;
            this.txtCode.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Gold;
            this.txtCode.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtCode.Properties.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(54, 50);
            this.txtCode.TabIndex = 1;
            this.txtCode.TabStop = false;
            // 
            // cmbParty
            // 
            this.cmbParty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbParty.EnterMoveNextControl = true;
            this.cmbParty.Location = new System.Drawing.Point(852, 113);
            this.cmbParty.Name = "cmbParty";
            this.cmbParty.Properties.Appearance.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 16F);
            this.cmbParty.Properties.Appearance.Options.UseFont = true;
            this.cmbParty.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbParty.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cmbParty.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Gold;
            this.cmbParty.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.cmbParty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbParty.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 32, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AccountCode", "کوڈ", 39, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AccountTitle", "نام پارٹی", 120, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cmbParty.Properties.DataSource = this.bsAccounts;
            this.cmbParty.Properties.DisplayMember = "AccountTitle";
            this.cmbParty.Properties.NullText = "پارٹی منتخب کریں";
            this.cmbParty.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cmbParty.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSearch;
            this.cmbParty.Properties.ValueMember = "ID";
            this.cmbParty.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbParty.Size = new System.Drawing.Size(166, 50);
            this.cmbParty.TabIndex = 2;
            this.cmbParty.EditValueChanged += new System.EventHandler(this.cmbParty_EditValueChanged);
            this.cmbParty.Enter += new System.EventHandler(this.cmbParty_Enter);
            // 
            // bsAccounts
            // 
            this.bsAccounts.DataSource = typeof(MandiPOS.CLasses.DetailAccountView);
            // 
            // txtNarration
            // 
            this.txtNarration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNarration.EnterMoveNextControl = true;
            this.txtNarration.Location = new System.Drawing.Point(336, 113);
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Properties.Appearance.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 16F);
            this.txtNarration.Properties.Appearance.Options.UseFont = true;
            this.txtNarration.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Gold;
            this.txtNarration.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtNarration.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNarration.Size = new System.Drawing.Size(510, 50);
            this.txtNarration.TabIndex = 3;
            this.txtNarration.Enter += new System.EventHandler(this.txtNarration_Enter);
            // 
            // Dr
            // 
            this.Dr.Location = new System.Drawing.Point(12, 113);
            this.Dr.Name = "Dr";
            this.Dr.Properties.Appearance.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 16F);
            this.Dr.Properties.Appearance.Options.UseFont = true;
            this.Dr.Properties.Appearance.Options.UseTextOptions = true;
            this.Dr.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Dr.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Gold;
            this.Dr.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.Dr.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Dr.Size = new System.Drawing.Size(161, 50);
            this.Dr.TabIndex = 5;
            this.Dr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            // 
            // Cr
            // 
            this.Cr.EnterMoveNextControl = true;
            this.Cr.Location = new System.Drawing.Point(179, 113);
            this.Cr.Name = "Cr";
            this.Cr.Properties.Appearance.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 16F);
            this.Cr.Properties.Appearance.Options.UseFont = true;
            this.Cr.Properties.Appearance.Options.UseTextOptions = true;
            this.Cr.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Cr.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Gold;
            this.Cr.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.Cr.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Cr.Size = new System.Drawing.Size(151, 50);
            this.Cr.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 14.25F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(964, 75);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 32);
            this.labelControl3.TabIndex = 24;
            this.labelControl3.Text = "نام پارٹی";
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 14.25F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(815, 75);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(31, 32);
            this.labelControl4.TabIndex = 25;
            this.labelControl4.Text = "تفصیل";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 14.25F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(286, 75);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(32, 32);
            this.labelControl5.TabIndex = 26;
            this.labelControl5.Text = "رقم جمع";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 14.25F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(139, 75);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(34, 32);
            this.labelControl6.TabIndex = 27;
            this.labelControl6.Text = "رقم بنام";
            // 
            // gridEX1
            // 
            this.gridEX1.AllowColumnDrag = false;
            this.gridEX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridEX1.ColumnAutoResize = true;
            this.gridEX1.DataSource = this.bs;
            gridEX1_DesignTimeLayout.LayoutString = resources.GetString("gridEX1_DesignTimeLayout.LayoutString");
            this.gridEX1.DesignTimeLayout = gridEX1_DesignTimeLayout;
            this.gridEX1.GroupByBoxVisible = false;
            this.gridEX1.Location = new System.Drawing.Point(12, 169);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridEX1.Size = new System.Drawing.Size(1078, 413);
            this.gridEX1.TabIndex = 6;
            this.gridEX1.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEX1.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gridEX1.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.gridEX1_FormattingRow);
            this.gridEX1.DoubleClick += new System.EventHandler(this.gridEX1_DoubleClick);
            // 
            // bs
            // 
            this.bs.DataSource = typeof(MandiPOS.CLasses.JVCart);
            // 
            // uiButton1
            // 
            this.uiButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uiButton1.Image = global::MandiPOS.Properties.Resources.save_close_48px;
            this.uiButton1.ImageSize = new System.Drawing.Size(48, 48);
            this.uiButton1.Location = new System.Drawing.Point(916, 588);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.uiButton1.Size = new System.Drawing.Size(174, 67);
            this.uiButton1.TabIndex = 28;
            this.uiButton1.Text = "محفوظ کریں";
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // frmJournalVoucher
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1102, 667);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.gridEX1);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.Cr);
            this.Controls.Add(this.Dr);
            this.Controls.Add(this.txtNarration);
            this.Controls.Add(this.cmbParty);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.dt);
            this.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 14.25F);
            this.Name = "frmJournalVoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmJournalVoucher";
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbParty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNarration.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dt;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.LookUpEdit cmbParty;
        private DevExpress.XtraEditors.TextEdit txtNarration;
        private DevExpress.XtraEditors.TextEdit Dr;
        private DevExpress.XtraEditors.TextEdit Cr;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private Janus.Windows.GridEX.GridEX gridEX1;
        private System.Windows.Forms.BindingSource bs;
        private System.Windows.Forms.BindingSource bsAccounts;
        private Janus.Windows.EditControls.UIButton uiButton1;
    }
}