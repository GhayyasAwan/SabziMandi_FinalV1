namespace MandiPOS.GUI
{
    partial class frmBardanaVoucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBardanaVoucher));
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbBardana = new System.Windows.Forms.RadioButton();
            this.rbSeeds = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbJama = new System.Windows.Forms.RadioButton();
            this.rbBanam = new System.Windows.Forms.RadioButton();
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.cmbParties = new DevExpress.XtraEditors.LookUpEdit();
            this.txtNarration = new DevExpress.XtraEditors.TextEdit();
            this.cmbItems = new DevExpress.XtraEditors.LookUpEdit();
            this.txtQty = new DevExpress.XtraEditors.TextEdit();
            this.txtRate = new DevExpress.XtraEditors.TextEdit();
            this.txtPrevBalance = new DevExpress.XtraEditors.TextEdit();
            this.txtDebit = new DevExpress.XtraEditors.TextEdit();
            this.txtCredit = new DevExpress.XtraEditors.TextEdit();
            this.bsCart = new System.Windows.Forms.BindingSource(this.components);
            this.bsParties = new System.Windows.Forms.BindingSource(this.components);
            this.bsItems = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbParties.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNarration.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbItems.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrevBalance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCredit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsParties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(178, 31);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1155, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "کوڈ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(921, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 41);
            this.label2.TabIndex = 10;
            this.label2.Text = "سابقہ بیلنس";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(715, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 41);
            this.label3.TabIndex = 12;
            this.label3.Text = "تفصیل";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(572, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 41);
            this.label4.TabIndex = 13;
            this.label4.Text = "اشیاء";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(435, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 41);
            this.label5.TabIndex = 14;
            this.label5.Text = "تعداد";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(322, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 41);
            this.label6.TabIndex = 15;
            this.label6.Text = "ریٹ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(204, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 41);
            this.label7.TabIndex = 16;
            this.label7.Text = "رقم بنام";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(75, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 41);
            this.label8.TabIndex = 17;
            this.label8.Text = "رقم جمع";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbParties);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtNarration);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbItems);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtQty);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtRate);
            this.groupBox1.Controls.Add(this.txtPrevBalance);
            this.groupBox1.Controls.Add(this.txtDebit);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCredit);
            this.groupBox1.Location = new System.Drawing.Point(12, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1197, 147);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.PowderBlue;
            this.groupBox2.Controls.Add(this.rbBardana);
            this.groupBox2.Controls.Add(this.rbSeeds);
            this.groupBox2.Location = new System.Drawing.Point(433, -16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(149, 76);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            // 
            // rbBardana
            // 
            this.rbBardana.AutoSize = true;
            this.rbBardana.Location = new System.Drawing.Point(10, 25);
            this.rbBardana.Name = "rbBardana";
            this.rbBardana.Size = new System.Drawing.Size(72, 45);
            this.rbBardana.TabIndex = 1;
            this.rbBardana.Text = "باردانہ";
            this.rbBardana.UseVisualStyleBackColor = true;
            // 
            // rbSeeds
            // 
            this.rbSeeds.AutoSize = true;
            this.rbSeeds.Checked = true;
            this.rbSeeds.Location = new System.Drawing.Point(88, 25);
            this.rbSeeds.Name = "rbSeeds";
            this.rbSeeds.Size = new System.Drawing.Size(51, 45);
            this.rbSeeds.TabIndex = 0;
            this.rbSeeds.TabStop = true;
            this.rbSeeds.Text = "بیج";
            this.rbSeeds.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.LightBlue;
            this.groupBox3.Controls.Add(this.rbJama);
            this.groupBox3.Controls.Add(this.rbBanam);
            this.groupBox3.Location = new System.Drawing.Point(275, -16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(149, 76);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            // 
            // rbJama
            // 
            this.rbJama.AutoSize = true;
            this.rbJama.Location = new System.Drawing.Point(10, 25);
            this.rbJama.Name = "rbJama";
            this.rbJama.Size = new System.Drawing.Size(61, 45);
            this.rbJama.TabIndex = 1;
            this.rbJama.Text = "جامد";
            this.rbJama.UseVisualStyleBackColor = true;
            // 
            // rbBanam
            // 
            this.rbBanam.AutoSize = true;
            this.rbBanam.Checked = true;
            this.rbBanam.Location = new System.Drawing.Point(84, 25);
            this.rbBanam.Name = "rbBanam";
            this.rbBanam.Size = new System.Drawing.Size(58, 45);
            this.rbBanam.TabIndex = 0;
            this.rbBanam.TabStop = true;
            this.rbBanam.Text = "آمد";
            this.rbBanam.UseVisualStyleBackColor = true;
            // 
            // gridEX1
            // 
            this.gridEX1.AllowColumnDrag = false;
            this.gridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gridEX1.AlternatingColors = true;
            this.gridEX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridEX1.AutoEdit = true;
            this.gridEX1.ColumnAutoResize = true;
            this.gridEX1.DataSource = this.bsCart;
            this.gridEX1.DefaultFilterRowComparison = Janus.Windows.GridEX.FilterConditionOperator.Contains;
            gridEX1_DesignTimeLayout.LayoutString = resources.GetString("gridEX1_DesignTimeLayout.LayoutString");
            this.gridEX1.DesignTimeLayout = gridEX1_DesignTimeLayout;
            this.gridEX1.DynamicFiltering = true;
            this.gridEX1.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gridEX1.GroupByBoxVisible = false;
            this.gridEX1.IncrementalSearchMode = Janus.Windows.GridEX.IncrementalSearchMode.AllCharacters;
            this.gridEX1.Location = new System.Drawing.Point(12, 211);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.OfficeColorScheme = Janus.Windows.GridEX.OfficeColorScheme.Blue;
            this.gridEX1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridEX1.Size = new System.Drawing.Size(1197, 465);
            this.gridEX1.TabIndex = 21;
            this.gridEX1.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEX1.TotalRowFormatStyle.BackColor = System.Drawing.SystemColors.Info;
            this.gridEX1.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gridEX1.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gridEX1.UpdateMode = Janus.Windows.GridEX.UpdateMode.CellUpdate;
            this.gridEX1.VisualStyle = Janus.Windows.GridEX.VisualStyle.VS2010;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.ForestGreen;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::MandiPOS.Properties.Resources.save_close_48px;
            this.btnSave.Location = new System.Drawing.Point(1060, 682);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSave.Size = new System.Drawing.Size(149, 61);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "محفوظ کریں";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Enabled = false;
            this.txtCode.Location = new System.Drawing.Point(1091, 80);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Appearance.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Properties.Appearance.Options.UseFont = true;
            this.txtCode.Size = new System.Drawing.Size(100, 48);
            this.txtCode.TabIndex = 2;
            this.txtCode.TabStop = false;
            // 
            // cmbParties
            // 
            this.cmbParties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbParties.EnterMoveNextControl = true;
            this.cmbParties.Location = new System.Drawing.Point(778, 80);
            this.cmbParties.Name = "cmbParties";
            this.cmbParties.Properties.Appearance.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbParties.Properties.Appearance.Options.UseFont = true;
            this.cmbParties.Properties.Appearance.Options.UseTextOptions = true;
            this.cmbParties.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.cmbParties.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbParties.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cmbParties.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbParties.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AccountCode", "کوڈ", 27, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AccountTitle", "نام پارٹی", 52, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Contact", "رابطہ نمبر", 55, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("City", "شہر", 28, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RefName", "معرفت", 39, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cmbParties.Properties.DataSource = this.bsParties;
            this.cmbParties.Properties.DisplayMember = "AccountTitle";
            this.cmbParties.Properties.NullText = "پارٹی منتخب کریں";
            this.cmbParties.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cmbParties.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSearch;
            this.cmbParties.Properties.ValueMember = "ID";
            this.cmbParties.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbParties.Size = new System.Drawing.Size(307, 48);
            this.cmbParties.TabIndex = 3;
            // 
            // txtNarration
            // 
            this.txtNarration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNarration.EnterMoveNextControl = true;
            this.txtNarration.Location = new System.Drawing.Point(620, 80);
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Properties.Appearance.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNarration.Properties.Appearance.Options.UseFont = true;
            this.txtNarration.Properties.Appearance.Options.UseTextOptions = true;
            this.txtNarration.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtNarration.Size = new System.Drawing.Size(152, 48);
            this.txtNarration.TabIndex = 4;
            // 
            // cmbItems
            // 
            this.cmbItems.EnterMoveNextControl = true;
            this.cmbItems.Location = new System.Drawing.Point(483, 80);
            this.cmbItems.Name = "cmbItems";
            this.cmbItems.Properties.Appearance.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbItems.Properties.Appearance.Options.UseFont = true;
            this.cmbItems.Properties.Appearance.Options.UseTextOptions = true;
            this.cmbItems.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.cmbItems.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbItems.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cmbItems.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbItems.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "کوڈ", 27, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ItemTitle", "اشیاء کا نام", 65, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cmbItems.Properties.DataSource = this.bsItems;
            this.cmbItems.Properties.DisplayMember = "ItemTitle";
            this.cmbItems.Properties.NullText = "پارٹی منتخب کریں";
            this.cmbItems.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cmbItems.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSearch;
            this.cmbItems.Properties.ValueMember = "ID";
            this.cmbItems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbItems.Size = new System.Drawing.Size(131, 48);
            this.cmbItems.TabIndex = 5;
            // 
            // txtQty
            // 
            this.txtQty.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtQty.EnterMoveNextControl = true;
            this.txtQty.Location = new System.Drawing.Point(377, 80);
            this.txtQty.Name = "txtQty";
            this.txtQty.Properties.Appearance.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Properties.Appearance.Options.UseFont = true;
            this.txtQty.Properties.Appearance.Options.UseTextOptions = true;
            this.txtQty.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtQty.Size = new System.Drawing.Size(100, 48);
            this.txtQty.TabIndex = 6;
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckNumeric);
            // 
            // txtRate
            // 
            this.txtRate.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtRate.Location = new System.Drawing.Point(271, 80);
            this.txtRate.Name = "txtRate";
            this.txtRate.Properties.Appearance.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRate.Properties.Appearance.Options.UseFont = true;
            this.txtRate.Properties.Appearance.Options.UseTextOptions = true;
            this.txtRate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtRate.Size = new System.Drawing.Size(100, 48);
            this.txtRate.TabIndex = 7;
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckNumeric);
            // 
            // txtPrevBalance
            // 
            this.txtPrevBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrevBalance.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPrevBalance.Enabled = false;
            this.txtPrevBalance.Location = new System.Drawing.Point(778, 26);
            this.txtPrevBalance.Name = "txtPrevBalance";
            this.txtPrevBalance.Properties.Appearance.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrevBalance.Properties.Appearance.Options.UseFont = true;
            this.txtPrevBalance.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPrevBalance.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtPrevBalance.Size = new System.Drawing.Size(137, 48);
            this.txtPrevBalance.TabIndex = 11;
            this.txtPrevBalance.TabStop = false;
            // 
            // txtDebit
            // 
            this.txtDebit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDebit.EnterMoveNextControl = true;
            this.txtDebit.Location = new System.Drawing.Point(140, 80);
            this.txtDebit.Name = "txtDebit";
            this.txtDebit.Properties.Appearance.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDebit.Properties.Appearance.Options.UseFont = true;
            this.txtDebit.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDebit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtDebit.Properties.ReadOnly = true;
            this.txtDebit.Size = new System.Drawing.Size(125, 48);
            this.txtDebit.TabIndex = 8;
            // 
            // txtCredit
            // 
            this.txtCredit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCredit.EnterMoveNextControl = true;
            this.txtCredit.Location = new System.Drawing.Point(9, 80);
            this.txtCredit.Name = "txtCredit";
            this.txtCredit.Properties.Appearance.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCredit.Properties.Appearance.Options.UseFont = true;
            this.txtCredit.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCredit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtCredit.Properties.ReadOnly = true;
            this.txtCredit.Size = new System.Drawing.Size(125, 48);
            this.txtCredit.TabIndex = 9;
            // 
            // bsCart
            // 
            this.bsCart.DataSource = typeof(MandiPOS.CLasses.BardanaCart);
            // 
            // bsParties
            // 
            this.bsParties.DataSource = typeof(MandiPOS.CLasses.DetailAccountView);
            // 
            // bsItems
            // 
            this.bsItems.DataSource = typeof(MandiPOS.CLasses.tblItems);
            // 
            // frmBardanaVoucher
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1221, 749);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gridEX1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Name = "frmBardanaVoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBardanaVoucher";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbParties.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNarration.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbItems.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrevBalance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCredit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsParties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.LookUpEdit cmbParties;
        private DevExpress.XtraEditors.TextEdit txtNarration;
        private DevExpress.XtraEditors.LookUpEdit cmbItems;
        private DevExpress.XtraEditors.TextEdit txtQty;
        private DevExpress.XtraEditors.TextEdit txtRate;
        private DevExpress.XtraEditors.TextEdit txtDebit;
        private DevExpress.XtraEditors.TextEdit txtCredit;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtPrevBalance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbBardana;
        private System.Windows.Forms.RadioButton rbSeeds;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbJama;
        private System.Windows.Forms.RadioButton rbBanam;
        private Janus.Windows.GridEX.GridEX gridEX1;
        private System.Windows.Forms.BindingSource bsCart;
        private System.Windows.Forms.BindingSource bsItems;
        private System.Windows.Forms.BindingSource bsParties;
        private System.Windows.Forms.Button btnSave;
    }
}