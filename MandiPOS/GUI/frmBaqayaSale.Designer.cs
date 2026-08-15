namespace MandiPOS.GUI
{
    partial class frmBaqayaSale
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaqayaSale));
            this.lblParty = new System.Windows.Forms.Label();
            this.dgv = new Janus.Windows.GridEX.GridEX();
            this.uiButton2 = new Janus.Windows.EditControls.UIButton();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            this.SuspendLayout();
            // 
            // lblParty
            // 
            this.lblParty.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblParty.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblParty.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParty.ForeColor = System.Drawing.Color.White;
            this.lblParty.Location = new System.Drawing.Point(0, 0);
            this.lblParty.Name = "lblParty";
            this.lblParty.Size = new System.Drawing.Size(766, 50);
            this.lblParty.TabIndex = 0;
            this.lblParty.Text = "Label01";
            this.lblParty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv
            // 
            this.dgv.ColumnAutoResize = true;
            this.dgv.DataSource = this.bs;
            dgv_DesignTimeLayout.LayoutString = resources.GetString("dgv_DesignTimeLayout.LayoutString");
            this.dgv.DesignTimeLayout = dgv_DesignTimeLayout;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.DynamicFiltering = true;
            this.dgv.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.dgv.FilterRowFormatStyle.BackColor = System.Drawing.Color.PeachPuff;
            this.dgv.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.dgv.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 12F);
            this.dgv.GroupByBoxVisible = false;
            this.dgv.Location = new System.Drawing.Point(0, 50);
            this.dgv.Name = "dgv";
            this.dgv.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgv.Size = new System.Drawing.Size(766, 361);
            this.dgv.TabIndex = 6;
            this.dgv.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.dgv.TotalRowFormatStyle.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dgv.TotalRowFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.dgv.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.dgv.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.dgv_FormattingRow);
            // 
            // uiButton2
            // 
            this.uiButton2.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.Button;
            this.uiButton2.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiButton2.Image = global::MandiPOS.Properties.Resources.printernew;
            this.uiButton2.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.AfterText;
            this.uiButton2.ImageSize = new System.Drawing.Size(32, 32);
            this.uiButton2.Location = new System.Drawing.Point(118, 4);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(106, 40);
            this.uiButton2.TabIndex = 2;
            this.uiButton2.Text = "پرنٹ بل";
            this.uiButton2.Visible = false;
            this.uiButton2.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.uiButton2.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // uiButton1
            // 
            this.uiButton1.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.Button;
            this.uiButton1.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiButton1.Image = global::MandiPOS.Properties.Resources.printernew;
            this.uiButton1.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.AfterText;
            this.uiButton1.ImageSize = new System.Drawing.Size(32, 32);
            this.uiButton1.Location = new System.Drawing.Point(6, 4);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(106, 40);
            this.uiButton1.TabIndex = 1;
            this.uiButton1.Text = " پرنٹ رپورٹ";
            this.uiButton1.Visible = false;
            this.uiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // bs
            // 
            this.bs.DataSource = typeof(MandiPOS.CLasses.BaqayaReportModel);
            // 
            // frmBaqayaSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 411);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.uiButton2);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.lblParty);
            this.Name = "frmBaqayaSale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sub Parties Details";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblParty;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private Janus.Windows.EditControls.UIButton uiButton2;
        private Janus.Windows.GridEX.GridEX dgv;
        private System.Windows.Forms.BindingSource bs;
    }
}