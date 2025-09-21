namespace MandiPOS.Reports
{
    partial class frmLedgerReport
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
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem1 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem2 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem3 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.GridEX.GridEXLayout dgvLedger_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLedgerReport));
            this.panel1 = new System.Windows.Forms.Panel();
            this.uiComboBox1 = new Janus.Windows.EditControls.UIComboBox();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.lblDateRange2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCommission = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblCreditLimit = new System.Windows.Forms.Label();
            this.lblcontact = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblRef = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLedger = new Janus.Windows.GridEX.GridEX();
            this.clsLedgerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLedger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsLedgerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uiComboBox1);
            this.panel1.Controls.Add(this.uiButton1);
            this.panel1.Controls.Add(this.lblDateRange2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblDateRange);
            this.panel1.Controls.Add(this.lblRemarks);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblCommission);
            this.panel1.Controls.Add(this.lblCode);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.lblCreditLimit);
            this.panel1.Controls.Add(this.lblcontact);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lblRef);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1532, 129);
            this.panel1.TabIndex = 0;
            // 
            // uiComboBox1
            // 
            this.uiComboBox1.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            uiComboBoxItem1.FormatStyle.Alpha = 0;
            uiComboBoxItem1.IsSeparator = false;
            uiComboBoxItem1.Text = "مکمل";
            uiComboBoxItem1.Value = 1;
            uiComboBoxItem2.FormatStyle.Alpha = 0;
            uiComboBoxItem2.IsSeparator = false;
            uiComboBoxItem2.Text = "بنام رقم";
            uiComboBoxItem2.Value = 2;
            uiComboBoxItem3.FormatStyle.Alpha = 0;
            uiComboBoxItem3.IsSeparator = false;
            uiComboBoxItem3.Text = "جمع رقم";
            uiComboBoxItem3.Value = 3;
            this.uiComboBox1.Items.AddRange(new Janus.Windows.EditControls.UIComboBoxItem[] {
            uiComboBoxItem1,
            uiComboBoxItem2,
            uiComboBoxItem3});
            this.uiComboBox1.Location = new System.Drawing.Point(119, 72);
            this.uiComboBox1.Name = "uiComboBox1";
            this.uiComboBox1.Size = new System.Drawing.Size(128, 46);
            this.uiComboBox1.TabIndex = 20;
            // 
            // uiButton1
            // 
            this.uiButton1.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.Button;
            this.uiButton1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiButton1.Image = global::MandiPOS.Properties.Resources.printernew;
            this.uiButton1.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.AfterText;
            this.uiButton1.ImageSize = new System.Drawing.Size(32, 32);
            this.uiButton1.Location = new System.Drawing.Point(12, 78);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(101, 38);
            this.uiButton1.TabIndex = 19;
            this.uiButton1.Text = "پرنٹ";
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // lblDateRange2
            // 
            this.lblDateRange2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateRange2.Font = new System.Drawing.Font("Arial Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateRange2.ForeColor = System.Drawing.Color.Maroon;
            this.lblDateRange2.Location = new System.Drawing.Point(287, 76);
            this.lblDateRange2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDateRange2.Name = "lblDateRange2";
            this.lblDateRange2.Size = new System.Drawing.Size(276, 52);
            this.lblDateRange2.TabIndex = 18;
            this.lblDateRange2.Text = "01-01-2025";
            this.lblDateRange2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDateRange2.Visible = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(568, 76);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 52);
            this.label6.TabIndex = 17;
            this.label6.Text = "تا";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.Visible = false;
            // 
            // lblDateRange
            // 
            this.lblDateRange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateRange.Font = new System.Drawing.Font("Arial Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateRange.ForeColor = System.Drawing.Color.Maroon;
            this.lblDateRange.Location = new System.Drawing.Point(634, 76);
            this.lblDateRange.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(276, 52);
            this.lblDateRange.TabIndex = 16;
            this.lblDateRange.Text = "01-01-2025";
            this.lblDateRange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDateRange.Visible = false;
            // 
            // lblRemarks
            // 
            this.lblRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRemarks.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarks.Location = new System.Drawing.Point(384, 68);
            this.lblRemarks.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(772, 48);
            this.lblRemarks.TabIndex = 15;
            this.lblRemarks.Text = "نام پارٹی";
            this.lblRemarks.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1318, 71);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 39);
            this.label4.TabIndex = 14;
            this.label4.Text = "کمیشن";
            // 
            // lblCommission
            // 
            this.lblCommission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCommission.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommission.Location = new System.Drawing.Point(1159, 62);
            this.lblCommission.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCommission.Name = "lblCommission";
            this.lblCommission.Size = new System.Drawing.Size(154, 52);
            this.lblCommission.TabIndex = 13;
            this.lblCommission.Text = "نام پارٹی";
            this.lblCommission.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCode
            // 
            this.lblCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCode.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.Location = new System.Drawing.Point(1382, 10);
            this.lblCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(96, 52);
            this.lblCode.TabIndex = 12;
            this.lblCode.Text = "کوڈ";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1483, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 39);
            this.label3.TabIndex = 11;
            this.label3.Text = "کوڈ";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1451, 71);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 39);
            this.label11.TabIndex = 10;
            this.label11.Text = "بیلنس حد";
            // 
            // lblCreditLimit
            // 
            this.lblCreditLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreditLimit.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditLimit.Location = new System.Drawing.Point(1292, 62);
            this.lblCreditLimit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCreditLimit.Name = "lblCreditLimit";
            this.lblCreditLimit.Size = new System.Drawing.Size(154, 52);
            this.lblCreditLimit.TabIndex = 9;
            this.lblCreditLimit.Text = "نام پارٹی";
            this.lblCreditLimit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblcontact
            // 
            this.lblcontact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblcontact.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcontact.Location = new System.Drawing.Point(394, 15);
            this.lblcontact.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblcontact.Name = "lblcontact";
            this.lblcontact.Size = new System.Drawing.Size(154, 52);
            this.lblcontact.TabIndex = 8;
            this.lblcontact.Text = "نام پارٹی";
            this.lblcontact.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1161, 71);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 39);
            this.label8.TabIndex = 7;
            this.label8.Text = "تفصیل";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(551, 15);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 39);
            this.label7.TabIndex = 6;
            this.label7.Text = "رابطہ نمبر";
            // 
            // lblRef
            // 
            this.lblRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRef.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRef.Location = new System.Drawing.Point(623, 6);
            this.lblRef.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRef.Name = "lblRef";
            this.lblRef.Size = new System.Drawing.Size(288, 52);
            this.lblRef.TabIndex = 5;
            this.lblRef.Text = "نام پارٹی";
            this.lblRef.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(935, 15);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 39);
            this.label5.TabIndex = 4;
            this.label5.Text = "معرفت";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(1013, 6);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(288, 52);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "نام پارٹی";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1307, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 39);
            this.label2.TabIndex = 1;
            this.label2.Text = "نام پارٹی";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1532, 128);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvLedger
            // 
            this.dgvLedger.AlternatingColors = true;
            this.dgvLedger.AutoEdit = true;
            this.dgvLedger.ColumnAutoResize = true;
            this.dgvLedger.DataSource = this.clsLedgerBindingSource;
            dgvLedger_DesignTimeLayout.LayoutString = resources.GetString("dgvLedger_DesignTimeLayout.LayoutString");
            this.dgvLedger.DesignTimeLayout = dgvLedger_DesignTimeLayout;
            this.dgvLedger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLedger.Font = new System.Drawing.Font("Calibri", 10F);
            this.dgvLedger.GroupByBoxVisible = false;
            this.dgvLedger.Location = new System.Drawing.Point(0, 129);
            this.dgvLedger.Margin = new System.Windows.Forms.Padding(2);
            this.dgvLedger.Name = "dgvLedger";
            this.dgvLedger.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvLedger.Size = new System.Drawing.Size(1532, 587);
            this.dgvLedger.TabIndex = 3;
            this.dgvLedger.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.dgvLedger.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.dgvLedger.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // clsLedgerBindingSource
            // 
            this.clsLedgerBindingSource.DataSource = typeof(MandiPOS.Reports.ReportClasses.clsLedger);
            // 
            // frmLedgerReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1532, 716);
            this.Controls.Add(this.dgvLedger);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmLedgerReport";
            this.Text = "Ledger";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLedger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsLedgerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource clsLedgerBindingSource;
        private Janus.Windows.GridEX.GridEX dgvLedger;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblCreditLimit;
        private System.Windows.Forms.Label lblcontact;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblRef;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCommission;
        private System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.Label lblDateRange2;
        private System.Windows.Forms.Label label6;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private Janus.Windows.EditControls.UIComboBox uiComboBox1;
    }
}