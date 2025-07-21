namespace MandiPOS.GUI
{
    partial class frmMasterAccounts
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtTitle = new DevExpress.XtraEditors.TextEdit();
            this.cmbType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.masterAccountsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccountTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccountType = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterAccountsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(552, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 32);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "عنوان کھاتہ";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(114, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(39, 32);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "قسم کھاتہ";
            // 
            // txtTitle
            // 
            this.txtTitle.EnterMoveNextControl = true;
            this.txtTitle.Location = new System.Drawing.Point(161, 50);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Properties.Appearance.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Properties.Appearance.Options.UseFont = true;
            this.txtTitle.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Gold;
            this.txtTitle.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTitle.Size = new System.Drawing.Size(445, 38);
            this.txtTitle.TabIndex = 1;
            // 
            // cmbType
            // 
            this.cmbType.Location = new System.Drawing.Point(12, 56);
            this.cmbType.Name = "cmbType";
            this.cmbType.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbType.Properties.Appearance.Options.UseFont = true;
            this.cmbType.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Gold;
            this.cmbType.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.cmbType.Properties.AppearanceItemHighlight.BackColor = System.Drawing.Color.LightGreen;
            this.cmbType.Properties.AppearanceItemHighlight.Options.UseBackColor = true;
            this.cmbType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbType.Properties.Items.AddRange(new object[] {
            "Assets",
            "Liability",
            "Expenses",
            "Capital",
            "Income"});
            this.cmbType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbType.Size = new System.Drawing.Size(143, 30);
            this.cmbType.TabIndex = 3;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.DataSource = this.masterAccountsBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 92);
            this.gridControl1.MainView = this.dgv;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl1.Size = new System.Drawing.Size(592, 483);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgv});
            // 
            // masterAccountsBindingSource
            // 
            this.masterAccountsBindingSource.DataSource = typeof(MandiPOS.CLasses.MasterAccounts);
            // 
            // dgv
            // 
            this.dgv.Appearance.FocusedCell.BackColor = System.Drawing.Color.LightGreen;
            this.dgv.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.dgv.Appearance.FocusedCell.Options.UseBackColor = true;
            this.dgv.Appearance.FocusedCell.Options.UseForeColor = true;
            this.dgv.Appearance.FocusedRow.BackColor = System.Drawing.Color.LightGreen;
            this.dgv.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dgv.Appearance.FocusedRow.Options.UseBackColor = true;
            this.dgv.Appearance.FocusedRow.Options.UseForeColor = true;
            this.dgv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.Appearance.HeaderPanel.Options.UseFont = true;
            this.dgv.Appearance.Row.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.Appearance.Row.Options.UseFont = true;
            this.dgv.Appearance.SelectedRow.BackColor = System.Drawing.Color.LightGreen;
            this.dgv.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.dgv.Appearance.SelectedRow.Options.UseBackColor = true;
            this.dgv.Appearance.SelectedRow.Options.UseForeColor = true;
            this.dgv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colAccountTitle,
            this.colAccountType});
            this.dgv.GridControl = this.gridControl1;
            this.dgv.Name = "dgv";
            this.dgv.OptionsView.ShowGroupPanel = false;
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colAccountTitle
            // 
            this.colAccountTitle.FieldName = "AccountTitle";
            this.colAccountTitle.Name = "colAccountTitle";
            this.colAccountTitle.OptionsColumn.AllowEdit = false;
            this.colAccountTitle.OptionsColumn.AllowMove = false;
            this.colAccountTitle.OptionsColumn.AllowShowHide = false;
            this.colAccountTitle.Visible = true;
            this.colAccountTitle.VisibleIndex = 0;
            this.colAccountTitle.Width = 455;
            // 
            // colAccountType
            // 
            this.colAccountType.FieldName = "AccountType";
            this.colAccountType.Name = "colAccountType";
            this.colAccountType.OptionsColumn.AllowEdit = false;
            this.colAccountType.OptionsColumn.AllowMove = false;
            this.colAccountType.OptionsColumn.AllowShowHide = false;
            this.colAccountType.OptionsColumn.FixedWidth = true;
            this.colAccountType.Visible = true;
            this.colAccountType.VisibleIndex = 1;
            this.colAccountType.Width = 150;
            // 
            // frmMasterAccounts
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(616, 587);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.labelControl1);
            this.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.ShowIcon = false;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMasterAccounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Master Accounts";
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterAccountsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtTitle;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cmbType;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView dgv;
        private System.Windows.Forms.BindingSource masterAccountsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colAccountTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colAccountType;
    }
}