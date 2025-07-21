namespace MandiPOS.GUI
{
    partial class frmSubPartiesSale
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubPartiesSale));
            this.lblParty = new System.Windows.Forms.Label();
            this.lbld1 = new System.Windows.Forms.Label();
            this.lbld2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgv = new Janus.Windows.GridEX.GridEX();
            this.uiButton2 = new Janus.Windows.EditControls.UIButton();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.vwSubpartiesSaleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwSubpartiesSaleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblParty
            // 
            this.lblParty.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblParty.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblParty.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParty.ForeColor = System.Drawing.Color.White;
            this.lblParty.Location = new System.Drawing.Point(0, 0);
            this.lblParty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblParty.Name = "lblParty";
            this.lblParty.Size = new System.Drawing.Size(1021, 62);
            this.lblParty.TabIndex = 0;
            this.lblParty.Text = "Label01";
            this.lblParty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbld1
            // 
            this.lbld1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbld1.BackColor = System.Drawing.Color.DodgerBlue;
            this.lbld1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbld1.ForeColor = System.Drawing.Color.White;
            this.lbld1.Location = new System.Drawing.Point(872, 23);
            this.lbld1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbld1.Name = "lbld1";
            this.lbld1.Size = new System.Drawing.Size(133, 28);
            this.lbld1.TabIndex = 3;
            this.lbld1.Text = "03-Jun-2025";
            this.lbld1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbld2
            // 
            this.lbld2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbld2.BackColor = System.Drawing.Color.DodgerBlue;
            this.lbld2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbld2.ForeColor = System.Drawing.Color.White;
            this.lbld2.Location = new System.Drawing.Point(703, 23);
            this.lbld2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbld2.Name = "lbld2";
            this.lbld2.Size = new System.Drawing.Size(133, 28);
            this.lbld2.TabIndex = 4;
            this.lbld2.Text = "03-Jun-2025";
            this.lbld2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DodgerBlue;
            this.label4.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(844, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 51);
            this.label4.TabIndex = 5;
            this.label4.Text = "تا";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv
            // 
            this.dgv.ColumnAutoResize = true;
            this.dgv.DataSource = this.vwSubpartiesSaleBindingSource;
            dgv_DesignTimeLayout.LayoutString = resources.GetString("dgv_DesignTimeLayout.LayoutString");
            this.dgv.DesignTimeLayout = dgv_DesignTimeLayout;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.DynamicFiltering = true;
            this.dgv.FilterMode = Janus.Windows.GridEX.FilterMode.Manual;
            this.dgv.FilterRowFormatStyle.BackColor = System.Drawing.Color.PeachPuff;
            this.dgv.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 12F);
            this.dgv.GroupByBoxVisible = false;
            this.dgv.Location = new System.Drawing.Point(0, 62);
            this.dgv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv.Name = "dgv";
            this.dgv.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgv.Size = new System.Drawing.Size(1021, 444);
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
            this.uiButton2.Location = new System.Drawing.Point(157, 5);
            this.uiButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(141, 49);
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
            this.uiButton1.Location = new System.Drawing.Point(8, 5);
            this.uiButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(141, 49);
            this.uiButton1.TabIndex = 1;
            this.uiButton1.Text = " پرنٹ رپورٹ";
            this.uiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            // 
            // vwSubpartiesSaleBindingSource
            // 
            this.vwSubpartiesSaleBindingSource.DataSource = typeof(MandiPOS.CLasses.vw_SubpartiesSale);
            // 
            // frmSubPartiesSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 506);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbld2);
            this.Controls.Add(this.lbld1);
            this.Controls.Add(this.uiButton2);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.lblParty);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmSubPartiesSale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sub Parties Details";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwSubpartiesSaleBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblParty;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private Janus.Windows.EditControls.UIButton uiButton2;
        private System.Windows.Forms.Label lbld1;
        private System.Windows.Forms.Label lbld2;
        private System.Windows.Forms.Label label4;
        private Janus.Windows.GridEX.GridEX dgv;
        private System.Windows.Forms.BindingSource vwSubpartiesSaleBindingSource;
    }
}