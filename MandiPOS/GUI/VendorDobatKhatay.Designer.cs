namespace MandiPOS.GUI
{
    partial class VendorDobatKhatay
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
            Janus.Windows.GridEX.GridEXLayout dgvCustomerDobat_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout dgvCustomer_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VendorDobatKhatay));
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvCustomerDobat = new Janus.Windows.GridEX.GridEX();
            this.bsDobatCustomers = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvCustomer = new Janus.Windows.GridEX.GridEX();
            this.bsCustomers = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerDobat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDobatCustomers)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DodgerBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(958, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "بیوپاری ڈوبت کھاتے";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 57);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(958, 522);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvCustomerDobat);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(473, 516);
            this.panel1.TabIndex = 0;
            // 
            // dgvCustomerDobat
            // 
            this.dgvCustomerDobat.AllowColumnDrag = false;
            this.dgvCustomerDobat.AlternatingColors = true;
            this.dgvCustomerDobat.AutoEdit = true;
            this.dgvCustomerDobat.ColumnAutoResize = true;
            this.dgvCustomerDobat.DataSource = this.bsDobatCustomers;
            dgvCustomerDobat_DesignTimeLayout.LayoutString = resources.GetString("dgvCustomerDobat_DesignTimeLayout.LayoutString");
            this.dgvCustomerDobat.DesignTimeLayout = dgvCustomerDobat_DesignTimeLayout;
            this.dgvCustomerDobat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomerDobat.DynamicFiltering = true;
            this.dgvCustomerDobat.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.dgvCustomerDobat.GroupByBoxVisible = false;
            this.dgvCustomerDobat.Location = new System.Drawing.Point(0, 57);
            this.dgvCustomerDobat.Name = "dgvCustomerDobat";
            this.dgvCustomerDobat.OfficeColorScheme = Janus.Windows.GridEX.OfficeColorScheme.Blue;
            this.dgvCustomerDobat.RecordNavigator = true;
            this.dgvCustomerDobat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvCustomerDobat.Size = new System.Drawing.Size(473, 459);
            this.dgvCustomerDobat.TabIndex = 3;
            this.dgvCustomerDobat.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.dgvCustomerDobat.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.dgvCustomerDobat.UpdateMode = Janus.Windows.GridEX.UpdateMode.CellUpdate;
            this.dgvCustomerDobat.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // bsDobatCustomers
            // 
            this.bsDobatCustomers.DataSource = typeof(MandiPOS.CLasses.DetailAccountView);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DodgerBlue;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(473, 57);
            this.label3.TabIndex = 2;
            this.label3.Text = "ڈوبت کھاتے";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.UseCompatibleTextRendering = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvCustomer);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(482, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(473, 516);
            this.panel2.TabIndex = 1;
            // 
            // dgvCustomer
            // 
            this.dgvCustomer.AllowColumnDrag = false;
            this.dgvCustomer.AlternatingColors = true;
            this.dgvCustomer.AutoEdit = true;
            this.dgvCustomer.ColumnAutoResize = true;
            this.dgvCustomer.DataSource = this.bsCustomers;
            dgvCustomer_DesignTimeLayout.LayoutString = resources.GetString("dgvCustomer_DesignTimeLayout.LayoutString");
            this.dgvCustomer.DesignTimeLayout = dgvCustomer_DesignTimeLayout;
            this.dgvCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomer.DynamicFiltering = true;
            this.dgvCustomer.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.dgvCustomer.GroupByBoxVisible = false;
            this.dgvCustomer.Location = new System.Drawing.Point(0, 57);
            this.dgvCustomer.Name = "dgvCustomer";
            this.dgvCustomer.OfficeColorScheme = Janus.Windows.GridEX.OfficeColorScheme.Blue;
            this.dgvCustomer.RecordNavigator = true;
            this.dgvCustomer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvCustomer.Size = new System.Drawing.Size(473, 459);
            this.dgvCustomer.TabIndex = 2;
            this.dgvCustomer.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.dgvCustomer.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.dgvCustomer.UpdateMode = Janus.Windows.GridEX.UpdateMode.CellUpdate;
            this.dgvCustomer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // bsCustomers
            // 
            this.bsCustomers.DataSource = typeof(MandiPOS.CLasses.DetailAccountView);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DodgerBlue;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(473, 57);
            this.label2.TabIndex = 3;
            this.label2.Text = "بیوپاری کھاتے";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.UseCompatibleTextRendering = true;
            // 
            // VendorDobatKhatay
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(958, 579);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "VendorDobatKhatay";
            this.Text = "CustomerDobatKhatay";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerDobat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDobatCustomers)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCustomers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.GridEX.GridEX dgvCustomer;
        private System.Windows.Forms.BindingSource bsCustomers;
        private Janus.Windows.GridEX.GridEX dgvCustomerDobat;
        private System.Windows.Forms.BindingSource bsDobatCustomers;
    }
}