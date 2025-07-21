namespace MandiPOS.GUI
{
    partial class frmMarkaDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMarkaDetails));
            this.label1 = new System.Windows.Forms.Label();
            this.d01 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.d02 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.بلپرنٹکریںToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.رپورٹپرنٹکریںToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.vwvendorSaleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vwvendorSaleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 0, 13, 0);
            this.label1.Size = new System.Drawing.Size(1067, 65);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // d01
            // 
            this.d01.CustomFormat = "dd-MMM-yyyy";
            this.d01.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            this.d01.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d01.Location = new System.Drawing.Point(481, 14);
            this.d01.Margin = new System.Windows.Forms.Padding(4);
            this.d01.Name = "d01";
            this.d01.Size = new System.Drawing.Size(185, 30);
            this.d01.TabIndex = 0;
            // 
            // d02
            // 
            this.d02.CustomFormat = "dd-MMM-yyyy";
            this.d02.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            this.d02.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d02.Location = new System.Drawing.Point(288, 14);
            this.d02.Margin = new System.Windows.Forms.Padding(4);
            this.d02.Name = "d02";
            this.d02.Size = new System.Drawing.Size(185, 30);
            this.d02.TabIndex = 1;
            // 
            // gridEX1
            // 
            this.gridEX1.ColumnAutoResize = true;
            this.gridEX1.DataSource = this.vwvendorSaleBindingSource;
            gridEX1_DesignTimeLayout.LayoutString = resources.GetString("gridEX1_DesignTimeLayout.LayoutString");
            this.gridEX1.DesignTimeLayout = gridEX1_DesignTimeLayout;
            this.gridEX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEX1.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 10F);
            this.gridEX1.GroupByBoxVisible = false;
            this.gridEX1.Location = new System.Drawing.Point(0, 65);
            this.gridEX1.Margin = new System.Windows.Forms.Padding(4);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridEX1.Size = new System.Drawing.Size(1067, 400);
            this.gridEX1.TabIndex = 3;
            this.gridEX1.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEX1.TotalRowFormatStyle.BackColor = System.Drawing.Color.LightYellow;
            this.gridEX1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.gridEX1.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.gridEX1_FormattingRow);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.بلپرنٹکریںToolStripMenuItem,
            this.toolStripMenuItem1,
            this.رپورٹپرنٹکریںToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(121, 86);
            // 
            // بلپرنٹکریںToolStripMenuItem
            // 
            this.بلپرنٹکریںToolStripMenuItem.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.بلپرنٹکریںToolStripMenuItem.Name = "بلپرنٹکریںToolStripMenuItem";
            this.بلپرنٹکریںToolStripMenuItem.Size = new System.Drawing.Size(120, 38);
            this.بلپرنٹکریںToolStripMenuItem.Text = "بل";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(117, 6);
            // 
            // رپورٹپرنٹکریںToolStripMenuItem
            // 
            this.رپورٹپرنٹکریںToolStripMenuItem.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.رپورٹپرنٹکریںToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.رپورٹپرنٹکریںToolStripMenuItem.Name = "رپورٹپرنٹکریںToolStripMenuItem";
            this.رپورٹپرنٹکریںToolStripMenuItem.Size = new System.Drawing.Size(120, 38);
            this.رپورٹپرنٹکریںToolStripMenuItem.Text = "رپورٹ";
            this.رپورٹپرنٹکریںToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.رپورٹپرنٹکریںToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(95, 7);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(71, 44);
            this.button2.TabIndex = 7;
            this.button2.Text = "رپورٹ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(16, 7);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 44);
            this.button1.TabIndex = 8;
            this.button1.Text = "بل";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 465);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 0, 27, 0);
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(1067, 46);
            this.label2.TabIndex = 9;
            this.label2.Text = "label2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.UseCompatibleTextRendering = true;
            // 
            // uiButton1
            // 
            this.uiButton1.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiButton1.Image = global::MandiPOS.Properties.Resources.refresh_149_16;
            this.uiButton1.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.AfterText;
            this.uiButton1.Location = new System.Drawing.Point(180, 7);
            this.uiButton1.Margin = new System.Windows.Forms.Padding(4);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(100, 44);
            this.uiButton1.TabIndex = 2;
            this.uiButton1.Text = "ریفریش";
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // vwvendorSaleBindingSource
            // 
            this.vwvendorSaleBindingSource.DataSource = typeof(MandiPOS.CLasses.vw_vendorSale);
            // 
            // frmMarkaDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 511);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.gridEX1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.d02);
            this.Controls.Add(this.d01);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMarkaDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Marka Details";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vwvendorSaleBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Janus.Windows.CalendarCombo.CalendarCombo d01;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private Janus.Windows.CalendarCombo.CalendarCombo d02;
        private Janus.Windows.GridEX.GridEX gridEX1;
        private System.Windows.Forms.BindingSource vwvendorSaleBindingSource;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem بلپرنٹکریںToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem رپورٹپرنٹکریںToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
    }
}