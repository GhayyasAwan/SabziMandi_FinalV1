namespace MandiPOS.Reports
{
    partial class rptAgreementStatistics
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraReports.UI.XRWatermark xrWatermark1 = new DevExpress.XtraReports.UI.XRWatermark();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.lblDate2 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblDate2Title = new DevExpress.XtraReports.UI.XRLabel();
            this.lblDate1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPartyTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.bndRemarks = new DevExpress.XtraReports.UI.SubBand();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblDetails = new DevExpress.XtraReports.UI.XRLabel();
            this.bndItems = new DevExpress.XtraReports.UI.SubBand();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblItemdetails = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.SubBand1 = new DevExpress.XtraReports.UI.SubBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            this.lblPrintTime = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 10F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 10F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.Detail.HeightF = 33.33333F;
            this.Detail.Name = "Detail";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblPrintTime,
            this.lblDate2,
            this.lblDate2Title,
            this.lblDate1,
            this.xrLabel3,
            this.lblPartyTitle,
            this.xrLabel1});
            this.ReportHeader.HeightF = 114.8333F;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.SubBands.AddRange(new DevExpress.XtraReports.UI.SubBand[] {
            this.bndRemarks,
            this.bndItems,
            this.SubBand1});
            // 
            // lblDate2
            // 
            this.lblDate2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lblDate2.BorderWidth = 0.1F;
            this.lblDate2.CanGrow = false;
            this.lblDate2.Font = new DevExpress.Drawing.DXFont("jameel Noori Nastaleeq", 14F, DevExpress.Drawing.DXFontStyle.Bold);
            this.lblDate2.LocationFloat = new DevExpress.Utils.PointFloat(347.5002F, 78.29167F);
            this.lblDate2.Name = "lblDate2";
            this.lblDate2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2F, 2F, 0F, 0F, 100F);
            this.lblDate2.SizeF = new System.Drawing.SizeF(120.6249F, 36.54166F);
            this.lblDate2.StylePriority.UseBorders = false;
            this.lblDate2.StylePriority.UseBorderWidth = false;
            this.lblDate2.StylePriority.UseFont = false;
            this.lblDate2.StylePriority.UseTextAlignment = false;
            this.lblDate2.Text = "تاریخ اول";
            this.lblDate2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.lblDate2.TextFitMode = DevExpress.XtraReports.UI.TextFitMode.ShrinkOnly;
            this.lblDate2.WordWrap = false;
            // 
            // lblDate2Title
            // 
            this.lblDate2Title.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lblDate2Title.BorderWidth = 0.1F;
            this.lblDate2Title.CanGrow = false;
            this.lblDate2Title.Font = new DevExpress.Drawing.DXFont("jameel Noori Nastaleeq", 14F, DevExpress.Drawing.DXFontStyle.Bold);
            this.lblDate2Title.LocationFloat = new DevExpress.Utils.PointFloat(468.1251F, 78.29167F);
            this.lblDate2Title.Name = "lblDate2Title";
            this.lblDate2Title.Padding = new DevExpress.XtraPrinting.PaddingInfo(2F, 2F, 0F, 0F, 100F);
            this.lblDate2Title.SizeF = new System.Drawing.SizeF(120.6249F, 36.54166F);
            this.lblDate2Title.StylePriority.UseBorders = false;
            this.lblDate2Title.StylePriority.UseBorderWidth = false;
            this.lblDate2Title.StylePriority.UseFont = false;
            this.lblDate2Title.StylePriority.UseTextAlignment = false;
            this.lblDate2Title.Text = "تاریخ دوم";
            this.lblDate2Title.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.lblDate2Title.TextFitMode = DevExpress.XtraReports.UI.TextFitMode.ShrinkOnly;
            this.lblDate2Title.WordWrap = false;
            // 
            // lblDate1
            // 
            this.lblDate1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lblDate1.BorderWidth = 0.1F;
            this.lblDate1.CanGrow = false;
            this.lblDate1.Font = new DevExpress.Drawing.DXFont("jameel Noori Nastaleeq", 14F, DevExpress.Drawing.DXFontStyle.Bold);
            this.lblDate1.LocationFloat = new DevExpress.Utils.PointFloat(588.7501F, 78.29167F);
            this.lblDate1.Name = "lblDate1";
            this.lblDate1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2F, 2F, 0F, 0F, 100F);
            this.lblDate1.SizeF = new System.Drawing.SizeF(120.6249F, 36.54166F);
            this.lblDate1.StylePriority.UseBorders = false;
            this.lblDate1.StylePriority.UseBorderWidth = false;
            this.lblDate1.StylePriority.UseFont = false;
            this.lblDate1.StylePriority.UseTextAlignment = false;
            this.lblDate1.Text = "تاریخ اول";
            this.lblDate1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.lblDate1.TextFitMode = DevExpress.XtraReports.UI.TextFitMode.ShrinkOnly;
            this.lblDate1.WordWrap = false;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel3.BorderWidth = 0.1F;
            this.xrLabel3.CanGrow = false;
            this.xrLabel3.Font = new DevExpress.Drawing.DXFont("jameel Noori Nastaleeq", 14F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(709.375F, 78.29167F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2F, 2F, 0F, 0F, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(120.6249F, 36.54166F);
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseBorderWidth = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "تاریخ اول";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrLabel3.TextFitMode = DevExpress.XtraReports.UI.TextFitMode.ShrinkOnly;
            this.xrLabel3.WordWrap = false;
            // 
            // lblPartyTitle
            // 
            this.lblPartyTitle.CanGrow = false;
            this.lblPartyTitle.Font = new DevExpress.Drawing.DXFont("calibri", 20F, DevExpress.Drawing.DXFontStyle.Bold);
            this.lblPartyTitle.LocationFloat = new DevExpress.Utils.PointFloat(0F, 41.75F);
            this.lblPartyTitle.Name = "lblPartyTitle";
            this.lblPartyTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2F, 2F, 0F, 0F, 100F);
            this.lblPartyTitle.SizeF = new System.Drawing.SizeF(830F, 36.54166F);
            this.lblPartyTitle.StylePriority.UseFont = false;
            this.lblPartyTitle.StylePriority.UseTextAlignment = false;
            this.lblPartyTitle.Text = "نام بیوپاری";
            this.lblPartyTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.lblPartyTitle.TextFitMode = DevExpress.XtraReports.UI.TextFitMode.ShrinkOnly;
            this.lblPartyTitle.WordWrap = false;
            // 
            // xrLabel1
            // 
            this.xrLabel1.CanGrow = false;
            this.xrLabel1.Font = new DevExpress.Drawing.DXFont("calibri", 20F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2F, 2F, 0F, 0F, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(830F, 41.75F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "تفصیل معاہدہ";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrLabel1.TextFitMode = DevExpress.XtraReports.UI.TextFitMode.ShrinkOnly;
            this.xrLabel1.WordWrap = false;
            // 
            // bndRemarks
            // 
            this.bndRemarks.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel8,
            this.lblDetails});
            this.bndRemarks.HeightF = 36.54166F;
            this.bndRemarks.Name = "bndRemarks";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel8.BorderWidth = 0.1F;
            this.xrLabel8.CanGrow = false;
            this.xrLabel8.Font = new DevExpress.Drawing.DXFont("jameel Noori Nastaleeq", 14F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(709.3751F, 0F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2F, 2F, 0F, 0F, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(120.6249F, 36.54166F);
            this.xrLabel8.StylePriority.UseBorders = false;
            this.xrLabel8.StylePriority.UseBorderWidth = false;
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "تفصیل";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrLabel8.TextFitMode = DevExpress.XtraReports.UI.TextFitMode.ShrinkOnly;
            this.xrLabel8.WordWrap = false;
            // 
            // lblDetails
            // 
            this.lblDetails.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.lblDetails.BorderWidth = 0.1F;
            this.lblDetails.CanGrow = false;
            this.lblDetails.Font = new DevExpress.Drawing.DXFont("jameel Noori Nastaleeq", 14F);
            this.lblDetails.LocationFloat = new DevExpress.Utils.PointFloat(10.0001F, 0F);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Padding = new DevExpress.XtraPrinting.PaddingInfo(2F, 10F, 0F, 0F, 100F);
            this.lblDetails.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.lblDetails.SizeF = new System.Drawing.SizeF(699.3749F, 36.54166F);
            this.lblDetails.StylePriority.UseBorders = false;
            this.lblDetails.StylePriority.UseBorderWidth = false;
            this.lblDetails.StylePriority.UseFont = false;
            this.lblDetails.StylePriority.UsePadding = false;
            this.lblDetails.StylePriority.UseTextAlignment = false;
            this.lblDetails.Text = "تاریخ اول";
            this.lblDetails.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.lblDetails.TextFitMode = DevExpress.XtraReports.UI.TextFitMode.ShrinkOnly;
            this.lblDetails.WordWrap = false;
            // 
            // bndItems
            // 
            this.bndItems.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4,
            this.lblItemdetails});
            this.bndItems.HeightF = 36.54166F;
            this.bndItems.Name = "bndItems";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel4.BorderWidth = 0.1F;
            this.xrLabel4.CanGrow = false;
            this.xrLabel4.Font = new DevExpress.Drawing.DXFont("jameel Noori Nastaleeq", 14F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(709.3751F, 0F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2F, 2F, 0F, 0F, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(120.6249F, 36.54166F);
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.StylePriority.UseBorderWidth = false;
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "اشیاء";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrLabel4.TextFitMode = DevExpress.XtraReports.UI.TextFitMode.ShrinkOnly;
            this.xrLabel4.WordWrap = false;
            // 
            // lblItemdetails
            // 
            this.lblItemdetails.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.lblItemdetails.BorderWidth = 0.1F;
            this.lblItemdetails.CanGrow = false;
            this.lblItemdetails.Font = new DevExpress.Drawing.DXFont("jameel Noori Nastaleeq", 14F);
            this.lblItemdetails.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 0F);
            this.lblItemdetails.Name = "lblItemdetails";
            this.lblItemdetails.Padding = new DevExpress.XtraPrinting.PaddingInfo(2F, 10F, 0F, 0F, 100F);
            this.lblItemdetails.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.lblItemdetails.SizeF = new System.Drawing.SizeF(699.3749F, 36.54166F);
            this.lblItemdetails.StylePriority.UseBorders = false;
            this.lblItemdetails.StylePriority.UseBorderWidth = false;
            this.lblItemdetails.StylePriority.UseFont = false;
            this.lblItemdetails.StylePriority.UsePadding = false;
            this.lblItemdetails.StylePriority.UseTextAlignment = false;
            this.lblItemdetails.Text = "تاریخ اول";
            this.lblItemdetails.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.lblItemdetails.TextFitMode = DevExpress.XtraReports.UI.TextFitMode.ShrinkOnly;
            this.lblItemdetails.WordWrap = false;
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.BorderWidth = 0.1F;
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(188.5417F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2F, 2F, 0F, 0F, 100F);
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(452.9167F, 33.33333F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseBorderWidth = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 11.5D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.CanGrow = false;
            this.xrTableCell1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Qty]")});
            this.xrTableCell1.Font = new DevExpress.Drawing.DXFont("verdana", 9.75F);
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseFont = false;
            this.xrTableCell1.Text = "xrTableCell1";
            this.xrTableCell1.TextFormatString = "{0:#,##.##}";
            this.xrTableCell1.Weight = 0.15873015873015872D;
            this.xrTableCell1.WordWrap = false;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.CanGrow = false;
            this.xrTableCell2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ItemTitle]")});
            this.xrTableCell2.Font = new DevExpress.Drawing.DXFont("jameel Noori Nastaleeq", 12F);
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.Text = "xrTableCell2";
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell2.Weight = 0.15873015873015872D;
            this.xrTableCell2.WordWrap = false;
            // 
            // SubBand1
            // 
            this.SubBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.SubBand1.HeightF = 53.5834F;
            this.SubBand1.Name = "SubBand1";
            // 
            // xrTable2
            // 
            this.xrTable2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.BorderWidth = 0.25F;
            this.xrTable2.Font = new DevExpress.Drawing.DXFont("jameel Noori Nastaleeq", 14F);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(188.5417F, 20.25007F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2F, 2F, 0F, 0F, 100F);
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(452.9167F, 33.33333F);
            this.xrTable2.StylePriority.UseBackColor = false;
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseBorderWidth = false;
            this.xrTable2.StylePriority.UseFont = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell3,
            this.xrTableCell4});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 11.5D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.CanGrow = false;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "تعداد نگ";
            this.xrTableCell3.TextFormatString = "{0:#,##.##}";
            this.xrTableCell3.Weight = 0.15873015873015872D;
            this.xrTableCell3.WordWrap = false;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.CanGrow = false;
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StylePriority.UseTextAlignment = false;
            this.xrTableCell4.Text = "نام اشیاء";
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell4.Weight = 0.15873015873015872D;
            this.xrTableCell4.WordWrap = false;
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataSource = typeof(MandiPOS.CLasses.usp_ItemRecordViaAgreementID);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // lblPrintTime
            // 
            this.lblPrintTime.CanGrow = false;
            this.lblPrintTime.Font = new DevExpress.Drawing.DXFont("calibri", 10F);
            this.lblPrintTime.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lblPrintTime.Name = "lblPrintTime";
            this.lblPrintTime.Padding = new DevExpress.XtraPrinting.PaddingInfo(10F, 2F, 0F, 0F, 100F);
            this.lblPrintTime.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.lblPrintTime.SizeF = new System.Drawing.SizeF(286.25F, 36.54166F);
            this.lblPrintTime.StylePriority.UseFont = false;
            this.lblPrintTime.StylePriority.UsePadding = false;
            this.lblPrintTime.StylePriority.UseTextAlignment = false;
            this.lblPrintTime.Text = "نام بیوپاری";
            this.lblPrintTime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lblPrintTime.TextFitMode = DevExpress.XtraReports.UI.TextFitMode.ShrinkOnly;
            this.lblPrintTime.WordWrap = false;
            // 
            // rptAgreementStatistics
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.ReportHeader});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource1});
            this.DataSource = this.objectDataSource1;
            this.Font = new DevExpress.Drawing.DXFont("Arial", 9.75F);
            this.Margins = new DevExpress.Drawing.DXMargins(10F, 10F, 10F, 10F);
            this.Padding = new DevExpress.XtraPrinting.PaddingInfo(10F, 10F, 10F, 10F, 100F);
            this.Version = "26.1";
            xrWatermark1.Id = "Watermark1";
            this.Watermarks.AddRange(new DevExpress.XtraPrinting.Drawing.Watermark[] {
            xrWatermark1});
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel lblPartyTitle;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel lblDetails;
        private DevExpress.XtraReports.UI.XRLabel lblDate2;
        private DevExpress.XtraReports.UI.XRLabel lblDate2Title;
        private DevExpress.XtraReports.UI.XRLabel lblDate1;
        private DevExpress.XtraReports.UI.SubBand bndRemarks;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.SubBand bndItems;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel lblItemdetails;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.SubBand SubBand1;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
        private DevExpress.XtraReports.UI.XRLabel lblPrintTime;
    }
}
