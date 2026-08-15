namespace MandiPOS.GUI
{
    partial class frmAgreementInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgreementInfo));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPartyID = new Janus.Windows.GridEX.EditControls.EditBox();
            this.visualStyleManager1 = new Janus.Windows.Common.VisualStyleManager(this.components);
            this.txtPartyName = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label4 = new System.Windows.Forms.Label();
            this.dtp2 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRemarks = new Janus.Windows.GridEX.EditControls.EditBox();
            this.cmbItems = new Janus.Windows.EditControls.UIComboBox();
            this.tblItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtArea = new Janus.Windows.GridEX.EditControls.EditBox();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.dgv = new Janus.Windows.GridEX.GridEX();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.uiButton2 = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.tblItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DodgerBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(529, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "معاہدہ بیوپاری";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(478, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "بیوپاری";
            // 
            // txtPartyID
            // 
            this.txtPartyID.Location = new System.Drawing.Point(372, 55);
            this.txtPartyID.Name = "txtPartyID";
            this.txtPartyID.OfficeColorScheme = Janus.Windows.GridEX.OfficeColorScheme.Blue;
            this.txtPartyID.ReadOnly = true;
            this.txtPartyID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPartyID.Size = new System.Drawing.Size(100, 35);
            this.txtPartyID.TabIndex = 2;
            this.txtPartyID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.txtPartyID.VisualStyleManager = this.visualStyleManager1;
            this.txtPartyID.TextChanged += new System.EventHandler(this.editBox1_TextChanged);
            // 
            // visualStyleManager1
            // 
            janusColorScheme1.HighlightTextColor = System.Drawing.SystemColors.HighlightText;
            janusColorScheme1.Name = "Scheme0";
            janusColorScheme1.OfficeColorScheme = Janus.Windows.Common.OfficeColorScheme.Blue;
            janusColorScheme1.OfficeCustomColor = System.Drawing.Color.Empty;
            janusColorScheme1.VisualStyle = Janus.Windows.Common.VisualStyle.Office2010;
            this.visualStyleManager1.ColorSchemes.Add(janusColorScheme1);
            this.visualStyleManager1.DefaultColorScheme = "Scheme0";
            // 
            // txtPartyName
            // 
            this.txtPartyName.Location = new System.Drawing.Point(12, 55);
            this.txtPartyName.Name = "txtPartyName";
            this.txtPartyName.OfficeColorScheme = Janus.Windows.GridEX.OfficeColorScheme.Blue;
            this.txtPartyName.ReadOnly = true;
            this.txtPartyName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPartyName.Size = new System.Drawing.Size(354, 35);
            this.txtPartyName.TabIndex = 3;
            this.txtPartyName.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.txtPartyName.VisualStyleManager = this.visualStyleManager1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(479, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 27);
            this.label3.TabIndex = 4;
            this.label3.Text = "تاریخ اول";
            // 
            // dtp1
            // 
            this.dtp1.CustomFormat = "dd-MM-yyyy";
            this.dtp1.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtp1.DropDownCalendar.OfficeColorScheme = Janus.Windows.CalendarCombo.OfficeColorScheme.Blue;
            this.dtp1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.dtp1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp1.Location = new System.Drawing.Point(326, 98);
            this.dtp1.Name = "dtp1";
            this.dtp1.OfficeColorScheme = Janus.Windows.CalendarCombo.OfficeColorScheme.Blue;
            this.dtp1.Size = new System.Drawing.Size(147, 27);
            this.dtp1.TabIndex = 5;
            this.dtp1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.dtp1.VisualStyleManager = this.visualStyleManager1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(257, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 27);
            this.label4.TabIndex = 6;
            this.label4.Text = "تاریخ دوم";
            // 
            // dtp2
            // 
            this.dtp2.CustomFormat = "dd-MM-yyyy";
            this.dtp2.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtp2.DropDownCalendar.OfficeColorScheme = Janus.Windows.CalendarCombo.OfficeColorScheme.Blue;
            this.dtp2.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.dtp2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp2.IsNullDate = true;
            this.dtp2.Location = new System.Drawing.Point(104, 100);
            this.dtp2.Name = "dtp2";
            this.dtp2.Nullable = true;
            this.dtp2.NullButtonText = "Clear";
            this.dtp2.OfficeColorScheme = Janus.Windows.CalendarCombo.OfficeColorScheme.Blue;
            this.dtp2.ShowNullButton = true;
            this.dtp2.Size = new System.Drawing.Size(147, 27);
            this.dtp2.TabIndex = 7;
            this.dtp2.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.dtp2.VisualStyleManager = this.visualStyleManager1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(479, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 27);
            this.label5.TabIndex = 8;
            this.label5.Text = "تفصیلات";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(12, 131);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.OfficeColorScheme = Janus.Windows.GridEX.OfficeColorScheme.Blue;
            this.txtRemarks.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRemarks.Size = new System.Drawing.Size(461, 117);
            this.txtRemarks.TabIndex = 9;
            this.txtRemarks.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.txtRemarks.VisualStyleManager = this.visualStyleManager1;
            // 
            // cmbItems
            // 
            this.cmbItems.DataSource = this.tblItemsBindingSource;
            this.cmbItems.DisplayMember = "ItemTitle";
            this.cmbItems.Location = new System.Drawing.Point(291, 254);
            this.cmbItems.Name = "cmbItems";
            this.cmbItems.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Blue;
            this.cmbItems.Size = new System.Drawing.Size(182, 35);
            this.cmbItems.TabIndex = 10;
            this.cmbItems.ValueMember = "ID";
            this.cmbItems.VisualStyleManager = this.visualStyleManager1;
            // 
            // tblItemsBindingSource
            // 
            this.tblItemsBindingSource.DataSource = typeof(MandiPOS.CLasses.tblItems);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(479, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 27);
            this.label6.TabIndex = 11;
            this.label6.Text = "اشیاء";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(257, 262);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 27);
            this.label7.TabIndex = 12;
            this.label7.Text = "رقبہ";
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(66, 254);
            this.txtArea.Name = "txtArea";
            this.txtArea.OfficeColorScheme = Janus.Windows.GridEX.OfficeColorScheme.Blue;
            this.txtArea.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtArea.Size = new System.Drawing.Size(185, 35);
            this.txtArea.TabIndex = 13;
            this.txtArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.txtArea.VisualStyleManager = this.visualStyleManager1;
            // 
            // uiButton1
            // 
            this.uiButton1.Image = global::MandiPOS.Properties.Resources.Plus_36851;
            this.uiButton1.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Center;
            this.uiButton1.ImageSize = new System.Drawing.Size(24, 24);
            this.uiButton1.Location = new System.Drawing.Point(12, 254);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Blue;
            this.uiButton1.Size = new System.Drawing.Size(48, 35);
            this.uiButton1.TabIndex = 14;
            this.uiButton1.VisualStyleManager = this.visualStyleManager1;
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // dgv
            // 
            this.dgv.AllowColumnDrag = false;
            this.dgv.AlternatingColors = true;
            this.dgv.AutoEdit = true;
            this.dgv.ColumnAutoResize = true;
            this.dgv.DataSource = this.bs;
            dgv_DesignTimeLayout.LayoutString = resources.GetString("dgv_DesignTimeLayout.LayoutString");
            this.dgv.DesignTimeLayout = dgv_DesignTimeLayout;
            this.dgv.DynamicFiltering = true;
            this.dgv.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.dgv.GroupByBoxVisible = false;
            this.dgv.Location = new System.Drawing.Point(12, 295);
            this.dgv.Name = "dgv";
            this.dgv.OfficeColorScheme = Janus.Windows.GridEX.OfficeColorScheme.Blue;
            this.dgv.RecordNavigator = true;
            this.dgv.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgv.Size = new System.Drawing.Size(505, 226);
            this.dgv.TabIndex = 15;
            this.dgv.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.dgv.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.dgv.UpdateMode = Janus.Windows.GridEX.UpdateMode.CellUpdate;
            this.dgv.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.dgv.VisualStyleManager = this.visualStyleManager1;
            // 
            // bs
            // 
            this.bs.DataSource = typeof(MandiPOS.CLasses.tblAgreementDetails);
            // 
            // uiButton2
            // 
            this.uiButton2.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Center;
            this.uiButton2.ImageSize = new System.Drawing.Size(24, 24);
            this.uiButton2.Location = new System.Drawing.Point(12, 527);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Blue;
            this.uiButton2.Size = new System.Drawing.Size(141, 35);
            this.uiButton2.TabIndex = 16;
            this.uiButton2.Text = "محفوظ کریں";
            this.uiButton2.VisualStyleManager = this.visualStyleManager1;
            this.uiButton2.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // frmAgreementInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(529, 571);
            this.Controls.Add(this.uiButton2);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.txtArea);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbItems);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtp2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtp1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPartyName);
            this.Controls.Add(this.txtPartyID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAgreementInfo";
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.tblItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.GridEX.EditControls.EditBox txtPartyID;
        private Janus.Windows.GridEX.EditControls.EditBox txtPartyName;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.CalendarCombo.CalendarCombo dtp1;
        private System.Windows.Forms.Label label4;
        private Janus.Windows.CalendarCombo.CalendarCombo dtp2;
        private System.Windows.Forms.Label label5;
        private Janus.Windows.GridEX.EditControls.EditBox txtRemarks;
        private Janus.Windows.Common.VisualStyleManager visualStyleManager1;
        private Janus.Windows.EditControls.UIComboBox cmbItems;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Janus.Windows.GridEX.EditControls.EditBox txtArea;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private Janus.Windows.GridEX.GridEX dgv;
        private System.Windows.Forms.BindingSource tblItemsBindingSource;
        private System.Windows.Forms.BindingSource bs;
        private Janus.Windows.EditControls.UIButton uiButton2;
    }
}