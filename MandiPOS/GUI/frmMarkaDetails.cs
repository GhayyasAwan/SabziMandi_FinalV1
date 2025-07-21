using Dapper;

using DevExpress.XtraReports.UI;

using Janus.Windows.GridEX;

using MandiPOS.CLasses;
using MandiPOS.Reports;

using System;
using System.Linq;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class frmMarkaDetails : Form
    {

        int partyID;
        string marka;
        public frmMarkaDetails(int PartyID, DateTime date1, DateTime date2, string Marka)
        {
            InitializeComponent();
            label1.Text = Marka;
            partyID = PartyID;
            d01.Value = date1; d02.Value = date2; marka = Marka;
            Refresh();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        rptMarkaSummary report;
        public override void Refresh()
        {
            string sql = $@"
                            Declare @PartyID int ='{partyID}'; Declare @Marka Nvarchar(250)=N'{marka}';
                            Declare @date1 date='{d01.Value.Date:yyyy-MM-dd}'; declare @date2 date='{d02.Value.Date:yyyy-MM-dd}';
Select * from vw_vendorSale Where ArrivalNo in  ( Select ArrivalNo From vw_SubpartiesSale Where PartyID=@PartyID and Marka=@Marka And (ArrivalDate Between @date1 and @date2))";
            System.Collections.Generic.List<vw_vendorSale> data = new db().Query<vw_vendorSale>(sql).ToList();
            vwvendorSaleBindingSource.DataSource = data;
            vwvendorSaleBindingSource.ResetBindings(false);

            sql = $@"Declare @PartyID int ='{partyID}'; Declare @Marka Nvarchar(250)=N'{marka}';
                            Declare @date1 date='{d01.Value.Date:yyyy-MM-dd}'; declare @date2 date='{d02.Value.Date:yyyy-MM-dd}';
SELECT STRING_AGG(CONCAT(ItemTitle, '=', TotalQty), ', ') AS ItemSummary
FROM (
    SELECT 
        i.ItemTitle,
        SUM(sd.ItemQty) AS TotalQty
    FROM 
        tblSale s
    INNER JOIN 
        tblSaleDetail sd ON s.ID = sd.SaleID
    INNER JOIN 
        tblItems i ON sd.ItemID = i.ID
    WHERE 
        s.ArrivalNo IN ( Select ArrivalNo From vw_SubpartiesSale Where PartyID=@PartyID and Marka=@Marka And (ArrivalDate Between @date1 and @date2))
    GROUP BY 
        i.ItemTitle
) AS ItemData";
            label2.Text = new db().ExecuteScalar<string>(sql);
            if (report != null)
            {
                report.Dispose();
            }
            report = new rptMarkaSummary(marka,partyID, d01.Value.Date, d02.Value.Date, data, label2.Text.Trim());
            report.CreateDocument();
        }

        private void ـToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void uiButton2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var rows = gridEX1.GetCheckedRows();
            if (rows.Length > 0)
            {
                var FinalReport = new XtraReport();
                foreach (var row in rows)
                {
                    var rpt = new saleBill(gridEX1.GetValue("ArrivalNo").ToString(), 1);
                    rpt.CreateDocument();
                    if (FinalReport == null)
                    {
                        FinalReport = rpt;
                    }
                    else
                    {
                        FinalReport.Pages.AddRange(rpt.Pages);
                    }
                }
                if (FinalReport != null)
                {
                    FinalReport.ShowPreview();
                }
            }
            else
            {
                this.Error("No Records Selected.");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (report != null)
            {
                report.ShowPreview();
            }
        }

        private void gridEX1_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            if (e.Row.RowType == RowType.TotalRow)
            {
                decimal totalDebit = 0;
                decimal totalCredit = 0;

                if (decimal.TryParse(Convert.ToString(e.Row.Cells["Debit"]?.Value), out decimal debit))
                    totalDebit = debit;

                if (decimal.TryParse(Convert.ToString(e.Row.Cells["Credit"]?.Value), out decimal credit))
                    totalCredit = credit;

                decimal difference = totalDebit - totalCredit;

                e.Row.Cells["EndBalance"].Text = Math.Abs(difference).ToString("0.##");

                if (difference < 0)
                {
                    e.Row.Cells["State"].Text = "جمع";
                }
                else
                {
                    e.Row.Cells["State"].Text = "بنام";
                }
            }
        }
    }
}
