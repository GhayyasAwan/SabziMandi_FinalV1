namespace MandiPOS.GUI
{
    partial class frmAccountsNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccountsNew));
            this.label1 = new System.Windows.Forms.Label();
            this.txtCode = new Janus.Windows.GridEX.EditControls.EditBox();
            this.visualStyleManager1 = new Janus.Windows.Common.VisualStyleManager(this.components);
            this.txtName = new Janus.Windows.GridEX.EditControls.EditBox();
            this.txtContact = new Janus.Windows.GridEX.EditControls.EditBox();
            this.cmbCity = new Janus.Windows.EditControls.UIComboBox();
            this.bsCity = new System.Windows.Forms.BindingSource(this.components);
            this.txtDebit = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.txtCredit = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.grpRef = new Janus.Windows.EditControls.UIGroupBox();
            this.cmbRefParty = new Janus.Windows.EditControls.UIComboBox();
            this.bss = new System.Windows.Forms.BindingSource(this.components);
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.txtRefName = new Janus.Windows.GridEX.EditControls.EditBox();
            this.rbOther = new Janus.Windows.EditControls.UIRadioButton();
            this.rbCustomer = new Janus.Windows.EditControls.UIRadioButton();
            this.rbVendor = new Janus.Windows.EditControls.UIRadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRemarks = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCommisionRatio = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.txtCreditLimit = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dgv = new Janus.Windows.GridEX.GridEX();
            this.bsAccount1 = new System.Windows.Forms.BindingSource(this.components);
            this.bsAccounts2 = new System.Windows.Forms.BindingSource(this.components);
            this.txtOldAccNo = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.label10 = new System.Windows.Forms.Label();
            this.uiCheckBox1 = new Janus.Windows.EditControls.UICheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpRef)).BeginInit();
            this.grpRef.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAccount1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAccounts2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1293, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "کوڈ";
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(1234, 55);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(87, 39);
            this.txtCode.TabIndex = 1;
            this.txtCode.VisualStyleManager = this.visualStyleManager1;
            // 
            // visualStyleManager1
            // 
            janusColorScheme1.HighlightTextColor = System.Drawing.SystemColors.HighlightText;
            janusColorScheme1.Name = "Scheme0";
            janusColorScheme1.OfficeCustomColor = System.Drawing.Color.Empty;
            janusColorScheme1.VisualStyle = Janus.Windows.Common.VisualStyle.Office2007;
            this.visualStyleManager1.ColorSchemes.Add(janusColorScheme1);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(904, 55);
            this.txtName.Name = "txtName";
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.Size = new System.Drawing.Size(324, 39);
            this.txtName.TabIndex = 2;
            this.txtName.VisualStyleManager = this.visualStyleManager1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(739, 54);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(159, 39);
            this.txtContact.TabIndex = 3;
            this.txtContact.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.txtContact.VisualStyleManager = this.visualStyleManager1;
            // 
            // cmbCity
            // 
            this.cmbCity.DataSource = this.bsCity;
            this.cmbCity.DisplayMember = "CityName";
            this.cmbCity.Location = new System.Drawing.Point(549, 54);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbCity.Size = new System.Drawing.Size(184, 39);
            this.cmbCity.TabIndex = 4;
            this.cmbCity.ValueMember = "ID";
            this.cmbCity.VisualStyleManager = this.visualStyleManager1;
            // 
            // bsCity
            // 
            this.bsCity.DataSource = typeof(MandiPOS.CLasses.tblCity);
            // 
            // txtDebit
            // 
            this.txtDebit.Location = new System.Drawing.Point(395, 55);
            this.txtDebit.Name = "txtDebit";
            this.txtDebit.Size = new System.Drawing.Size(148, 39);
            this.txtDebit.TabIndex = 5;
            this.txtDebit.Text = "0.00";
            this.txtDebit.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.txtDebit.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDebit.VisualStyleManager = this.visualStyleManager1;
            // 
            // txtCredit
            // 
            this.txtCredit.Location = new System.Drawing.Point(241, 55);
            this.txtCredit.Name = "txtCredit";
            this.txtCredit.Size = new System.Drawing.Size(148, 39);
            this.txtCredit.TabIndex = 6;
            this.txtCredit.Text = "0.00";
            this.txtCredit.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.txtCredit.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCredit.VisualStyleManager = this.visualStyleManager1;
            // 
            // grpRef
            // 
            this.grpRef.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRef.Controls.Add(this.cmbRefParty);
            this.grpRef.Controls.Add(this.uiButton1);
            this.grpRef.Controls.Add(this.txtRefName);
            this.grpRef.Controls.Add(this.rbOther);
            this.grpRef.Controls.Add(this.rbCustomer);
            this.grpRef.Controls.Add(this.rbVendor);
            this.grpRef.Location = new System.Drawing.Point(12, 12);
            this.grpRef.Name = "grpRef";
            this.grpRef.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grpRef.Size = new System.Drawing.Size(223, 183);
            this.grpRef.TabIndex = 7;
            this.grpRef.Text = "معرفت";
            this.grpRef.VisualStyleManager = this.visualStyleManager1;
            // 
            // cmbRefParty
            // 
            this.cmbRefParty.DataSource = this.bss;
            this.cmbRefParty.DisplayMember = "AccountTitle";
            this.cmbRefParty.Location = new System.Drawing.Point(10, 136);
            this.cmbRefParty.Name = "cmbRefParty";
            this.cmbRefParty.Size = new System.Drawing.Size(207, 39);
            this.cmbRefParty.TabIndex = 3;
            this.cmbRefParty.ValueMember = "ID";
            this.cmbRefParty.VisualStyleManager = this.visualStyleManager1;
            // 
            // bss
            // 
            this.bss.DataSource = typeof(MandiPOS.CLasses.DetailAccounts);
            // 
            // uiButton1
            // 
            this.uiButton1.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiButton1.Location = new System.Drawing.Point(0, -5);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(107, 40);
            this.uiButton1.TabIndex = 22;
            this.uiButton1.Text = "Import";
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // txtRefName
            // 
            this.txtRefName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRefName.Location = new System.Drawing.Point(10, 136);
            this.txtRefName.Name = "txtRefName";
            this.txtRefName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRefName.Size = new System.Drawing.Size(207, 39);
            this.txtRefName.TabIndex = 21;
            this.txtRefName.VisualStyleManager = this.visualStyleManager1;
            this.txtRefName.TextChanged += new System.EventHandler(this.txtRefName_TextChanged);
            // 
            // rbOther
            // 
            this.rbOther.AutoSize = true;
            this.rbOther.Location = new System.Drawing.Point(6, 46);
            this.rbOther.Name = "rbOther";
            this.rbOther.Size = new System.Drawing.Size(41, 36);
            this.rbOther.TabIndex = 2;
            this.rbOther.Text = "دیگر";
            this.rbOther.VisualStyleManager = this.visualStyleManager1;
            this.rbOther.CheckedChanged += new System.EventHandler(this.rbOther_CheckedChanged);
            // 
            // rbCustomer
            // 
            this.rbCustomer.AutoSize = true;
            this.rbCustomer.Location = new System.Drawing.Point(67, 46);
            this.rbCustomer.Name = "rbCustomer";
            this.rbCustomer.Size = new System.Drawing.Size(46, 36);
            this.rbCustomer.TabIndex = 1;
            this.rbCustomer.Text = "گاہک";
            this.rbCustomer.VisualStyleManager = this.visualStyleManager1;
            this.rbCustomer.CheckedChanged += new System.EventHandler(this.rbCustomer_CheckedChanged);
            // 
            // rbVendor
            // 
            this.rbVendor.AutoSize = true;
            this.rbVendor.Checked = true;
            this.rbVendor.Location = new System.Drawing.Point(140, 46);
            this.rbVendor.Name = "rbVendor";
            this.rbVendor.Size = new System.Drawing.Size(54, 36);
            this.rbVendor.TabIndex = 0;
            this.rbVendor.TabStop = true;
            this.rbVendor.Text = "بیوپاری";
            this.rbVendor.VisualStyleManager = this.visualStyleManager1;
            this.rbVendor.CheckedChanged += new System.EventHandler(this.rbVendor_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1192, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 32);
            this.label2.TabIndex = 8;
            this.label2.Text = "نام";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(832, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 32);
            this.label3.TabIndex = 9;
            this.label3.Text = "رابطہ نمبر";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(695, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 32);
            this.label4.TabIndex = 10;
            this.label4.Text = "شہر";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(472, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 32);
            this.label5.TabIndex = 11;
            this.label5.Text = "سابقہ بنام";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(320, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 32);
            this.label6.TabIndex = 12;
            this.label6.Text = "سابقہ جمع";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1264, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 32);
            this.label7.TabIndex = 14;
            this.label7.Text = "تفصیل";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemarks.Location = new System.Drawing.Point(703, 148);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRemarks.Size = new System.Drawing.Size(619, 39);
            this.txtRemarks.TabIndex = 13;
            this.txtRemarks.VisualStyleManager = this.visualStyleManager1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(337, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 32);
            this.label8.TabIndex = 18;
            this.label8.Text = "کمیشن";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(472, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 32);
            this.label9.TabIndex = 17;
            this.label9.Text = "بیلنس حد";
            // 
            // txtCommisionRatio
            // 
            this.txtCommisionRatio.Location = new System.Drawing.Point(241, 148);
            this.txtCommisionRatio.Name = "txtCommisionRatio";
            this.txtCommisionRatio.Size = new System.Drawing.Size(148, 39);
            this.txtCommisionRatio.TabIndex = 16;
            this.txtCommisionRatio.Text = "0.00";
            this.txtCommisionRatio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.txtCommisionRatio.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCommisionRatio.VisualStyleManager = this.visualStyleManager1;
            // 
            // txtCreditLimit
            // 
            this.txtCreditLimit.Location = new System.Drawing.Point(395, 148);
            this.txtCreditLimit.Name = "txtCreditLimit";
            this.txtCreditLimit.Size = new System.Drawing.Size(148, 39);
            this.txtCreditLimit.TabIndex = 15;
            this.txtCreditLimit.Text = "0.00";
            this.txtCreditLimit.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.txtCreditLimit.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCreditLimit.VisualStyleManager = this.visualStyleManager1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1150, 201);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(171, 519);
            this.flowLayoutPanel1.TabIndex = 19;
            this.flowLayoutPanel1.Visible = false;
            // 
            // dgv
            // 
            this.dgv.AllowColumnDrag = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnAutoResize = true;
            this.dgv.DataSource = this.bsAccount1;
            dgv_DesignTimeLayout.LayoutString = resources.GetString("dgv_DesignTimeLayout.LayoutString");
            this.dgv.DesignTimeLayout = dgv_DesignTimeLayout;
            this.dgv.DynamicFiltering = true;
            this.dgv.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.dgv.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.dgv.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.dgv.GroupByBoxVisible = false;
            this.dgv.Location = new System.Drawing.Point(12, 201);
            this.dgv.Name = "dgv";
            this.dgv.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgv.Size = new System.Drawing.Size(1309, 519);
            this.dgv.TabIndex = 20;
            this.dgv.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.dgv.VisualStyleManager = this.visualStyleManager1;
            // 
            // bsAccount1
            // 
            this.bsAccount1.DataSource = typeof(MandiPOS.CLasses.DetailAccountView);
            // 
            // bsAccounts2
            // 
            this.bsAccounts2.DataSource = typeof(MandiPOS.CLasses.DetailAccountView);
            // 
            // txtOldAccNo
            // 
            this.txtOldAccNo.Location = new System.Drawing.Point(549, 148);
            this.txtOldAccNo.Name = "txtOldAccNo";
            this.txtOldAccNo.Size = new System.Drawing.Size(148, 39);
            this.txtOldAccNo.TabIndex = 21;
            this.txtOldAccNo.Text = "0";
            this.txtOldAccNo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.txtOldAccNo.Value = 0;
            this.txtOldAccNo.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32;
            this.txtOldAccNo.VisualStyleManager = this.visualStyleManager1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(624, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 32);
            this.label10.TabIndex = 22;
            this.label10.Text = "پرانا کھاتہ نمبر";
            // 
            // uiCheckBox1
            // 
            this.uiCheckBox1.Location = new System.Drawing.Point(241, 98);
            this.uiCheckBox1.Name = "uiCheckBox1";
            this.uiCheckBox1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.uiCheckBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.uiCheckBox1.Size = new System.Drawing.Size(54, 38);
            this.uiCheckBox1.TabIndex = 23;
            this.uiCheckBox1.Text = " ایکٹو";
            // 
            // frmAccountsNew
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1333, 732);
            this.Controls.Add(this.uiCheckBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtOldAccNo);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCommisionRatio);
            this.Controls.Add(this.txtCreditLimit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grpRef);
            this.Controls.Add(this.txtCredit);
            this.Controls.Add(this.txtDebit);
            this.Controls.Add(this.cmbCity);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1024, 718);
            this.Name = "frmAccountsNew";
            this.Text = "frmAccountsNew";
            ((System.ComponentModel.ISupportInitialize)(this.bsCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpRef)).EndInit();
            this.grpRef.ResumeLayout(false);
            this.grpRef.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAccount1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAccounts2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Janus.Windows.GridEX.EditControls.EditBox txtCode;
        private Janus.Windows.GridEX.EditControls.EditBox txtName;
        private Janus.Windows.GridEX.EditControls.EditBox txtContact;
        private Janus.Windows.EditControls.UIComboBox cmbCity;
        private Janus.Windows.GridEX.EditControls.NumericEditBox txtDebit;
        private Janus.Windows.GridEX.EditControls.NumericEditBox txtCredit;
        private Janus.Windows.EditControls.UIGroupBox grpRef;
        private Janus.Windows.EditControls.UIRadioButton rbOther;
        private Janus.Windows.EditControls.UIRadioButton rbCustomer;
        private Janus.Windows.EditControls.UIRadioButton rbVendor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Janus.Windows.GridEX.EditControls.EditBox txtRemarks;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private Janus.Windows.GridEX.EditControls.NumericEditBox txtCommisionRatio;
        private Janus.Windows.GridEX.EditControls.NumericEditBox txtCreditLimit;
        private Janus.Windows.Common.VisualStyleManager visualStyleManager1;
        private System.Windows.Forms.BindingSource bsCity;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Janus.Windows.GridEX.GridEX dgv;
        private System.Windows.Forms.BindingSource bsAccount1;
        private System.Windows.Forms.BindingSource bsAccounts2;
        private Janus.Windows.EditControls.UIComboBox cmbRefParty;
        private System.Windows.Forms.BindingSource bss;
        private Janus.Windows.GridEX.EditControls.EditBox txtRefName;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private Janus.Windows.GridEX.EditControls.NumericEditBox txtOldAccNo;
        private System.Windows.Forms.Label label10;
        private Janus.Windows.EditControls.UICheckBox uiCheckBox1;
    }
}