namespace MandiPOS
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.applicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartOfAccountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterAccountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailAccountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.defaultAccountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeWallpaperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.securityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCheckForUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelUpdate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBarDownload = new System.Windows.Forms.ToolStripProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnbackup = new System.Windows.Forms.Button();
            this.bnRecovery = new System.Windows.Forms.Button();
            this.btnCustomerBill = new System.Windows.Forms.Button();
            this.btnBeejak = new System.Windows.Forms.Button();
            this.btnLedger = new System.Windows.Forms.Button();
            this.btnRokar = new System.Windows.Forms.Button();
            this.btnKhasra = new System.Windows.Forms.Button();
            this.btnJV = new System.Windows.Forms.Button();
            this.btnSale = new System.Windows.Forms.Button();
            this.btnBeejBardana = new System.Windows.Forms.Button();
            this.btnJamaVoucher = new System.Windows.Forms.Button();
            this.btnBanamVoucher = new System.Windows.Forms.Button();
            this.btnParty = new System.Windows.Forms.Button();
            this.btnCity = new System.Windows.Forms.Button();
            this.btnItem = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblFiscalYear = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rePostSalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationToolStripMenuItem,
            this.chartOfAccountsToolStripMenuItem,
            this.utilitiesToolStripMenuItem,
            this.securityToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1307, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // applicationToolStripMenuItem
            // 
            this.applicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.applicationToolStripMenuItem.Name = "applicationToolStripMenuItem";
            this.applicationToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.applicationToolStripMenuItem.Text = "Application";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // chartOfAccountsToolStripMenuItem
            // 
            this.chartOfAccountsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterAccountsToolStripMenuItem,
            this.detailAccountsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.defaultAccountsToolStripMenuItem});
            this.chartOfAccountsToolStripMenuItem.Name = "chartOfAccountsToolStripMenuItem";
            this.chartOfAccountsToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.chartOfAccountsToolStripMenuItem.Text = "Chart of Accounts";
            // 
            // masterAccountsToolStripMenuItem
            // 
            this.masterAccountsToolStripMenuItem.Name = "masterAccountsToolStripMenuItem";
            this.masterAccountsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.masterAccountsToolStripMenuItem.Text = "Master Accounts";
            this.masterAccountsToolStripMenuItem.Click += new System.EventHandler(this.masterAccountsToolStripMenuItem_Click);
            // 
            // detailAccountsToolStripMenuItem
            // 
            this.detailAccountsToolStripMenuItem.Name = "detailAccountsToolStripMenuItem";
            this.detailAccountsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.detailAccountsToolStripMenuItem.Text = "Detail Accounts";
            this.detailAccountsToolStripMenuItem.Click += new System.EventHandler(this.detailAccountsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(162, 6);
            // 
            // defaultAccountsToolStripMenuItem
            // 
            this.defaultAccountsToolStripMenuItem.Name = "defaultAccountsToolStripMenuItem";
            this.defaultAccountsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.defaultAccountsToolStripMenuItem.Text = "Default Accounts";
            this.defaultAccountsToolStripMenuItem.Click += new System.EventHandler(this.defaultAccountsToolStripMenuItem_Click);
            // 
            // utilitiesToolStripMenuItem
            // 
            this.utilitiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupToolStripMenuItem,
            this.changeWallpaperToolStripMenuItem});
            this.utilitiesToolStripMenuItem.Name = "utilitiesToolStripMenuItem";
            this.utilitiesToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.utilitiesToolStripMenuItem.Text = "Utilities";
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.backupToolStripMenuItem.Text = "Backup";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // changeWallpaperToolStripMenuItem
            // 
            this.changeWallpaperToolStripMenuItem.Name = "changeWallpaperToolStripMenuItem";
            this.changeWallpaperToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.changeWallpaperToolStripMenuItem.Text = "Change Wallpaper";
            this.changeWallpaperToolStripMenuItem.Visible = false;
            this.changeWallpaperToolStripMenuItem.Click += new System.EventHandler(this.changeWallpaperToolStripMenuItem_Click);
            // 
            // securityToolStripMenuItem
            // 
            this.securityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersToolStripMenuItem});
            this.securityToolStripMenuItem.Name = "securityToolStripMenuItem";
            this.securityToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.securityToolStripMenuItem.Text = "Security";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCheckForUpdate,
            this.rePostSalesToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // mnuCheckForUpdate
            // 
            this.mnuCheckForUpdate.Name = "mnuCheckForUpdate";
            this.mnuCheckForUpdate.Size = new System.Drawing.Size(180, 22);
            this.mnuCheckForUpdate.Text = "Check For Update";
            this.mnuCheckForUpdate.Click += new System.EventHandler(this.CheckForUpdate);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelUpdate,
            this.toolStripProgressBarDownload});
            this.statusStrip1.Location = new System.Drawing.Point(0, 657);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1307, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelUpdate
            // 
            this.toolStripStatusLabelUpdate.IsLink = true;
            this.toolStripStatusLabelUpdate.Name = "toolStripStatusLabelUpdate";
            this.toolStripStatusLabelUpdate.Size = new System.Drawing.Size(102, 19);
            this.toolStripStatusLabelUpdate.Text = "Download Update";
            this.toolStripStatusLabelUpdate.Visible = false;
            this.toolStripStatusLabelUpdate.Click += new System.EventHandler(this.DownlaodUpdates);
            // 
            // toolStripProgressBarDownload
            // 
            this.toolStripProgressBarDownload.Name = "toolStripProgressBarDownload";
            this.toolStripProgressBarDownload.Size = new System.Drawing.Size(100, 18);
            this.toolStripProgressBarDownload.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnbackup);
            this.panel1.Controls.Add(this.bnRecovery);
            this.panel1.Controls.Add(this.btnCustomerBill);
            this.panel1.Controls.Add(this.btnBeejak);
            this.panel1.Controls.Add(this.btnLedger);
            this.panel1.Controls.Add(this.btnRokar);
            this.panel1.Controls.Add(this.btnKhasra);
            this.panel1.Controls.Add(this.btnJV);
            this.panel1.Controls.Add(this.btnSale);
            this.panel1.Controls.Add(this.btnBeejBardana);
            this.panel1.Controls.Add(this.btnJamaVoucher);
            this.panel1.Controls.Add(this.btnBanamVoucher);
            this.panel1.Controls.Add(this.btnParty);
            this.panel1.Controls.Add(this.btnCity);
            this.panel1.Controls.Add(this.btnItem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(831, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(476, 570);
            this.panel1.TabIndex = 4;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.PaleGreen;
            this.btnExit.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::MandiPOS.Properties.Resources.power_on;
            this.btnExit.Location = new System.Drawing.Point(50, 428);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(132, 70);
            this.btnExit.TabIndex = 18;
            this.btnExit.Text = "اخراج";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.button9_Click);
            // 
            // btnbackup
            // 
            this.btnbackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnbackup.BackColor = System.Drawing.Color.PaleGreen;
            this.btnbackup.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbackup.Image = global::MandiPOS.Properties.Resources.backup;
            this.btnbackup.Location = new System.Drawing.Point(326, 428);
            this.btnbackup.Name = "btnbackup";
            this.btnbackup.Size = new System.Drawing.Size(132, 70);
            this.btnbackup.TabIndex = 17;
            this.btnbackup.Text = "بیک اپ";
            this.btnbackup.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnbackup.UseVisualStyleBackColor = false;
            this.btnbackup.Click += new System.EventHandler(this.button10_Click);
            // 
            // bnRecovery
            // 
            this.bnRecovery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnRecovery.BackColor = System.Drawing.Color.PaleGreen;
            this.bnRecovery.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnRecovery.Image = ((System.Drawing.Image)(resources.GetObject("bnRecovery.Image")));
            this.bnRecovery.Location = new System.Drawing.Point(50, 352);
            this.bnRecovery.Name = "bnRecovery";
            this.bnRecovery.Size = new System.Drawing.Size(132, 70);
            this.bnRecovery.TabIndex = 16;
            this.bnRecovery.Text = "ریکوری";
            this.bnRecovery.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.bnRecovery.UseVisualStyleBackColor = false;
            this.bnRecovery.Click += new System.EventHandler(this.button11_Click);
            // 
            // btnCustomerBill
            // 
            this.btnCustomerBill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCustomerBill.BackColor = System.Drawing.Color.PaleGreen;
            this.btnCustomerBill.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomerBill.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomerBill.Image")));
            this.btnCustomerBill.Location = new System.Drawing.Point(188, 352);
            this.btnCustomerBill.Name = "btnCustomerBill";
            this.btnCustomerBill.Size = new System.Drawing.Size(132, 70);
            this.btnCustomerBill.TabIndex = 15;
            this.btnCustomerBill.Text = "گاہک بل";
            this.btnCustomerBill.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCustomerBill.UseVisualStyleBackColor = false;
            this.btnCustomerBill.Click += new System.EventHandler(this.button12_Click);
            // 
            // btnBeejak
            // 
            this.btnBeejak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBeejak.BackColor = System.Drawing.Color.PaleGreen;
            this.btnBeejak.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBeejak.Image = ((System.Drawing.Image)(resources.GetObject("btnBeejak.Image")));
            this.btnBeejak.Location = new System.Drawing.Point(326, 352);
            this.btnBeejak.Name = "btnBeejak";
            this.btnBeejak.Size = new System.Drawing.Size(132, 70);
            this.btnBeejak.TabIndex = 14;
            this.btnBeejak.Text = "بیجک";
            this.btnBeejak.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBeejak.UseVisualStyleBackColor = false;
            this.btnBeejak.Click += new System.EventHandler(this.button13_Click);
            // 
            // btnLedger
            // 
            this.btnLedger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLedger.BackColor = System.Drawing.Color.PaleGreen;
            this.btnLedger.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLedger.Image = ((System.Drawing.Image)(resources.GetObject("btnLedger.Image")));
            this.btnLedger.Location = new System.Drawing.Point(326, 276);
            this.btnLedger.Name = "btnLedger";
            this.btnLedger.Size = new System.Drawing.Size(132, 70);
            this.btnLedger.TabIndex = 13;
            this.btnLedger.Text = "لین دین کھاتہ";
            this.btnLedger.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnLedger.UseVisualStyleBackColor = false;
            this.btnLedger.Click += new System.EventHandler(this.button14_Click);
            // 
            // btnRokar
            // 
            this.btnRokar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRokar.BackColor = System.Drawing.Color.PaleGreen;
            this.btnRokar.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRokar.Image = ((System.Drawing.Image)(resources.GetObject("btnRokar.Image")));
            this.btnRokar.Location = new System.Drawing.Point(188, 276);
            this.btnRokar.Name = "btnRokar";
            this.btnRokar.Size = new System.Drawing.Size(132, 70);
            this.btnRokar.TabIndex = 12;
            this.btnRokar.Text = "کیش روکڑ";
            this.btnRokar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnRokar.UseVisualStyleBackColor = false;
            this.btnRokar.Click += new System.EventHandler(this.button15_Click);
            // 
            // btnKhasra
            // 
            this.btnKhasra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKhasra.BackColor = System.Drawing.Color.PaleGreen;
            this.btnKhasra.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhasra.Image = ((System.Drawing.Image)(resources.GetObject("btnKhasra.Image")));
            this.btnKhasra.Location = new System.Drawing.Point(50, 276);
            this.btnKhasra.Name = "btnKhasra";
            this.btnKhasra.Size = new System.Drawing.Size(132, 70);
            this.btnKhasra.TabIndex = 11;
            this.btnKhasra.Text = "خسرہ";
            this.btnKhasra.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnKhasra.UseVisualStyleBackColor = false;
            this.btnKhasra.Click += new System.EventHandler(this.button16_Click);
            // 
            // btnJV
            // 
            this.btnJV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJV.BackColor = System.Drawing.Color.PaleGreen;
            this.btnJV.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJV.Image = global::MandiPOS.Properties.Resources.voucher;
            this.btnJV.Location = new System.Drawing.Point(46, 172);
            this.btnJV.Name = "btnJV";
            this.btnJV.Size = new System.Drawing.Size(132, 70);
            this.btnJV.TabIndex = 10;
            this.btnJV.Text = "جنرل ووچر";
            this.btnJV.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnJV.UseVisualStyleBackColor = false;
            this.btnJV.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnSale
            // 
            this.btnSale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSale.BackColor = System.Drawing.Color.PaleGreen;
            this.btnSale.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSale.Image = global::MandiPOS.Properties.Resources.purchase;
            this.btnSale.Location = new System.Drawing.Point(326, 172);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(132, 70);
            this.btnSale.TabIndex = 9;
            this.btnSale.Text = "مال فروخت";
            this.btnSale.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSale.UseVisualStyleBackColor = false;
            this.btnSale.Click += new System.EventHandler(this.button8_Click);
            // 
            // btnBeejBardana
            // 
            this.btnBeejBardana.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBeejBardana.BackColor = System.Drawing.Color.PaleGreen;
            this.btnBeejBardana.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBeejBardana.Image = global::MandiPOS.Properties.Resources.voucher;
            this.btnBeejBardana.Location = new System.Drawing.Point(46, 96);
            this.btnBeejBardana.Name = "btnBeejBardana";
            this.btnBeejBardana.Size = new System.Drawing.Size(132, 70);
            this.btnBeejBardana.TabIndex = 8;
            this.btnBeejBardana.Text = "بیج باردانہ ووچر";
            this.btnBeejBardana.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBeejBardana.UseVisualStyleBackColor = false;
            this.btnBeejBardana.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnJamaVoucher
            // 
            this.btnJamaVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJamaVoucher.BackColor = System.Drawing.Color.PaleGreen;
            this.btnJamaVoucher.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJamaVoucher.Image = global::MandiPOS.Properties.Resources.voucher;
            this.btnJamaVoucher.Location = new System.Drawing.Point(188, 96);
            this.btnJamaVoucher.Name = "btnJamaVoucher";
            this.btnJamaVoucher.Size = new System.Drawing.Size(132, 70);
            this.btnJamaVoucher.TabIndex = 7;
            this.btnJamaVoucher.Text = "جمع ووچر";
            this.btnJamaVoucher.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnJamaVoucher.UseVisualStyleBackColor = false;
            this.btnJamaVoucher.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnBanamVoucher
            // 
            this.btnBanamVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBanamVoucher.BackColor = System.Drawing.Color.PaleGreen;
            this.btnBanamVoucher.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBanamVoucher.Image = global::MandiPOS.Properties.Resources.voucher;
            this.btnBanamVoucher.Location = new System.Drawing.Point(326, 96);
            this.btnBanamVoucher.Name = "btnBanamVoucher";
            this.btnBanamVoucher.Size = new System.Drawing.Size(132, 70);
            this.btnBanamVoucher.TabIndex = 6;
            this.btnBanamVoucher.Text = "بنام ووچر";
            this.btnBanamVoucher.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBanamVoucher.UseVisualStyleBackColor = false;
            this.btnBanamVoucher.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnParty
            // 
            this.btnParty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParty.BackColor = System.Drawing.Color.PaleGreen;
            this.btnParty.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParty.Image = global::MandiPOS.Properties.Resources.Persons;
            this.btnParty.Location = new System.Drawing.Point(322, 20);
            this.btnParty.Name = "btnParty";
            this.btnParty.Size = new System.Drawing.Size(132, 70);
            this.btnParty.TabIndex = 5;
            this.btnParty.Text = "کھاتہ اندراج";
            this.btnParty.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnParty.UseVisualStyleBackColor = false;
            this.btnParty.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnCity
            // 
            this.btnCity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCity.BackColor = System.Drawing.Color.PaleGreen;
            this.btnCity.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCity.Image = global::MandiPOS.Properties.Resources.location;
            this.btnCity.Location = new System.Drawing.Point(184, 20);
            this.btnCity.Name = "btnCity";
            this.btnCity.Size = new System.Drawing.Size(132, 70);
            this.btnCity.TabIndex = 4;
            this.btnCity.Text = "شہر اندراج";
            this.btnCity.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCity.UseVisualStyleBackColor = false;
            this.btnCity.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnItem
            // 
            this.btnItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnItem.BackColor = System.Drawing.Color.PaleGreen;
            this.btnItem.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItem.Image = global::MandiPOS.Properties.Resources.Items;
            this.btnItem.Location = new System.Drawing.Point(46, 20);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new System.Drawing.Size(132, 70);
            this.btnItem.TabIndex = 3;
            this.btnItem.Text = "اشیاء اندراج";
            this.btnItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnItem.UseVisualStyleBackColor = false;
            this.btnItem.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::MandiPOS.Properties.Resources.BIsmillah;
            this.pictureBox1.Location = new System.Drawing.Point(60, 88);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(537, 143);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // lblFiscalYear
            // 
            this.lblFiscalYear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFiscalYear.BackColor = System.Drawing.Color.AliceBlue;
            this.lblFiscalYear.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiscalYear.Location = new System.Drawing.Point(60, 235);
            this.lblFiscalYear.Name = "lblFiscalYear";
            this.lblFiscalYear.Size = new System.Drawing.Size(537, 84);
            this.lblFiscalYear.TabIndex = 6;
            this.lblFiscalYear.Text = "مالی سال";
            this.lblFiscalYear.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTime
            // 
            this.lblTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTime.BackColor = System.Drawing.Color.Black;
            this.lblTime.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.Lime;
            this.lblTime.Location = new System.Drawing.Point(53, 335);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(543, 60);
            this.lblTime.TabIndex = 7;
            this.lblTime.Text = "Time";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTime.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1307, 63);
            this.panel2.TabIndex = 8;
            // 
            // rePostSalesToolStripMenuItem
            // 
            this.rePostSalesToolStripMenuItem.Name = "rePostSalesToolStripMenuItem";
            this.rePostSalesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rePostSalesToolStripMenuItem.Text = "Re-Post Sales";
            this.rePostSalesToolStripMenuItem.Click += new System.EventHandler(this.rePostSalesToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackgroundImage = global::MandiPOS.Properties.Resources.bg1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1307, 679);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblFiscalYear);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1024, 718);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem applicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem chartOfAccountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masterAccountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailAccountsToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnItem;
        private System.Windows.Forms.Button btnCity;
        private System.Windows.Forms.Button btnParty;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnbackup;
        private System.Windows.Forms.Button bnRecovery;
        private System.Windows.Forms.Button btnCustomerBill;
        private System.Windows.Forms.Button btnBeejak;
        private System.Windows.Forms.Button btnLedger;
        private System.Windows.Forms.Button btnRokar;
        private System.Windows.Forms.Button btnKhasra;
        private System.Windows.Forms.Button btnJV;
        private System.Windows.Forms.Button btnSale;
        private System.Windows.Forms.Button btnBeejBardana;
        private System.Windows.Forms.Button btnJamaVoucher;
        private System.Windows.Forms.Button btnBanamVoucher;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblFiscalYear;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem defaultAccountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem changeWallpaperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem securityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUpdate;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBarDownload;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCheckForUpdate;
        private System.Windows.Forms.ToolStripMenuItem rePostSalesToolStripMenuItem;
    }
}