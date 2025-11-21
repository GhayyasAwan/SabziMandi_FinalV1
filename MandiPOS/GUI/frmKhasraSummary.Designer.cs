namespace MandiPOS.GUI
{
    partial class frmKhasraSummary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhasraSummary));
            this.label1 = new System.Windows.Forms.Label();
            this.lbldate = new System.Windows.Forms.Label();
            this.dgv = new Janus.Windows.GridEX.GridEX();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.label2 = new System.Windows.Forms.Label();
            this._naqad = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this._udhar = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DodgerBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(821, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "خسرہ گاہک مختصر";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbldate
            // 
            this.lbldate.BackColor = System.Drawing.Color.Transparent;
            this.lbldate.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbldate.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldate.ForeColor = System.Drawing.Color.Maroon;
            this.lbldate.Location = new System.Drawing.Point(0, 50);
            this.lbldate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(821, 46);
            this.lbldate.TabIndex = 1;
            this.lbldate.Text = "خسرہ گاہک مختصر";
            this.lbldate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv
            // 
            this.dgv.AlternatingColors = true;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutomaticSort = false;
            this.dgv.ColumnAutoResize = true;
            this.dgv.DataSource = this.bs;
            dgv_DesignTimeLayout.LayoutString = resources.GetString("dgv_DesignTimeLayout.LayoutString");
            this.dgv.DesignTimeLayout = dgv_DesignTimeLayout;
            this.dgv.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 13.8F);
            this.dgv.GroupByBoxVisible = false;
            this.dgv.Location = new System.Drawing.Point(9, 98);
            this.dgv.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgv.Name = "dgv";
            this.dgv.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgv.RowHeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.dgv.Size = new System.Drawing.Size(806, 403);
            this.dgv.TabIndex = 2;
            this.dgv.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.dgv.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            // 
            // bs
            // 
            this.bs.DataSource = typeof(MandiPOS.CLasses.vw_KhasraSummary);
            // 
            // uiButton1
            // 
            this.uiButton1.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiButton1.Location = new System.Drawing.Point(9, 53);
            this.uiButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(109, 41);
            this.uiButton1.TabIndex = 3;
            this.uiButton1.Text = "بل پرنٹ کریں";
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(337, 513);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "نقد سیل";
            // 
            // _naqad
            // 
            this._naqad.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._naqad.HoverMode = Janus.Windows.GridEX.HoverMode.Highlight;
            this._naqad.Location = new System.Drawing.Point(209, 513);
            this._naqad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._naqad.Name = "_naqad";
            this._naqad.Size = new System.Drawing.Size(123, 30);
            this._naqad.TabIndex = 5;
            this._naqad.Text = "0";
            this._naqad.Value = 0;
            this._naqad.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32;
            this._naqad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            // 
            // _udhar
            // 
            this._udhar.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._udhar.HoverMode = Janus.Windows.GridEX.HoverMode.Highlight;
            this._udhar.Location = new System.Drawing.Point(11, 513);
            this._udhar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._udhar.Name = "_udhar";
            this._udhar.Size = new System.Drawing.Size(123, 30);
            this._udhar.TabIndex = 6;
            this._udhar.Text = "0";
            this._udhar.Value = 0;
            this._udhar.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32;
            this._udhar.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(139, 511);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 32);
            this.label3.TabIndex = 7;
            this.label3.Text = "ادھار سیل";
            // 
            // frmKhasraSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 561);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._udhar);
            this.Controls.Add(this._naqad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.lbldate);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmKhasraSummary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "خسرہ گاہک مختصر";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbldate;
        private Janus.Windows.GridEX.GridEX dgv;
        private System.Windows.Forms.BindingSource bs;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.GridEX.EditControls.NumericEditBox _naqad;
        private Janus.Windows.GridEX.EditControls.NumericEditBox _udhar;
        private System.Windows.Forms.Label label3;
    }
}