namespace MandiPOS.GUI
{
    partial class frmVoucherNew
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
            Janus.Windows.GridEX.GridEXLayout gridEX1_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVoucherNew));
            Janus.Windows.GridEX.GridEXLayout dgvHelp_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.visualStyleManager1 = new Janus.Windows.Common.VisualStyleManager(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.txtName = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCashBank = new Janus.Windows.EditControls.UIComboBox();
            this.bsCashBank = new System.Windows.Forms.BindingSource(this.components);
            this.txtNarration = new Janus.Windows.GridEX.EditControls.EditBox();
            this.txtAmount = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            this.bsCart = new System.Windows.Forms.BindingSource(this.components);
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.dgvHelp = new Janus.Windows.GridEX.GridEX();
            this.bsParties = new System.Windows.Forms.BindingSource(this.components);
            this.partyBal = new System.Windows.Forms.Label();
            this.txtVoucherNumber = new System.Windows.Forms.NumericUpDown();
            this.uiButton2 = new Janus.Windows.EditControls.UIButton();
            this.uiButton3 = new Janus.Windows.EditControls.UIButton();
            this.uiButton4 = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.bsCashBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsParties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVoucherNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(757, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "تاریخ";
            // 
            // dtp
            // 
            this.dtp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtp.CustomFormat = "dd-MMM-yyyy";
            this.dtp.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtp.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            this.dtp.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp.Location = new System.Drawing.Point(591, 6);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(160, 30);
            this.dtp.TabIndex = 1;
            this.dtp.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            this.dtp.VisualStyleManager = this.visualStyleManager1;
            // 
            // visualStyleManager1
            // 
            janusColorScheme1.HighlightTextColor = System.Drawing.SystemColors.HighlightText;
            janusColorScheme1.Name = "Scheme0";
            janusColorScheme1.OfficeCustomColor = System.Drawing.Color.Empty;
            this.visualStyleManager1.ColorSchemes.Add(janusColorScheme1);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(767, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "کوڈ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(711, 93);
            this.txtCode.Name = "txtCode";
            this.txtCode.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowNull;
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(80, 35);
            this.txtCode.TabIndex = 3;
            this.txtCode.TabStop = false;
            this.txtCode.Text = "";
            this.txtCode.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.txtCode.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32;
            this.txtCode.VisualStyleManager = this.visualStyleManager1;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(514, 93);
            this.txtName.Name = "txtName";
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.Size = new System.Drawing.Size(191, 35);
            this.txtName.TabIndex = 4;
            this.txtName.VisualStyleManager = this.visualStyleManager1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(662, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 27);
            this.label3.TabIndex = 5;
            this.label3.Text = "نام پارٹی";
            // 
            // txtCashBank
            // 
            this.txtCashBank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCashBank.DataSource = this.bsCashBank;
            this.txtCashBank.DisplayMember = "AccountTitle";
            this.txtCashBank.Location = new System.Drawing.Point(362, 92);
            this.txtCashBank.Name = "txtCashBank";
            this.txtCashBank.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCashBank.Size = new System.Drawing.Size(146, 35);
            this.txtCashBank.TabIndex = 6;
            this.txtCashBank.ValueMember = "ID";
            this.txtCashBank.VisualStyleManager = this.visualStyleManager1;
            // 
            // bsCashBank
            // 
            this.bsCashBank.DataSource = typeof(MandiPOS.CLasses.DetailAccountView);
            // 
            // txtNarration
            // 
            this.txtNarration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNarration.Location = new System.Drawing.Point(140, 93);
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNarration.Size = new System.Drawing.Size(216, 35);
            this.txtNarration.TabIndex = 7;
            this.txtNarration.VisualStyleManager = this.visualStyleManager1;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(12, 93);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(122, 35);
            this.txtAmount.TabIndex = 8;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtAmount.VisualStyleManager = this.visualStyleManager1;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(451, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 27);
            this.label4.TabIndex = 9;
            this.label4.Text = "کیش / بینک";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(318, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 27);
            this.label5.TabIndex = 10;
            this.label5.Text = "تفصیل";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(108, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 27);
            this.label6.TabIndex = 11;
            this.label6.Text = "رقم";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(357, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(44, 27);
            this.lblTitle.TabIndex = 12;
            this.lblTitle.Text = "بنام ووچر";
            // 
            // gridEX1
            // 
            this.gridEX1.AlternatingColors = true;
            this.gridEX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridEX1.ColumnAutoResize = true;
            this.gridEX1.DataSource = this.bsCart;
            gridEX1_DesignTimeLayout.LayoutString = resources.GetString("gridEX1_DesignTimeLayout.LayoutString");
            this.gridEX1.DesignTimeLayout = gridEX1_DesignTimeLayout;
            this.gridEX1.GroupByBoxVisible = false;
            this.gridEX1.Location = new System.Drawing.Point(12, 145);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridEX1.Size = new System.Drawing.Size(779, 418);
            this.gridEX1.TabIndex = 13;
            this.gridEX1.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEX1.TotalRowFormatStyle.BackColor = System.Drawing.SystemColors.Info;
            this.gridEX1.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gridEX1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.gridEX1.VisualStyleManager = this.visualStyleManager1;
            // 
            // bsCart
            // 
            this.bsCart.DataSource = typeof(MandiPOS.CLasses.VoucherCart);
            // 
            // uiButton1
            // 
            this.uiButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uiButton1.Image = global::MandiPOS.Properties.Resources.save_close_48px;
            this.uiButton1.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.AfterText;
            this.uiButton1.ImageSize = new System.Drawing.Size(32, 32);
            this.uiButton1.Location = new System.Drawing.Point(667, 522);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(124, 41);
            this.uiButton1.TabIndex = 14;
            this.uiButton1.Text = "محفوظ کریں";
            this.uiButton1.Visible = false;
            this.uiButton1.VisualStyleManager = this.visualStyleManager1;
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // dgvHelp
            // 
            this.dgvHelp.ColumnAutoResize = true;
            this.dgvHelp.DataSource = this.bsParties;
            dgvHelp_DesignTimeLayout.LayoutString = resources.GetString("dgvHelp_DesignTimeLayout.LayoutString");
            this.dgvHelp.DesignTimeLayout = dgvHelp_DesignTimeLayout;
            this.dgvHelp.GroupByBoxVisible = false;
            this.dgvHelp.Location = new System.Drawing.Point(267, 134);
            this.dgvHelp.Name = "dgvHelp";
            this.dgvHelp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvHelp.Size = new System.Drawing.Size(438, 340);
            this.dgvHelp.TabIndex = 15;
            this.dgvHelp.Visible = false;
            this.dgvHelp.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.dgvHelp.VisualStyleManager = this.visualStyleManager1;
            // 
            // bsParties
            // 
            this.bsParties.DataSource = typeof(MandiPOS.CLasses.DetailAccountView);
            // 
            // partyBal
            // 
            this.partyBal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.partyBal.AutoSize = true;
            this.partyBal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partyBal.Location = new System.Drawing.Point(514, 59);
            this.partyBal.Name = "partyBal";
            this.partyBal.Size = new System.Drawing.Size(19, 20);
            this.partyBal.TabIndex = 16;
            this.partyBal.Text = "0";
            // 
            // txtVoucherNumber
            // 
            this.txtVoucherNumber.Font = new System.Drawing.Font("Verdana", 12F);
            this.txtVoucherNumber.Location = new System.Drawing.Point(12, 7);
            this.txtVoucherNumber.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.txtVoucherNumber.Name = "txtVoucherNumber";
            this.txtVoucherNumber.Size = new System.Drawing.Size(87, 27);
            this.txtVoucherNumber.TabIndex = 17;
            this.txtVoucherNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // uiButton2
            // 
            this.uiButton2.Image = global::MandiPOS.Properties.Resources.download;
            this.uiButton2.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.AfterText;
            this.uiButton2.ImageSize = new System.Drawing.Size(32, 32);
            this.uiButton2.Location = new System.Drawing.Point(55, 39);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(37, 33);
            this.uiButton2.TabIndex = 34;
            this.uiButton2.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // uiButton3
            // 
            this.uiButton3.Image = global::MandiPOS.Properties.Resources.save_close_48px;
            this.uiButton3.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.AfterText;
            this.uiButton3.ImageSize = new System.Drawing.Size(32, 32);
            this.uiButton3.Location = new System.Drawing.Point(12, 40);
            this.uiButton3.Name = "uiButton3";
            this.uiButton3.Size = new System.Drawing.Size(37, 33);
            this.uiButton3.TabIndex = 33;
            this.uiButton3.Click += new System.EventHandler(this.uiButton3_Click);
            // 
            // uiButton4
            // 
            this.uiButton4.BackColor = System.Drawing.Color.Transparent;
            this.uiButton4.Image = global::MandiPOS.Properties.Resources.download__1_;
            this.uiButton4.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.AfterText;
            this.uiButton4.ImageSize = new System.Drawing.Size(32, 32);
            this.uiButton4.Location = new System.Drawing.Point(113, 2);
            this.uiButton4.Name = "uiButton4";
            this.uiButton4.Size = new System.Drawing.Size(44, 34);
            this.uiButton4.TabIndex = 35;
            this.uiButton4.Click += new System.EventHandler(this.uiButton4_Click);
            // 
            // frmVoucherNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(803, 575);
            this.Controls.Add(this.uiButton4);
            this.Controls.Add(this.uiButton2);
            this.Controls.Add(this.uiButton3);
            this.Controls.Add(this.txtVoucherNumber);
            this.Controls.Add(this.partyBal);
            this.Controls.Add(this.dgvHelp);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.gridEX1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtNarration);
            this.Controls.Add(this.txtCashBank);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtp);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "frmVoucherNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Voucher";
            ((System.ComponentModel.ISupportInitialize)(this.bsCashBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsParties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVoucherNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Janus.Windows.CalendarCombo.CalendarCombo dtp;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.GridEX.EditControls.NumericEditBox txtCode;
        private Janus.Windows.GridEX.EditControls.EditBox txtName;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.EditControls.UIComboBox txtCashBank;
        private Janus.Windows.GridEX.EditControls.EditBox txtNarration;
        private Janus.Windows.GridEX.EditControls.NumericEditBox txtAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTitle;
        private Janus.Windows.GridEX.GridEX gridEX1;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private System.Windows.Forms.BindingSource bsCart;
        private System.Windows.Forms.BindingSource bsParties;
        private System.Windows.Forms.BindingSource bsCashBank;
        private Janus.Windows.GridEX.GridEX dgvHelp;
        private Janus.Windows.Common.VisualStyleManager visualStyleManager1;
        private System.Windows.Forms.Label partyBal;
        private System.Windows.Forms.NumericUpDown txtVoucherNumber;
        private Janus.Windows.EditControls.UIButton uiButton2;
        private Janus.Windows.EditControls.UIButton uiButton3;
        private Janus.Windows.EditControls.UIButton uiButton4;
    }
}