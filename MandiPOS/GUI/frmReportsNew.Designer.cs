namespace MandiPOS.GUI
{
    partial class frmReportsNew
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
            Janus.Windows.GridEX.GridEXLayout cmbCity_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportsNew));
            Janus.Windows.GridEX.GridEXLayout cmbGroups_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout dgvHelp_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.rb_Report21 = new System.Windows.Forms.RadioButton();
            this.rb_Report19 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.rbBqayaSale = new System.Windows.Forms.RadioButton();
            this.rb_Report20 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.rb_Report17 = new System.Windows.Forms.RadioButton();
            this.rb_Report18 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.rb_Report13 = new System.Windows.Forms.RadioButton();
            this.rb_Report07 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rb_Report11 = new System.Windows.Forms.RadioButton();
            this.rb_Report06 = new System.Windows.Forms.RadioButton();
            this.rb_Report08 = new System.Windows.Forms.RadioButton();
            this.rb_Report02 = new System.Windows.Forms.RadioButton();
            this.rb_Report03 = new System.Windows.Forms.RadioButton();
            this.rb_Report01 = new System.Windows.Forms.RadioButton();
            this.rb_Report14 = new System.Windows.Forms.RadioButton();
            this.rb_Report15 = new System.Windows.Forms.RadioButton();
            this.rb_Report09 = new System.Windows.Forms.RadioButton();
            this.rb_Report10 = new System.Windows.Forms.RadioButton();
            this.rb_Report16 = new System.Windows.Forms.RadioButton();
            this.rb_Report12 = new System.Windows.Forms.RadioButton();
            this.lblDtp = new System.Windows.Forms.Label();
            this.dtp = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.dtp2 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.lblDate2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbSummary = new Janus.Windows.EditControls.UICheckBox();
            this.cbInActive = new Janus.Windows.EditControls.UICheckBox();
            this.cbZero = new Janus.Windows.EditControls.UICheckBox();
            this.cmbSort = new Janus.Windows.EditControls.UIComboBox();
            this.lblSort = new System.Windows.Forms.Label();
            this.btnViewReport = new Janus.Windows.EditControls.UIButton();
            this.lblBill = new System.Windows.Forms.Label();
            this.txtBillNo = new Janus.Windows.GridEX.EditControls.EditBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.cmbCity = new Janus.Windows.GridEX.EditControls.CheckedComboBox();
            this.lblgroup = new System.Windows.Forms.Label();
            this.cmbGroups = new Janus.Windows.GridEX.EditControls.CheckedComboBox();
            this.dgvHelp = new Janus.Windows.GridEX.GridEX();
            this._pname = new Janus.Windows.GridEX.EditControls.EditBox();
            this.lblParty = new System.Windows.Forms.Label();
            this._pid = new Janus.Windows.GridEX.EditControls.EditBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.bsParties = new System.Windows.Forms.BindingSource(this.components);
            this.chartDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bsSubParties = new System.Windows.Forms.BindingSource(this.components);
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsParties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSubParties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlMain.Controls.Add(this.uiGroupBox1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMain.Location = new System.Drawing.Point(897, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlMain.Size = new System.Drawing.Size(732, 572);
            this.pnlMain.TabIndex = 0;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.AutoScroll = true;
            this.uiGroupBox1.BackColor = System.Drawing.Color.PeachPuff;
            this.uiGroupBox1.BorderColor = System.Drawing.Color.PeachPuff;
            this.uiGroupBox1.Controls.Add(this.rb_Report21);
            this.uiGroupBox1.Controls.Add(this.rb_Report19);
            this.uiGroupBox1.Controls.Add(this.radioButton3);
            this.uiGroupBox1.Controls.Add(this.rbBqayaSale);
            this.uiGroupBox1.Controls.Add(this.rb_Report20);
            this.uiGroupBox1.Controls.Add(this.label3);
            this.uiGroupBox1.Controls.Add(this.rb_Report17);
            this.uiGroupBox1.Controls.Add(this.rb_Report18);
            this.uiGroupBox1.Controls.Add(this.label2);
            this.uiGroupBox1.Controls.Add(this.rb_Report13);
            this.uiGroupBox1.Controls.Add(this.rb_Report07);
            this.uiGroupBox1.Controls.Add(this.label1);
            this.uiGroupBox1.Controls.Add(this.rb_Report11);
            this.uiGroupBox1.Controls.Add(this.rb_Report06);
            this.uiGroupBox1.Controls.Add(this.rb_Report08);
            this.uiGroupBox1.Controls.Add(this.rb_Report02);
            this.uiGroupBox1.Controls.Add(this.rb_Report03);
            this.uiGroupBox1.Controls.Add(this.rb_Report01);
            this.uiGroupBox1.Controls.Add(this.rb_Report14);
            this.uiGroupBox1.Controls.Add(this.rb_Report15);
            this.uiGroupBox1.Controls.Add(this.rb_Report09);
            this.uiGroupBox1.Controls.Add(this.rb_Report10);
            this.uiGroupBox1.Controls.Add(this.rb_Report16);
            this.uiGroupBox1.Controls.Add(this.rb_Report12);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(732, 572);
            this.uiGroupBox1.TabIndex = 0;
            this.uiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003;
            // 
            // rb_Report21
            // 
            this.rb_Report21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_Report21.AutoSize = true;
            this.rb_Report21.BackColor = System.Drawing.Color.Transparent;
            this.rb_Report21.Enabled = false;
            this.rb_Report21.FlatAppearance.BorderSize = 0;
            this.rb_Report21.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rb_Report21.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rb_Report21.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Report21.Location = new System.Drawing.Point(25, 89);
            this.rb_Report21.Margin = new System.Windows.Forms.Padding(2);
            this.rb_Report21.Name = "rb_Report21";
            this.rb_Report21.Size = new System.Drawing.Size(138, 46);
            this.rb_Report21.TabIndex = 23;
            this.rb_Report21.Text = "معرفت رپورٹ";
            this.rb_Report21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb_Report21.UseCompatibleTextRendering = true;
            this.rb_Report21.UseVisualStyleBackColor = true;
            this.rb_Report21.CheckedChanged += new System.EventHandler(this.SetReport);
            // 
            // rb_Report19
            // 
            this.rb_Report19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_Report19.AutoSize = true;
            this.rb_Report19.BackColor = System.Drawing.Color.Transparent;
            this.rb_Report19.FlatAppearance.BorderSize = 0;
            this.rb_Report19.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rb_Report19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rb_Report19.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Report19.Location = new System.Drawing.Point(174, 90);
            this.rb_Report19.Margin = new System.Windows.Forms.Padding(2);
            this.rb_Report19.Name = "rb_Report19";
            this.rb_Report19.Size = new System.Drawing.Size(100, 46);
            this.rb_Report19.TabIndex = 22;
            this.rb_Report19.Text = "ماسٹر شیٹ";
            this.rb_Report19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb_Report19.UseCompatibleTextRendering = true;
            this.rb_Report19.UseVisualStyleBackColor = true;
            this.rb_Report19.CheckedChanged += new System.EventHandler(this.SetReport);
            // 
            // radioButton3
            // 
            this.radioButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton3.AutoSize = true;
            this.radioButton3.BackColor = System.Drawing.Color.Transparent;
            this.radioButton3.Enabled = false;
            this.radioButton3.FlatAppearance.BorderSize = 0;
            this.radioButton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.radioButton3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton3.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.Location = new System.Drawing.Point(574, 346);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(153, 46);
            this.radioButton3.TabIndex = 21;
            this.radioButton3.Text = "بیوپاری بل آمد وار";
            this.radioButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton3.UseCompatibleTextRendering = true;
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // rbBqayaSale
            // 
            this.rbBqayaSale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbBqayaSale.AutoSize = true;
            this.rbBqayaSale.BackColor = System.Drawing.Color.Transparent;
            this.rbBqayaSale.Enabled = false;
            this.rbBqayaSale.FlatAppearance.BorderSize = 0;
            this.rbBqayaSale.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rbBqayaSale.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbBqayaSale.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBqayaSale.Location = new System.Drawing.Point(585, 90);
            this.rbBqayaSale.Margin = new System.Windows.Forms.Padding(2);
            this.rbBqayaSale.Name = "rbBqayaSale";
            this.rbBqayaSale.Size = new System.Drawing.Size(140, 46);
            this.rbBqayaSale.TabIndex = 20;
            this.rbBqayaSale.Text = "بقایا سیل رپورٹ";
            this.rbBqayaSale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbBqayaSale.UseCompatibleTextRendering = true;
            this.rbBqayaSale.UseVisualStyleBackColor = true;
            this.rbBqayaSale.CheckedChanged += new System.EventHandler(this.SetReport);
            // 
            // rb_Report20
            // 
            this.rb_Report20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_Report20.AutoSize = true;
            this.rb_Report20.BackColor = System.Drawing.Color.Transparent;
            this.rb_Report20.FlatAppearance.BorderSize = 0;
            this.rb_Report20.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rb_Report20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rb_Report20.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Report20.Location = new System.Drawing.Point(166, 41);
            this.rb_Report20.Margin = new System.Windows.Forms.Padding(2);
            this.rb_Report20.Name = "rb_Report20";
            this.rb_Report20.Size = new System.Drawing.Size(104, 46);
            this.rb_Report20.TabIndex = 19;
            this.rb_Report20.Text = "فرد حساب";
            this.rb_Report20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb_Report20.UseCompatibleTextRendering = true;
            this.rb_Report20.UseVisualStyleBackColor = true;
            this.rb_Report20.CheckedChanged += new System.EventHandler(this.SetReport);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.DodgerBlue;
            this.label3.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(-5, 306);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(742, 38);
            this.label3.TabIndex = 18;
            this.label3.Text = "بیجک/  بکری رپورٹ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rb_Report17
            // 
            this.rb_Report17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_Report17.AutoSize = true;
            this.rb_Report17.BackColor = System.Drawing.Color.Transparent;
            this.rb_Report17.Enabled = false;
            this.rb_Report17.FlatAppearance.BorderSize = 0;
            this.rb_Report17.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rb_Report17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rb_Report17.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Report17.Location = new System.Drawing.Point(585, 502);
            this.rb_Report17.Margin = new System.Windows.Forms.Padding(2);
            this.rb_Report17.Name = "rb_Report17";
            this.rb_Report17.Size = new System.Drawing.Size(118, 46);
            this.rb_Report17.TabIndex = 16;
            this.rb_Report17.Text = "ادھار تفصیل";
            this.rb_Report17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb_Report17.UseCompatibleTextRendering = true;
            this.rb_Report17.UseVisualStyleBackColor = true;
            this.rb_Report17.Visible = false;
            this.rb_Report17.Click += new System.EventHandler(this.SetReport);
            // 
            // rb_Report18
            // 
            this.rb_Report18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_Report18.AutoSize = true;
            this.rb_Report18.BackColor = System.Drawing.Color.Transparent;
            this.rb_Report18.FlatAppearance.BorderSize = 0;
            this.rb_Report18.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rb_Report18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rb_Report18.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Report18.Location = new System.Drawing.Point(608, 202);
            this.rb_Report18.Margin = new System.Windows.Forms.Padding(2);
            this.rb_Report18.Name = "rb_Report18";
            this.rb_Report18.Size = new System.Drawing.Size(117, 46);
            this.rb_Report18.TabIndex = 17;
            this.rb_Report18.Text = "نقدی تفصیل";
            this.rb_Report18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb_Report18.UseCompatibleTextRendering = true;
            this.rb_Report18.UseVisualStyleBackColor = true;
            this.rb_Report18.Click += new System.EventHandler(this.SetReport);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.DodgerBlue;
            this.label2.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 146);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(744, 38);
            this.label2.TabIndex = 17;
            this.label2.Text = "خسرہ/  گاہک رپورٹ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rb_Report13
            // 
            this.rb_Report13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_Report13.AutoSize = true;
            this.rb_Report13.BackColor = System.Drawing.Color.Transparent;
            this.rb_Report13.FlatAppearance.BorderSize = 0;
            this.rb_Report13.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rb_Report13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rb_Report13.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Report13.Location = new System.Drawing.Point(237, 255);
            this.rb_Report13.Margin = new System.Windows.Forms.Padding(2);
            this.rb_Report13.Name = "rb_Report13";
            this.rb_Report13.Size = new System.Drawing.Size(123, 46);
            this.rb_Report13.TabIndex = 12;
            this.rb_Report13.Text = "گاہک ریکوری";
            this.rb_Report13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb_Report13.UseCompatibleTextRendering = true;
            this.rb_Report13.UseVisualStyleBackColor = true;
            this.rb_Report13.Click += new System.EventHandler(this.SetReport);
            // 
            // rb_Report07
            // 
            this.rb_Report07.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_Report07.AutoSize = true;
            this.rb_Report07.BackColor = System.Drawing.Color.Transparent;
            this.rb_Report07.FlatAppearance.BorderSize = 0;
            this.rb_Report07.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rb_Report07.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rb_Report07.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Report07.Location = new System.Drawing.Point(388, 346);
            this.rb_Report07.Margin = new System.Windows.Forms.Padding(2);
            this.rb_Report07.Name = "rb_Report07";
            this.rb_Report07.Size = new System.Drawing.Size(156, 46);
            this.rb_Report07.TabIndex = 6;
            this.rb_Report07.Text = "بیوپاری بکری جات";
            this.rb_Report07.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb_Report07.UseCompatibleTextRendering = true;
            this.rb_Report07.UseVisualStyleBackColor = true;
            this.rb_Report07.Click += new System.EventHandler(this.SetReport);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.DodgerBlue;
            this.label1.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-6, -8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(738, 47);
            this.label1.TabIndex = 16;
            this.label1.Text = "اکاؤنٹس / چٹھہ جات";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rb_Report11
            // 
            this.rb_Report11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_Report11.AutoSize = true;
            this.rb_Report11.BackColor = System.Drawing.Color.Transparent;
            this.rb_Report11.FlatAppearance.BorderSize = 0;
            this.rb_Report11.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rb_Report11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rb_Report11.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Report11.Location = new System.Drawing.Point(279, 90);
            this.rb_Report11.Margin = new System.Windows.Forms.Padding(2);
            this.rb_Report11.Name = "rb_Report11";
            this.rb_Report11.Size = new System.Drawing.Size(133, 46);
            this.rb_Report11.TabIndex = 10;
            this.rb_Report11.Text = "فرم ماہانہ آمدن";
            this.rb_Report11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb_Report11.UseCompatibleTextRendering = true;
            this.rb_Report11.UseVisualStyleBackColor = true;
            this.rb_Report11.Click += new System.EventHandler(this.SetReport);
            // 
            // rb_Report06
            // 
            this.rb_Report06.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_Report06.AutoSize = true;
            this.rb_Report06.BackColor = System.Drawing.Color.Transparent;
            this.rb_Report06.FlatAppearance.BorderSize = 0;
            this.rb_Report06.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rb_Report06.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rb_Report06.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Report06.Location = new System.Drawing.Point(629, 255);
            this.rb_Report06.Margin = new System.Windows.Forms.Padding(2);
            this.rb_Report06.Name = "rb_Report06";
            this.rb_Report06.Size = new System.Drawing.Size(95, 46);
            this.rb_Report06.TabIndex = 5;
            this.rb_Report06.Text = "گاہک بل";
            this.rb_Report06.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb_Report06.UseCompatibleTextRendering = true;
            this.rb_Report06.UseVisualStyleBackColor = true;
            this.rb_Report06.Click += new System.EventHandler(this.SetReport);
            // 
            // rb_Report08
            // 
            this.rb_Report08.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_Report08.AutoSize = true;
            this.rb_Report08.BackColor = System.Drawing.Color.Transparent;
            this.rb_Report08.FlatAppearance.BorderSize = 0;
            this.rb_Report08.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rb_Report08.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rb_Report08.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Report08.Location = new System.Drawing.Point(415, 255);
            this.rb_Report08.Margin = new System.Windows.Forms.Padding(2);
            this.rb_Report08.Name = "rb_Report08";
            this.rb_Report08.Size = new System.Drawing.Size(129, 46);
            this.rb_Report08.TabIndex = 7;
            this.rb_Report08.Text = "گاہک وار بکری";
            this.rb_Report08.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb_Report08.UseCompatibleTextRendering = true;
            this.rb_Report08.UseVisualStyleBackColor = true;
            this.rb_Report08.Click += new System.EventHandler(this.SetReport);
            // 
            // rb_Report02
            // 
            this.rb_Report02.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_Report02.AutoSize = true;
            this.rb_Report02.BackColor = System.Drawing.Color.Transparent;
            this.rb_Report02.FlatAppearance.BorderSize = 0;
            this.rb_Report02.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rb_Report02.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rb_Report02.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Report02.Location = new System.Drawing.Point(419, 41);
            this.rb_Report02.Margin = new System.Windows.Forms.Padding(2);
            this.rb_Report02.Name = "rb_Report02";
            this.rb_Report02.Size = new System.Drawing.Size(103, 46);
            this.rb_Report02.TabIndex = 1;
            this.rb_Report02.Text = "کیش روکڑ";
            this.rb_Report02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb_Report02.UseCompatibleTextRendering = true;
            this.rb_Report02.UseVisualStyleBackColor = true;
            this.rb_Report02.Click += new System.EventHandler(this.SetReport);
            // 
            // rb_Report03
            // 
            this.rb_Report03.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_Report03.AutoSize = true;
            this.rb_Report03.BackColor = System.Drawing.Color.Transparent;
            this.rb_Report03.FlatAppearance.BorderSize = 0;
            this.rb_Report03.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rb_Report03.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rb_Report03.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Report03.Location = new System.Drawing.Point(277, 41);
            this.rb_Report03.Margin = new System.Windows.Forms.Padding(2);
            this.rb_Report03.Name = "rb_Report03";
            this.rb_Report03.Size = new System.Drawing.Size(135, 46);
            this.rb_Report03.TabIndex = 2;
            this.rb_Report03.Text = "کھاتہ چٹھہ جات";
            this.rb_Report03.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb_Report03.UseCompatibleTextRendering = true;
            this.rb_Report03.UseVisualStyleBackColor = true;
            this.rb_Report03.Click += new System.EventHandler(this.SetReport);
            // 
            // rb_Report01
            // 
            this.rb_Report01.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_Report01.AutoSize = true;
            this.rb_Report01.BackColor = System.Drawing.Color.Transparent;
            this.rb_Report01.FlatAppearance.BorderSize = 0;
            this.rb_Report01.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rb_Report01.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rb_Report01.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Report01.Location = new System.Drawing.Point(528, 41);
            this.rb_Report01.Margin = new System.Windows.Forms.Padding(2);
            this.rb_Report01.Name = "rb_Report01";
            this.rb_Report01.Size = new System.Drawing.Size(197, 46);
            this.rb_Report01.TabIndex = 0;
            this.rb_Report01.Text = "لین دین کھاتہ / پارٹی کھاتہ";
            this.rb_Report01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb_Report01.UseCompatibleTextRendering = true;
            this.rb_Report01.UseVisualStyleBackColor = true;
            this.rb_Report01.Click += new System.EventHandler(this.SetReport);
            // 
            // rb_Report14
            // 
            this.rb_Report14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_Report14.BackColor = System.Drawing.Color.Transparent;
            this.rb_Report14.FlatAppearance.BorderSize = 0;
            this.rb_Report14.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rb_Report14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rb_Report14.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Report14.Location = new System.Drawing.Point(378, 202);
            this.rb_Report14.Margin = new System.Windows.Forms.Padding(2);
            this.rb_Report14.Name = "rb_Report14";
            this.rb_Report14.Size = new System.Drawing.Size(166, 46);
            this.rb_Report14.TabIndex = 13;
            this.rb_Report14.Text = "ادھار تفصیل / بیوپاری بکری";
            this.rb_Report14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rb_Report14.UseCompatibleTextRendering = true;
            this.rb_Report14.UseVisualStyleBackColor = true;
            this.rb_Report14.Click += new System.EventHandler(this.SetReport);
            // 
            // rb_Report15
            // 
            this.rb_Report15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_Report15.AutoSize = true;
            this.rb_Report15.BackColor = System.Drawing.Color.Transparent;
            this.rb_Report15.FlatAppearance.BorderSize = 0;
            this.rb_Report15.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rb_Report15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rb_Report15.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Report15.Location = new System.Drawing.Point(289, 346);
            this.rb_Report15.Margin = new System.Windows.Forms.Padding(2);
            this.rb_Report15.Name = "rb_Report15";
            this.rb_Report15.Size = new System.Drawing.Size(72, 46);
            this.rb_Report15.TabIndex = 14;
            this.rb_Report15.Text = "بیجک";
            this.rb_Report15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb_Report15.UseCompatibleTextRendering = true;
            this.rb_Report15.UseVisualStyleBackColor = true;
            this.rb_Report15.Click += new System.EventHandler(this.SetReport);
            // 
            // rb_Report09
            // 
            this.rb_Report09.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_Report09.AutoSize = true;
            this.rb_Report09.BackColor = System.Drawing.Color.Transparent;
            this.rb_Report09.FlatAppearance.BorderSize = 0;
            this.rb_Report09.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rb_Report09.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rb_Report09.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Report09.Location = new System.Drawing.Point(52, 202);
            this.rb_Report09.Margin = new System.Windows.Forms.Padding(2);
            this.rb_Report09.Name = "rb_Report09";
            this.rb_Report09.Size = new System.Drawing.Size(108, 46);
            this.rb_Report09.TabIndex = 8;
            this.rb_Report09.Text = "خسرہ گاہک";
            this.rb_Report09.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb_Report09.UseCompatibleTextRendering = true;
            this.rb_Report09.UseVisualStyleBackColor = true;
            this.rb_Report09.Click += new System.EventHandler(this.SetReport);
            // 
            // rb_Report10
            // 
            this.rb_Report10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_Report10.AutoSize = true;
            this.rb_Report10.BackColor = System.Drawing.Color.Transparent;
            this.rb_Report10.FlatAppearance.BorderSize = 0;
            this.rb_Report10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rb_Report10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rb_Report10.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Report10.Location = new System.Drawing.Point(224, 202);
            this.rb_Report10.Margin = new System.Windows.Forms.Padding(2);
            this.rb_Report10.Name = "rb_Report10";
            this.rb_Report10.Size = new System.Drawing.Size(137, 46);
            this.rb_Report10.TabIndex = 9;
            this.rb_Report10.Text = "خسرہ گاہک مختصر";
            this.rb_Report10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb_Report10.UseCompatibleTextRendering = true;
            this.rb_Report10.UseVisualStyleBackColor = true;
            this.rb_Report10.Click += new System.EventHandler(this.SetReport);
            // 
            // rb_Report16
            // 
            this.rb_Report16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_Report16.AutoSize = true;
            this.rb_Report16.BackColor = System.Drawing.Color.Transparent;
            this.rb_Report16.FlatAppearance.BorderSize = 0;
            this.rb_Report16.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rb_Report16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rb_Report16.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Report16.Location = new System.Drawing.Point(26, 41);
            this.rb_Report16.Margin = new System.Windows.Forms.Padding(2);
            this.rb_Report16.Name = "rb_Report16";
            this.rb_Report16.Size = new System.Drawing.Size(134, 46);
            this.rb_Report16.TabIndex = 15;
            this.rb_Report16.Text = "سب پارٹی کھاتہ";
            this.rb_Report16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb_Report16.UseCompatibleTextRendering = true;
            this.rb_Report16.UseVisualStyleBackColor = true;
            this.rb_Report16.Click += new System.EventHandler(this.SetReport);
            // 
            // rb_Report12
            // 
            this.rb_Report12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_Report12.AutoSize = true;
            this.rb_Report12.BackColor = System.Drawing.Color.Transparent;
            this.rb_Report12.FlatAppearance.BorderSize = 0;
            this.rb_Report12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rb_Report12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rb_Report12.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Report12.Location = new System.Drawing.Point(417, 90);
            this.rb_Report12.Margin = new System.Windows.Forms.Padding(2);
            this.rb_Report12.Name = "rb_Report12";
            this.rb_Report12.Size = new System.Drawing.Size(106, 46);
            this.rb_Report12.TabIndex = 11;
            this.rb_Report12.Text = "ٹاپ کمیشن";
            this.rb_Report12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb_Report12.UseCompatibleTextRendering = true;
            this.rb_Report12.UseVisualStyleBackColor = true;
            this.rb_Report12.Click += new System.EventHandler(this.SetReport);
            // 
            // lblDtp
            // 
            this.lblDtp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDtp.AutoSize = true;
            this.lblDtp.Location = new System.Drawing.Point(820, 47);
            this.lblDtp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDtp.Name = "lblDtp";
            this.lblDtp.Size = new System.Drawing.Size(69, 32);
            this.lblDtp.TabIndex = 1;
            this.lblDtp.Text = "تاریخ شروع";
            // 
            // dtp
            // 
            this.dtp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtp.CustomFormat = "dd-MMM-yyyy";
            this.dtp.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            this.dtp.Font = new System.Drawing.Font("Arial Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp.Location = new System.Drawing.Point(716, 81);
            this.dtp.Margin = new System.Windows.Forms.Padding(2);
            this.dtp.MinDate = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(172, 33);
            this.dtp.TabIndex = 2;
            this.dtp.Value = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            // 
            // dtp2
            // 
            this.dtp2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtp2.CustomFormat = "dd-MMM-yyyy";
            this.dtp2.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            this.dtp2.Font = new System.Drawing.Font("Arial Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp2.Location = new System.Drawing.Point(539, 81);
            this.dtp2.Margin = new System.Windows.Forms.Padding(2);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(172, 33);
            this.dtp2.TabIndex = 5;
            this.dtp2.Value = new System.DateTime(2025, 12, 13, 0, 0, 0, 0);
            // 
            // lblDate2
            // 
            this.lblDate2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate2.AutoSize = true;
            this.lblDate2.Location = new System.Drawing.Point(644, 47);
            this.lblDate2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDate2.Name = "lblDate2";
            this.lblDate2.Size = new System.Drawing.Size(58, 32);
            this.lblDate2.TabIndex = 4;
            this.lblDate2.Text = "تاریخ آخر";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PeachPuff;
            this.panel1.Controls.Add(this.cbSummary);
            this.panel1.Controls.Add(this.cbInActive);
            this.panel1.Controls.Add(this.cbZero);
            this.panel1.Controls.Add(this.cmbSort);
            this.panel1.Controls.Add(this.lblSort);
            this.panel1.Controls.Add(this.btnViewReport);
            this.panel1.Controls.Add(this.lblBill);
            this.panel1.Controls.Add(this.txtBillNo);
            this.panel1.Controls.Add(this.lblCity);
            this.panel1.Controls.Add(this.cmbCity);
            this.panel1.Controls.Add(this.lblgroup);
            this.panel1.Controls.Add(this.cmbGroups);
            this.panel1.Controls.Add(this.dgvHelp);
            this.panel1.Controls.Add(this._pname);
            this.panel1.Controls.Add(this.lblParty);
            this.panel1.Controls.Add(this._pid);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.dtp);
            this.panel1.Controls.Add(this.dtp2);
            this.panel1.Controls.Add(this.lblDtp);
            this.panel1.Controls.Add(this.lblDate2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(897, 572);
            this.panel1.TabIndex = 5;
            // 
            // cbSummary
            // 
            this.cbSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSummary.AutoSize = true;
            this.cbSummary.Location = new System.Drawing.Point(231, 106);
            this.cbSummary.Name = "cbSummary";
            this.cbSummary.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbSummary.Size = new System.Drawing.Size(43, 36);
            this.cbSummary.TabIndex = 18;
            this.cbSummary.Text = "مختصر";
            this.cbSummary.TextVerticalAlignment = Janus.Windows.EditControls.TextAlignment.Near;
            // 
            // cbInActive
            // 
            this.cbInActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbInActive.AutoSize = true;
            this.cbInActive.Location = new System.Drawing.Point(168, 128);
            this.cbInActive.Name = "cbInActive";
            this.cbInActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbInActive.Size = new System.Drawing.Size(106, 36);
            this.cbInActive.TabIndex = 17;
            this.cbInActive.Text = "بشمول ڈوبت کھاتے";
            this.cbInActive.TextVerticalAlignment = Janus.Windows.EditControls.TextAlignment.Near;
            this.cbInActive.Visible = false;
            // 
            // cbZero
            // 
            this.cbZero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbZero.AutoSize = true;
            this.cbZero.Location = new System.Drawing.Point(204, 81);
            this.cbZero.Name = "cbZero";
            this.cbZero.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbZero.Size = new System.Drawing.Size(70, 36);
            this.cbZero.TabIndex = 6;
            this.cbZero.Text = " بشمول زیرو";
            this.cbZero.TextVerticalAlignment = Janus.Windows.EditControls.TextAlignment.Near;
            // 
            // cmbSort
            // 
            this.cmbSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            uiComboBoxItem1.FormatStyle.Alpha = 0;
            uiComboBoxItem1.IsSeparator = false;
            uiComboBoxItem1.Text = "موجودہ کوڈ";
            uiComboBoxItem1.Value = 0;
            uiComboBoxItem2.FormatStyle.Alpha = 0;
            uiComboBoxItem2.IsSeparator = false;
            uiComboBoxItem2.Text = "پرانا کوڈ";
            uiComboBoxItem2.Value = 1;
            this.cmbSort.Items.AddRange(new Janus.Windows.EditControls.UIComboBoxItem[] {
            uiComboBoxItem1,
            uiComboBoxItem2});
            this.cmbSort.Location = new System.Drawing.Point(301, 125);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbSort.Size = new System.Drawing.Size(143, 39);
            this.cmbSort.TabIndex = 16;
            // 
            // lblSort
            // 
            this.lblSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSort.AutoSize = true;
            this.lblSort.Location = new System.Drawing.Point(449, 125);
            this.lblSort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(44, 32);
            this.lblSort.TabIndex = 15;
            this.lblSort.Text = "ترتیب";
            // 
            // btnViewReport
            // 
            this.btnViewReport.AutoSize = true;
            this.btnViewReport.Image = global::MandiPOS.Properties.Resources.printernew;
            this.btnViewReport.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Center;
            this.btnViewReport.ImageSize = new System.Drawing.Size(48, 48);
            this.btnViewReport.ImageVerticalAlignment = Janus.Windows.EditControls.ImageVerticalAlignment.BottomOfText;
            this.btnViewReport.Location = new System.Drawing.Point(10, 70);
            this.btnViewReport.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(89, 110);
            this.btnViewReport.TabIndex = 11;
            this.btnViewReport.Text = "رپورٹ دیکھیں";
            this.btnViewReport.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // lblBill
            // 
            this.lblBill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBill.AutoSize = true;
            this.lblBill.Location = new System.Drawing.Point(839, 115);
            this.lblBill.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBill.Name = "lblBill";
            this.lblBill.Size = new System.Drawing.Size(46, 32);
            this.lblBill.TabIndex = 14;
            this.lblBill.Text = "بل نمبر";
            this.lblBill.Visible = false;
            // 
            // txtBillNo
            // 
            this.txtBillNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBillNo.Location = new System.Drawing.Point(764, 149);
            this.txtBillNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(123, 39);
            this.txtBillNo.TabIndex = 13;
            this.txtBillNo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            // 
            // lblCity
            // 
            this.lblCity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(460, 47);
            this.lblCity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(30, 32);
            this.lblCity.TabIndex = 7;
            this.lblCity.Text = "شہر";
            // 
            // cmbCity
            // 
            this.cmbCity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            cmbCity_DesignTimeLayout.LayoutString = resources.GetString("cmbCity_DesignTimeLayout.LayoutString");
            this.cmbCity.DesignTimeLayout = cmbCity_DesignTimeLayout;
            this.cmbCity.DropDownDisplayMember = "CityName";
            this.cmbCity.DropDownValueMember = "ID";
            this.cmbCity.Location = new System.Drawing.Point(279, 81);
            this.cmbCity.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbCity.SaveSettings = false;
            this.cmbCity.Size = new System.Drawing.Size(214, 39);
            this.cmbCity.TabIndex = 8;
            this.cmbCity.ValueItemDataMember = "(None)";
            this.cmbCity.ValuesDataMember = null;
            // 
            // lblgroup
            // 
            this.lblgroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblgroup.AutoSize = true;
            this.lblgroup.Location = new System.Drawing.Point(667, 47);
            this.lblgroup.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblgroup.Name = "lblgroup";
            this.lblgroup.Size = new System.Drawing.Size(45, 32);
            this.lblgroup.TabIndex = 3;
            this.lblgroup.Text = "گروپ";
            // 
            // cmbGroups
            // 
            this.cmbGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            cmbGroups_DesignTimeLayout.LayoutString = resources.GetString("cmbGroups_DesignTimeLayout.LayoutString");
            this.cmbGroups.DesignTimeLayout = cmbGroups_DesignTimeLayout;
            this.cmbGroups.DropDownDataSource = this.bs;
            this.cmbGroups.DropDownDisplayMember = "AccountTitle";
            this.cmbGroups.DropDownValueMember = "ID";
            this.cmbGroups.Location = new System.Drawing.Point(497, 81);
            this.cmbGroups.Margin = new System.Windows.Forms.Padding(2);
            this.cmbGroups.Name = "cmbGroups";
            this.cmbGroups.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbGroups.SaveSettings = false;
            this.cmbGroups.Size = new System.Drawing.Size(214, 39);
            this.cmbGroups.TabIndex = 6;
            this.cmbGroups.ValuesDataMember = null;
            // 
            // dgvHelp
            // 
            this.dgvHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHelp.ColumnAutoResize = true;
            this.dgvHelp.DataSource = this.bsParties;
            dgvHelp_DesignTimeLayout.LayoutString = resources.GetString("dgvHelp_DesignTimeLayout.LayoutString");
            this.dgvHelp.DesignTimeLayout = dgvHelp_DesignTimeLayout;
            this.dgvHelp.GroupByBoxVisible = false;
            this.dgvHelp.Location = new System.Drawing.Point(312, 190);
            this.dgvHelp.Margin = new System.Windows.Forms.Padding(2);
            this.dgvHelp.Name = "dgvHelp";
            this.dgvHelp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvHelp.Size = new System.Drawing.Size(576, 371);
            this.dgvHelp.TabIndex = 12;
            this.dgvHelp.Visible = false;
            this.dgvHelp.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            // 
            // _pname
            // 
            this._pname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._pname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this._pname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this._pname.Location = new System.Drawing.Point(539, 149);
            this._pname.Margin = new System.Windows.Forms.Padding(2);
            this._pname.Name = "_pname";
            this._pname.Size = new System.Drawing.Size(349, 39);
            this._pname.TabIndex = 10;
            this._pname.TextChanged += new System.EventHandler(this._pname_TextChanged);
            this._pname.Leave += new System.EventHandler(this._pname_Leave);
            // 
            // lblParty
            // 
            this.lblParty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblParty.AutoSize = true;
            this.lblParty.Location = new System.Drawing.Point(831, 115);
            this.lblParty.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblParty.Name = "lblParty";
            this.lblParty.Size = new System.Drawing.Size(50, 32);
            this.lblParty.TabIndex = 9;
            this.lblParty.Text = "نام پارٹی";
            // 
            // _pid
            // 
            this._pid.Location = new System.Drawing.Point(850, 149);
            this._pid.Margin = new System.Windows.Forms.Padding(2);
            this._pid.Name = "_pid";
            this._pid.ReadOnly = true;
            this._pid.Size = new System.Drawing.Size(87, 39);
            this._pid.TabIndex = 7;
            this._pid.TabStop = false;
            this._pid.Visible = false;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.lblTitle.Size = new System.Drawing.Size(897, 39);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "label3";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bs
            // 
            this.bs.DataSource = typeof(MandiPOS.CLasses.MasterAccounts);
            // 
            // bsParties
            // 
            this.bsParties.DataSource = typeof(MandiPOS.CLasses.DetailAccountView);
            // 
            // chartDataBindingSource
            // 
            this.chartDataBindingSource.DataSource = typeof(MandiPOS.CLasses.ChartData);
            // 
            // bsSubParties
            // 
            this.bsSubParties.DataSource = typeof(MandiPOS.CLasses.DetailAccountView);
            // 
            // frmReportsNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1629, 572);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmReportsNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "رپورٹس";
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsParties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSubParties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.RadioButton rb_Report01;
        private System.Windows.Forms.RadioButton rb_Report02;
        private System.Windows.Forms.RadioButton rb_Report03;
        private System.Windows.Forms.RadioButton rb_Report06;
        private System.Windows.Forms.RadioButton rb_Report07;
        private System.Windows.Forms.RadioButton rb_Report08;
        private System.Windows.Forms.RadioButton rb_Report09;
        private System.Windows.Forms.RadioButton rb_Report10;
        private System.Windows.Forms.RadioButton rb_Report11;
        private System.Windows.Forms.RadioButton rb_Report12;
        private System.Windows.Forms.RadioButton rb_Report13;
        private System.Windows.Forms.RadioButton rb_Report14;
        private System.Windows.Forms.RadioButton rb_Report15;
        private System.Windows.Forms.RadioButton rb_Report16;
        private System.Windows.Forms.RadioButton rb_Report17;
        private System.Windows.Forms.RadioButton rb_Report18;
        private System.Windows.Forms.Label lblDtp;
        private Janus.Windows.CalendarCombo.CalendarCombo dtp;
        private Janus.Windows.CalendarCombo.CalendarCombo dtp2;
        private System.Windows.Forms.Label lblDate2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private Janus.Windows.GridEX.EditControls.EditBox _pname;
        private System.Windows.Forms.Label lblParty;
        private Janus.Windows.GridEX.EditControls.EditBox _pid;
        private Janus.Windows.EditControls.UIButton btnViewReport;
        private System.Windows.Forms.BindingSource bsParties;
        private Janus.Windows.GridEX.GridEX dgvHelp;
        private System.Windows.Forms.Label lblgroup;
        private Janus.Windows.GridEX.EditControls.CheckedComboBox cmbGroups;
        private System.Windows.Forms.BindingSource bs;
        private System.Windows.Forms.Label lblCity;
        private Janus.Windows.GridEX.EditControls.CheckedComboBox cmbCity;
        private System.Windows.Forms.BindingSource chartDataBindingSource;
        private Janus.Windows.GridEX.EditControls.EditBox txtBillNo;
        private System.Windows.Forms.Label lblBill;
        private System.Windows.Forms.BindingSource bsSubParties;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbBqayaSale;
        private System.Windows.Forms.RadioButton rb_Report20;
        private System.Windows.Forms.RadioButton rb_Report21;
        private System.Windows.Forms.RadioButton rb_Report19;
        private System.Windows.Forms.RadioButton radioButton3;
        private Janus.Windows.EditControls.UIComboBox cmbSort;
        private System.Windows.Forms.Label lblSort;
        private Janus.Windows.EditControls.UICheckBox cbSummary;
        private Janus.Windows.EditControls.UICheckBox cbInActive;
        private Janus.Windows.EditControls.UICheckBox cbZero;
    }
}