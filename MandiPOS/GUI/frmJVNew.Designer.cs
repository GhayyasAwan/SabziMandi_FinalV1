namespace MandiPOS.GUI
{
    partial class frmJVNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJVNew));
            Janus.Windows.GridEX.GridEXLayout dgvHelp_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label2 = new System.Windows.Forms.Label();
            this._code = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this._name = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label3 = new System.Windows.Forms.Label();
            this._narration = new Janus.Windows.GridEX.EditControls.EditBox();
            this._cr = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this._dr = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgv = new Janus.Windows.GridEX.GridEX();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.dgvHelp = new Janus.Windows.GridEX.GridEX();
            this.bsParties = new System.Windows.Forms.BindingSource(this.components);
            this.partyBal = new System.Windows.Forms.Label();
            this.numericChartRangeControlClient1 = new DevExpress.XtraEditors.NumericChartRangeControlClient();
            this.txtVno = new System.Windows.Forms.NumericUpDown();
            this.grpMode = new System.Windows.Forms.GroupBox();
            this.rbCredit = new Janus.Windows.EditControls.UIRadioButton();
            this.rbDebit = new Janus.Windows.EditControls.UIRadioButton();
            this.uiButton3 = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsParties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericChartRangeControlClient1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVno)).BeginInit();
            this.grpMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(795, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "تاریخ";
            // 
            // dtp
            // 
            this.dtp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtp.CustomFormat = "dd-MM-yyyy";
            this.dtp.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            this.dtp.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp.Location = new System.Drawing.Point(629, 10);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(160, 26);
            this.dtp.TabIndex = 1;
            this.dtp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtp_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(805, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "کوڈ";
            // 
            // _code
            // 
            this._code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._code.EditMode = Janus.Windows.GridEX.NumericEditMode.Value;
            this._code.Location = new System.Drawing.Point(758, 90);
            this._code.Name = "_code";
            this._code.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowNull;
            this._code.ReadOnly = true;
            this._code.Size = new System.Drawing.Size(71, 35);
            this._code.TabIndex = 3;
            this._code.TabStop = false;
            this._code.Text = "";
            this._code.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32;
            // 
            // _name
            // 
            this._name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._name.Location = new System.Drawing.Point(594, 90);
            this._name.Name = "_name";
            this._name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._name.Size = new System.Drawing.Size(158, 35);
            this._name.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(709, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 27);
            this.label3.TabIndex = 4;
            this.label3.Text = "نام پارٹی";
            // 
            // _narration
            // 
            this._narration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._narration.Location = new System.Drawing.Point(240, 90);
            this._narration.Name = "_narration";
            this._narration.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._narration.Size = new System.Drawing.Size(348, 35);
            this._narration.TabIndex = 7;
            // 
            // _cr
            // 
            this._cr.EditMode = Janus.Windows.GridEX.NumericEditMode.Value;
            this._cr.Location = new System.Drawing.Point(12, 90);
            this._cr.Name = "_cr";
            this._cr.Size = new System.Drawing.Size(108, 35);
            this._cr.TabIndex = 11;
            this._cr.Text = "0.00";
            this._cr.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this._cr.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // _dr
            // 
            this._dr.EditMode = Janus.Windows.GridEX.NumericEditMode.Value;
            this._dr.Location = new System.Drawing.Point(126, 90);
            this._dr.Name = "_dr";
            this._dr.Size = new System.Drawing.Size(108, 35);
            this._dr.TabIndex = 9;
            this._dr.Text = "0.00";
            this._dr.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this._dr.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(550, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 27);
            this.label4.TabIndex = 6;
            this.label4.Text = "تفصیل";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 27);
            this.label5.TabIndex = 8;
            this.label5.Text = "رقم جمع";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(79, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 27);
            this.label6.TabIndex = 10;
            this.label6.Text = "رقم بنام";
            // 
            // dgv
            // 
            this.dgv.AllowColumnDrag = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnAutoResize = true;
            this.dgv.DataSource = this.bs;
            dgv_DesignTimeLayout.LayoutString = resources.GetString("dgv_DesignTimeLayout.LayoutString");
            this.dgv.DesignTimeLayout = dgv_DesignTimeLayout;
            this.dgv.GroupByBoxVisible = false;
            this.dgv.Location = new System.Drawing.Point(12, 139);
            this.dgv.Name = "dgv";
            this.dgv.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgv.Size = new System.Drawing.Size(817, 339);
            this.dgv.TabIndex = 12;
            this.dgv.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.dgv.TotalRowFormatStyle.BackColor = System.Drawing.SystemColors.Info;
            this.dgv.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.dgv.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            // 
            // bs
            // 
            this.bs.DataSource = typeof(MandiPOS.CLasses.JVCart);
            // 
            // uiButton1
            // 
            this.uiButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uiButton1.Image = global::MandiPOS.Properties.Resources.save_close_48px;
            this.uiButton1.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.AfterText;
            this.uiButton1.ImageSize = new System.Drawing.Size(32, 32);
            this.uiButton1.Location = new System.Drawing.Point(705, 484);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(124, 41);
            this.uiButton1.TabIndex = 13;
            this.uiButton1.Text = "محفوظ کریں";
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // dgvHelp
            // 
            this.dgvHelp.ColumnAutoResize = true;
            this.dgvHelp.DataSource = this.bsParties;
            dgvHelp_DesignTimeLayout.LayoutString = resources.GetString("dgvHelp_DesignTimeLayout.LayoutString");
            this.dgvHelp.DesignTimeLayout = dgvHelp_DesignTimeLayout;
            this.dgvHelp.GroupByBoxVisible = false;
            this.dgvHelp.Location = new System.Drawing.Point(347, 131);
            this.dgvHelp.Name = "dgvHelp";
            this.dgvHelp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvHelp.Size = new System.Drawing.Size(405, 287);
            this.dgvHelp.TabIndex = 14;
            this.dgvHelp.Visible = false;
            this.dgvHelp.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
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
            this.partyBal.Location = new System.Drawing.Point(591, 60);
            this.partyBal.Name = "partyBal";
            this.partyBal.Size = new System.Drawing.Size(19, 20);
            this.partyBal.TabIndex = 15;
            this.partyBal.Text = "0";
            // 
            // txtVno
            // 
            this.txtVno.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVno.Location = new System.Drawing.Point(12, 7);
            this.txtVno.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtVno.Name = "txtVno";
            this.txtVno.Size = new System.Drawing.Size(108, 26);
            this.txtVno.TabIndex = 16;
            this.txtVno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grpMode
            // 
            this.grpMode.BackColor = System.Drawing.Color.DodgerBlue;
            this.grpMode.Controls.Add(this.rbCredit);
            this.grpMode.Controls.Add(this.rbDebit);
            this.grpMode.Location = new System.Drawing.Point(365, -16);
            this.grpMode.Name = "grpMode";
            this.grpMode.Size = new System.Drawing.Size(178, 72);
            this.grpMode.TabIndex = 17;
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
            // uiButton3
            // 
            this.uiButton3.BackColor = System.Drawing.Color.Transparent;
            this.uiButton3.Image = ((System.Drawing.Image)(resources.GetObject("uiButton3.Image")));
            this.uiButton3.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.AfterText;
            this.uiButton3.ImageSize = new System.Drawing.Size(32, 32);
            this.uiButton3.Location = new System.Drawing.Point(126, 9);
            this.uiButton3.Name = "uiButton3";
            this.uiButton3.Size = new System.Drawing.Size(44, 34);
            this.uiButton3.TabIndex = 34;
            this.uiButton3.Click += new System.EventHandler(this.uiButton3_Click);
            // 
            // frmJVNew
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(841, 527);
            this.Controls.Add(this.uiButton3);
            this.Controls.Add(this.grpMode);
            this.Controls.Add(this.txtVno);
            this.Controls.Add(this.partyBal);
            this.Controls.Add(this.dgvHelp);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._dr);
            this.Controls.Add(this._cr);
            this.Controls.Add(this._narration);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._name);
            this.Controls.Add(this._code);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtp);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmJVNew";
            this.Text = "frmJVNew";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsParties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericChartRangeControlClient1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVno)).EndInit();
            this.grpMode.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Janus.Windows.CalendarCombo.CalendarCombo dtp;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.GridEX.EditControls.NumericEditBox _code;
        private Janus.Windows.GridEX.EditControls.EditBox _name;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.GridEX.EditControls.EditBox _narration;
        private Janus.Windows.GridEX.EditControls.NumericEditBox _cr;
        private Janus.Windows.GridEX.EditControls.NumericEditBox _dr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Janus.Windows.GridEX.GridEX dgv;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private System.Windows.Forms.BindingSource bsParties;
        private Janus.Windows.GridEX.GridEX dgvHelp;
        private System.Windows.Forms.BindingSource bs;
        private System.Windows.Forms.Label partyBal;
        private DevExpress.XtraEditors.NumericChartRangeControlClient numericChartRangeControlClient1;
        private System.Windows.Forms.NumericUpDown txtVno;
        private System.Windows.Forms.GroupBox grpMode;
        private Janus.Windows.EditControls.UIRadioButton rbCredit;
        private Janus.Windows.EditControls.UIRadioButton rbDebit;
        private Janus.Windows.EditControls.UIButton uiButton3;
    }
}