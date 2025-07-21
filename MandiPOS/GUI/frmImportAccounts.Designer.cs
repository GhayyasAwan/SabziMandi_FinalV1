namespace MandiPOS.GUI
{
    partial class frmImportAccounts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportAccounts));
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            this.excelFormatBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiButton2 = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.excelFormatBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // uiButton1
            // 
            this.uiButton1.Location = new System.Drawing.Point(13, 13);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(131, 44);
            this.uiButton1.TabIndex = 0;
            this.uiButton1.Text = "Selct File";
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // gridEX1
            // 
            this.gridEX1.DataSource = this.excelFormatBindingSource;
            gridEX1_DesignTimeLayout.LayoutString = resources.GetString("gridEX1_DesignTimeLayout.LayoutString");
            this.gridEX1.DesignTimeLayout = gridEX1_DesignTimeLayout;
            this.gridEX1.GroupByBoxVisible = false;
            this.gridEX1.Location = new System.Drawing.Point(13, 64);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.Size = new System.Drawing.Size(792, 598);
            this.gridEX1.TabIndex = 1;
            // 
            // excelFormatBindingSource
            // 
            this.excelFormatBindingSource.DataSource = typeof(MandiPOS.CLasses.ExcelFormat);
            // 
            // uiButton2
            // 
            this.uiButton2.Location = new System.Drawing.Point(150, 14);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(131, 44);
            this.uiButton2.TabIndex = 2;
            this.uiButton2.Text = "Import";
            this.uiButton2.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // frmImportAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 674);
            this.Controls.Add(this.uiButton2);
            this.Controls.Add(this.gridEX1);
            this.Controls.Add(this.uiButton1);
            this.Name = "frmImportAccounts";
            this.Text = "frmImportAccounts";
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.excelFormatBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.EditControls.UIButton uiButton1;
        private Janus.Windows.GridEX.GridEX gridEX1;
        private System.Windows.Forms.BindingSource excelFormatBindingSource;
        private Janus.Windows.EditControls.UIButton uiButton2;
    }
}