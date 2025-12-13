namespace MandiPOS.GUI
{
    partial class frmAccountsNew2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccountsNew2));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCredit = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.txtDebit = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.cmbCity = new Janus.Windows.EditControls.UIComboBox();
            this.bsCity = new System.Windows.Forms.BindingSource(this.components);
            this.txtContact = new Janus.Windows.GridEX.EditControls.EditBox();
            this.txtName = new Janus.Windows.GridEX.EditControls.EditBox();
            this.txtCode = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            this.bsAccount1 = new System.Windows.Forms.BindingSource(this.components);
            this.txtOldAcc = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label7 = new System.Windows.Forms.Label();
            this.uiCheckBox1 = new Janus.Windows.EditControls.UICheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAccount1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(963, 45);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(95, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 27);
            this.label6.TabIndex = 12;
            this.label6.Text = "سابقہ جمع";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(247, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 27);
            this.label5.TabIndex = 10;
            this.label5.Text = "سابقہ بنام";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(372, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 27);
            this.label4.TabIndex = 8;
            this.label4.Text = "شہر";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(628, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 27);
            this.label3.TabIndex = 4;
            this.label3.Text = "رابطہ نمبر";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(826, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "نام";
            // 
            // txtCredit
            // 
            this.txtCredit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredit.Location = new System.Drawing.Point(16, 87);
            this.txtCredit.Name = "txtCredit";
            this.txtCredit.Size = new System.Drawing.Size(125, 35);
            this.txtCredit.TabIndex = 13;
            this.txtCredit.Text = "0.00";
            this.txtCredit.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.txtCredit.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtDebit
            // 
            this.txtDebit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebit.Location = new System.Drawing.Point(147, 87);
            this.txtDebit.Name = "txtDebit";
            this.txtDebit.Size = new System.Drawing.Size(119, 35);
            this.txtDebit.TabIndex = 11;
            this.txtDebit.Text = "0.00";
            this.txtDebit.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.txtDebit.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // cmbCity
            // 
            this.cmbCity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCity.DataSource = this.bsCity;
            this.cmbCity.DisplayMember = "CityName";
            this.cmbCity.Location = new System.Drawing.Point(272, 87);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbCity.Size = new System.Drawing.Size(125, 35);
            this.cmbCity.TabIndex = 9;
            this.cmbCity.ValueMember = "ID";
            // 
            // bsCity
            // 
            this.bsCity.DataSource = typeof(MandiPOS.CLasses.tblCity);
            // 
            // txtContact
            // 
            this.txtContact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContact.Location = new System.Drawing.Point(544, 86);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(129, 35);
            this.txtContact.TabIndex = 5;
            this.txtContact.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(679, 87);
            this.txtName.Name = "txtName";
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.Size = new System.Drawing.Size(183, 35);
            this.txtName.TabIndex = 3;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(868, 87);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(87, 35);
            this.txtCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(927, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "کوڈ";
            // 
            // gridEX1
            // 
            this.gridEX1.AllowColumnDrag = false;
            this.gridEX1.AlternatingColors = true;
            this.gridEX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridEX1.AutoEdit = true;
            this.gridEX1.ColumnAutoResize = true;
            this.gridEX1.DataSource = this.bsAccount1;
            gridEX1_DesignTimeLayout.LayoutString = resources.GetString("gridEX1_DesignTimeLayout.LayoutString");
            this.gridEX1.DesignTimeLayout = gridEX1_DesignTimeLayout;
            this.gridEX1.DynamicFiltering = true;
            this.gridEX1.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gridEX1.GroupByBoxVisible = false;
            this.gridEX1.Location = new System.Drawing.Point(12, 127);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.OfficeColorScheme = Janus.Windows.GridEX.OfficeColorScheme.Blue;
            this.gridEX1.RecordNavigator = true;
            this.gridEX1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridEX1.Size = new System.Drawing.Size(939, 440);
            this.gridEX1.TabIndex = 14;
            this.gridEX1.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEX1.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gridEX1.UpdateMode = Janus.Windows.GridEX.UpdateMode.CellUpdate;
            this.gridEX1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.gridEX1.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.gridEX1_FormattingRow);
            // 
            // bsAccount1
            // 
            this.bsAccount1.DataSource = typeof(MandiPOS.CLasses.DetailAccountView);
            // 
            // txtOldAcc
            // 
            this.txtOldAcc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOldAcc.Location = new System.Drawing.Point(403, 86);
            this.txtOldAcc.Name = "txtOldAcc";
            this.txtOldAcc.Size = new System.Drawing.Size(135, 35);
            this.txtOldAcc.TabIndex = 7;
            this.txtOldAcc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(477, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 27);
            this.label7.TabIndex = 6;
            this.label7.Text = "پرانا کھاتہ نمبر";
            // 
            // uiCheckBox1
            // 
            this.uiCheckBox1.Location = new System.Drawing.Point(16, 49);
            this.uiCheckBox1.Name = "uiCheckBox1";
            this.uiCheckBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.uiCheckBox1.Size = new System.Drawing.Size(57, 32);
            this.uiCheckBox1.TabIndex = 16;
            this.uiCheckBox1.Text = "ایکٹو";
            // 
            // frmAccountsNew2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(963, 579);
            this.Controls.Add(this.uiCheckBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtOldAcc);
            this.Controls.Add(this.gridEX1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCredit);
            this.Controls.Add(this.txtDebit);
            this.Controls.Add(this.cmbCity);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmAccountsNew2";
            this.Text = "frmAccountsNew2";
            ((System.ComponentModel.ISupportInitialize)(this.bsCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAccount1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.GridEX.EditControls.NumericEditBox txtCredit;
        private Janus.Windows.GridEX.EditControls.NumericEditBox txtDebit;
        private Janus.Windows.EditControls.UIComboBox cmbCity;
        private Janus.Windows.GridEX.EditControls.EditBox txtContact;
        private Janus.Windows.GridEX.EditControls.EditBox txtName;
        private Janus.Windows.GridEX.EditControls.EditBox txtCode;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.GridEX.GridEX gridEX1;
        private System.Windows.Forms.BindingSource bsAccount1;
        private System.Windows.Forms.BindingSource bsCity;
        private Janus.Windows.GridEX.EditControls.EditBox txtOldAcc;
        private System.Windows.Forms.Label label7;
        private Janus.Windows.EditControls.UICheckBox uiCheckBox1;
    }
}