namespace MandiPOS.GUI
{
    partial class frmBVNew2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBVNew2));
            Janus.Windows.GridEX.GridEXLayout dgvHelp_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbStock_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbOther = new Janus.Windows.EditControls.UIRadioButton();
            this.rbSeed = new Janus.Windows.EditControls.UIRadioButton();
            this.grpMode = new System.Windows.Forms.GroupBox();
            this.rbCredit = new Janus.Windows.EditControls.UIRadioButton();
            this.rbDebit = new Janus.Windows.EditControls.UIRadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this._code = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this._name = new Janus.Windows.GridEX.EditControls.EditBox();
            this._narration = new Janus.Windows.GridEX.EditControls.EditBox();
            this._items = new Janus.Windows.EditControls.UIComboBox();
            this.bsItems = new System.Windows.Forms.BindingSource(this.components);
            this._qty = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this._rate = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this._dr = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this._cr = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.dgv = new Janus.Windows.GridEX.GridEX();
            this.bsCart = new System.Windows.Forms.BindingSource(this.components);
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.bsParties = new System.Windows.Forms.BindingSource(this.components);
            this.dgvHelp = new Janus.Windows.GridEX.GridEX();
            this.partyBal = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.txtVno = new System.Windows.Forms.NumericUpDown();
            this._wt = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.lblwt = new System.Windows.Forms.Label();
            this.uiButton2 = new Janus.Windows.EditControls.UIButton();
            this.uiButton3 = new Janus.Windows.EditControls.UIButton();
            this.uiCheckBox1 = new Janus.Windows.EditControls.UICheckBox();
            this.cmbStock = new Janus.Windows.GridEX.EditControls.MultiColumnCombo();
            this.bsStock = new System.Windows.Forms.BindingSource(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grpMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsParties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStock)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(892, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "تاریخ";
            // 
            // dtp
            // 
            this.dtp.CustomFormat = "dd-MM-yyyy";
            this.dtp.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            this.dtp.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp.Location = new System.Drawing.Point(726, 40);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(160, 30);
            this.dtp.TabIndex = 1;
            this.dtp.Value = new System.DateTime(2025, 12, 11, 0, 0, 0, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Lavender;
            this.groupBox1.Controls.Add(this.rbOther);
            this.groupBox1.Controls.Add(this.rbSeed);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(249, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(178, 72);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // rbOther
            // 
            this.rbOther.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbOther.Location = new System.Drawing.Point(15, 22);
            this.rbOther.Name = "rbOther";
            this.rbOther.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbOther.Size = new System.Drawing.Size(72, 44);
            this.rbOther.TabIndex = 4;
            this.rbOther.Text = "باردانہ";
            this.rbOther.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center;
            this.rbOther.UseCompatibleTextRendering = true;
            // 
            // rbSeed
            // 
            this.rbSeed.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbSeed.Checked = true;
            this.rbSeed.Location = new System.Drawing.Point(93, 22);
            this.rbSeed.Name = "rbSeed";
            this.rbSeed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbSeed.Size = new System.Drawing.Size(72, 44);
            this.rbSeed.TabIndex = 3;
            this.rbSeed.TabStop = true;
            this.rbSeed.Text = "بیج";
            this.rbSeed.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center;
            this.rbSeed.UseCompatibleTextRendering = true;
            // 
            // grpMode
            // 
            this.grpMode.BackColor = System.Drawing.Color.DodgerBlue;
            this.grpMode.Controls.Add(this.rbCredit);
            this.grpMode.Controls.Add(this.rbDebit);
            this.grpMode.Location = new System.Drawing.Point(543, -11);
            this.grpMode.Name = "grpMode";
            this.grpMode.Size = new System.Drawing.Size(178, 72);
            this.grpMode.TabIndex = 5;
            this.grpMode.TabStop = false;
            // 
            // rbCredit
            // 
            this.rbCredit.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbCredit.Location = new System.Drawing.Point(15, 22);
            this.rbCredit.Name = "rbCredit";
            this.rbCredit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbCredit.Size = new System.Drawing.Size(72, 44);
            this.rbCredit.TabIndex = 4;
            this.rbCredit.Text = "جامد";
            this.rbCredit.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center;
            this.rbCredit.UseCompatibleTextRendering = true;
            // 
            // rbDebit
            // 
            this.rbDebit.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbDebit.Checked = true;
            this.rbDebit.Location = new System.Drawing.Point(93, 22);
            this.rbDebit.Name = "rbDebit";
            this.rbDebit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbDebit.Size = new System.Drawing.Size(72, 44);
            this.rbDebit.TabIndex = 3;
            this.rbDebit.TabStop = true;
            this.rbDebit.Text = "آمد";
            this.rbDebit.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center;
            this.rbDebit.UseCompatibleTextRendering = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1224, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 27);
            this.label2.TabIndex = 6;
            this.label2.Text = "کوڈ";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1151, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 27);
            this.label3.TabIndex = 7;
            this.label3.Text = "پارٹی";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(895, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 27);
            this.label4.TabIndex = 8;
            this.label4.Text = "تفصیل";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(774, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 27);
            this.label5.TabIndex = 9;
            this.label5.Text = "اشیاء";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(353, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 27);
            this.label6.TabIndex = 10;
            this.label6.Text = "تعداد";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(230, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 27);
            this.label7.TabIndex = 11;
            this.label7.Text = "ریٹ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(155, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 27);
            this.label8.TabIndex = 12;
            this.label8.Text = "رقم بنام";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(62, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 27);
            this.label9.TabIndex = 13;
            this.label9.Text = "رقم جمع";
            // 
            // _code
            // 
            this._code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._code.Location = new System.Drawing.Point(1188, 113);
            this._code.Name = "_code";
            this._code.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowNull;
            this._code.Size = new System.Drawing.Size(60, 35);
            this._code.TabIndex = 14;
            this._code.Text = "";
            this._code.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this._code.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32;
            // 
            // _name
            // 
            this._name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._name.Location = new System.Drawing.Point(939, 113);
            this._name.Name = "_name";
            this._name.Size = new System.Drawing.Size(243, 35);
            this._name.TabIndex = 15;
            // 
            // _narration
            // 
            this._narration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._narration.Location = new System.Drawing.Point(808, 114);
            this._narration.Name = "_narration";
            this._narration.Size = new System.Drawing.Size(125, 35);
            this._narration.TabIndex = 16;
            // 
            // _items
            // 
            this._items.DataSource = this.bsItems;
            this._items.DisplayMember = "ItemTitle";
            this._items.Location = new System.Drawing.Point(653, 114);
            this._items.Name = "_items";
            this._items.Size = new System.Drawing.Size(149, 35);
            this._items.Sorted = true;
            this._items.TabIndex = 17;
            this._items.ValueMember = "ID";
            this._items.SelectedIndexChanged += new System.EventHandler(this.uiComboBox1_SelectedIndexChanged);
            // 
            // bsItems
            // 
            this.bsItems.DataSource = typeof(MandiPOS.CLasses.tblItems);
            // 
            // _qty
            // 
            this._qty.Location = new System.Drawing.Point(332, 114);
            this._qty.Name = "_qty";
            this._qty.Size = new System.Drawing.Size(54, 35);
            this._qty.TabIndex = 18;
            this._qty.Text = "0.00";
            this._qty.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this._qty.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // _rate
            // 
            this._rate.Location = new System.Drawing.Point(202, 114);
            this._rate.Name = "_rate";
            this._rate.Size = new System.Drawing.Size(60, 35);
            this._rate.TabIndex = 19;
            this._rate.Text = "0.00";
            this._rate.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this._rate.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // _dr
            // 
            this._dr.Location = new System.Drawing.Point(107, 114);
            this._dr.Name = "_dr";
            this._dr.ReadOnly = true;
            this._dr.Size = new System.Drawing.Size(89, 35);
            this._dr.TabIndex = 20;
            this._dr.TabStop = false;
            this._dr.Text = "0.00";
            this._dr.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this._dr.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // _cr
            // 
            this._cr.Location = new System.Drawing.Point(12, 114);
            this._cr.Name = "_cr";
            this._cr.ReadOnly = true;
            this._cr.Size = new System.Drawing.Size(89, 35);
            this._cr.TabIndex = 21;
            this._cr.TabStop = false;
            this._cr.Text = "0.00";
            this._cr.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this._cr.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
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
            this.dgv.DataSource = this.bsCart;
            dgv_DesignTimeLayout.LayoutString = resources.GetString("dgv_DesignTimeLayout.LayoutString");
            this.dgv.DesignTimeLayout = dgv_DesignTimeLayout;
            this.dgv.GroupByBoxVisible = false;
            this.dgv.Location = new System.Drawing.Point(12, 167);
            this.dgv.Name = "dgv";
            this.dgv.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgv.Size = new System.Drawing.Size(1236, 451);
            this.dgv.TabIndex = 22;
            this.dgv.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.dgv.TotalRowFormatStyle.BackColor = System.Drawing.SystemColors.Info;
            this.dgv.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.dgv.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // bsCart
            // 
            this.bsCart.DataSource = typeof(MandiPOS.CLasses.BardanaCart);
            // 
            // uiButton1
            // 
            this.uiButton1.Image = global::MandiPOS.Properties.Resources.save_close_48px;
            this.uiButton1.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.AfterText;
            this.uiButton1.ImageSize = new System.Drawing.Size(32, 32);
            this.uiButton1.Location = new System.Drawing.Point(6, 42);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(37, 33);
            this.uiButton1.TabIndex = 23;
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // bsParties
            // 
            this.bsParties.DataSource = typeof(MandiPOS.CLasses.DetailAccountView);
            // 
            // dgvHelp
            // 
            this.dgvHelp.ColumnAutoResize = true;
            this.dgvHelp.DataSource = this.bsParties;
            dgvHelp_DesignTimeLayout.LayoutString = resources.GetString("dgvHelp_DesignTimeLayout.LayoutString");
            this.dgvHelp.DesignTimeLayout = dgvHelp_DesignTimeLayout;
            this.dgvHelp.GroupByBoxVisible = false;
            this.dgvHelp.Location = new System.Drawing.Point(586, 154);
            this.dgvHelp.Name = "dgvHelp";
            this.dgvHelp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvHelp.Size = new System.Drawing.Size(596, 371);
            this.dgvHelp.TabIndex = 26;
            this.dgvHelp.Visible = false;
            this.dgvHelp.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            // 
            // partyBal
            // 
            this.partyBal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.partyBal.AutoSize = true;
            this.partyBal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partyBal.Location = new System.Drawing.Point(943, 86);
            this.partyBal.Name = "partyBal";
            this.partyBal.Size = new System.Drawing.Size(19, 20);
            this.partyBal.TabIndex = 27;
            this.partyBal.Text = "0";
            // 
            // lblType
            // 
            this.lblType.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblType.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblType.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.ForeColor = System.Drawing.Color.White;
            this.lblType.Location = new System.Drawing.Point(0, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(1260, 37);
            this.lblType.TabIndex = 28;
            this.lblType.Text = "تاریخ";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtVno
            // 
            this.txtVno.Location = new System.Drawing.Point(3, 1);
            this.txtVno.Name = "txtVno";
            this.txtVno.Size = new System.Drawing.Size(85, 35);
            this.txtVno.TabIndex = 29;
            this.txtVno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _wt
            // 
            this._wt.Location = new System.Drawing.Point(268, 114);
            this._wt.Name = "_wt";
            this._wt.Size = new System.Drawing.Size(58, 35);
            this._wt.TabIndex = 30;
            this._wt.Text = "0.00";
            this._wt.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this._wt.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblwt
            // 
            this.lblwt.AutoSize = true;
            this.lblwt.Location = new System.Drawing.Point(276, 84);
            this.lblwt.Name = "lblwt";
            this.lblwt.Size = new System.Drawing.Size(50, 27);
            this.lblwt.TabIndex = 31;
            this.lblwt.Text = "وزن (کلو)";
            // 
            // uiButton2
            // 
            this.uiButton2.Image = global::MandiPOS.Properties.Resources.download;
            this.uiButton2.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.AfterText;
            this.uiButton2.ImageSize = new System.Drawing.Size(32, 32);
            this.uiButton2.Location = new System.Drawing.Point(49, 41);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(37, 33);
            this.uiButton2.TabIndex = 32;
            this.uiButton2.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // uiButton3
            // 
            this.uiButton3.BackColor = System.Drawing.Color.Transparent;
            this.uiButton3.Image = global::MandiPOS.Properties.Resources.download__1_;
            this.uiButton3.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.AfterText;
            this.uiButton3.ImageSize = new System.Drawing.Size(32, 32);
            this.uiButton3.Location = new System.Drawing.Point(94, 3);
            this.uiButton3.Name = "uiButton3";
            this.uiButton3.Size = new System.Drawing.Size(44, 34);
            this.uiButton3.TabIndex = 33;
            this.uiButton3.Click += new System.EventHandler(this.uiButton3_Click);
            // 
            // uiCheckBox1
            // 
            this.uiCheckBox1.Location = new System.Drawing.Point(420, 40);
            this.uiCheckBox1.Name = "uiCheckBox1";
            this.uiCheckBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.uiCheckBox1.Size = new System.Drawing.Size(104, 30);
            this.uiCheckBox1.TabIndex = 36;
            this.uiCheckBox1.Text = "اندراج وزن";
            this.uiCheckBox1.CheckedChanged += new System.EventHandler(this.uiCheckBox1_CheckedChanged);
            // 
            // cmbStock
            // 
            this.cmbStock.DataSource = this.bsStock;
            cmbStock_DesignTimeLayout.LayoutString = resources.GetString("cmbStock_DesignTimeLayout.LayoutString");
            this.cmbStock.DesignTimeLayout = cmbStock_DesignTimeLayout;
            this.cmbStock.DisplayMember = "Title";
            this.cmbStock.Location = new System.Drawing.Point(392, 113);
            this.cmbStock.Name = "cmbStock";
            this.cmbStock.SelectedIndex = -1;
            this.cmbStock.SelectedItem = null;
            this.cmbStock.Size = new System.Drawing.Size(255, 35);
            this.cmbStock.TabIndex = 37;
            this.cmbStock.ValueMember = "SourceID";
            // 
            // bsStock
            // 
            this.bsStock.DataSource = typeof(MandiPOS.CLasses.clsStock);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(612, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 27);
            this.label10.TabIndex = 38;
            this.label10.Text = "سٹاک";
            // 
            // frmBVNew2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1260, 630);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbStock);
            this.Controls.Add(this.dgvHelp);
            this.Controls.Add(this.uiCheckBox1);
            this.Controls.Add(this.uiButton3);
            this.Controls.Add(this.uiButton2);
            this.Controls.Add(this.lblwt);
            this.Controls.Add(this._wt);
            this.Controls.Add(this.txtVno);
            this.Controls.Add(this.grpMode);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.partyBal);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this._cr);
            this.Controls.Add(this._dr);
            this.Controls.Add(this._rate);
            this.Controls.Add(this._qty);
            this.Controls.Add(this._items);
            this.Controls.Add(this._narration);
            this.Controls.Add(this._name);
            this.Controls.Add(this._code);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtp);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmBVNew2";
            this.Text = "frmBVNew";
            this.groupBox1.ResumeLayout(false);
            this.grpMode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsParties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Janus.Windows.CalendarCombo.CalendarCombo dtp;
        private System.Windows.Forms.GroupBox groupBox1;
        private Janus.Windows.EditControls.UIRadioButton rbSeed;
        private Janus.Windows.EditControls.UIRadioButton rbOther;
        private System.Windows.Forms.GroupBox grpMode;
        private Janus.Windows.EditControls.UIRadioButton rbCredit;
        private Janus.Windows.EditControls.UIRadioButton rbDebit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private Janus.Windows.GridEX.EditControls.NumericEditBox _code;
        private Janus.Windows.GridEX.EditControls.EditBox _name;
        private Janus.Windows.GridEX.EditControls.EditBox _narration;
        private Janus.Windows.EditControls.UIComboBox _items;
        private Janus.Windows.GridEX.EditControls.NumericEditBox _qty;
        private Janus.Windows.GridEX.EditControls.NumericEditBox _rate;
        private Janus.Windows.GridEX.EditControls.NumericEditBox _dr;
        private Janus.Windows.GridEX.EditControls.NumericEditBox _cr;
        private Janus.Windows.GridEX.GridEX dgv;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private System.Windows.Forms.BindingSource bsCart;
        private System.Windows.Forms.BindingSource bsItems;
        private System.Windows.Forms.BindingSource bsParties;
        private Janus.Windows.GridEX.GridEX dgvHelp;
        private System.Windows.Forms.Label partyBal;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.NumericUpDown txtVno;
        private Janus.Windows.GridEX.EditControls.NumericEditBox _wt;
        private System.Windows.Forms.Label lblwt;
        private Janus.Windows.EditControls.UIButton uiButton2;
        private Janus.Windows.EditControls.UIButton uiButton3;
        private Janus.Windows.EditControls.UICheckBox uiCheckBox1;
        private Janus.Windows.GridEX.EditControls.MultiColumnCombo cmbStock;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.BindingSource bsStock;
    }
}