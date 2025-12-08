using Dapper;

using DevExpress.XtraReports.UI;

using Janus.Windows.GridEX;

using MandiPOS.CLasses;
using MandiPOS.Reports;

using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class frmSubPartiesSale : Form
    {
        int partyID = 0;
        DateTime date1 = DateTime.Now;
        DateTime date2 = DateTime.Now;
        DataTable data = new DataTable();
        public frmSubPartiesSale(int PartyID, DateTime d1, DateTime d2)
        {
            InitializeComponent();
            dgv.RowDoubleClick += Dgv_RowDoubleClick;
            date1 = d1.Date;
            date2 = d2.Date;
            partyID = PartyID;
            lbld1.Text = $"{d1.Date:dd-MMM-yyyy}";
            lbld2.Text = $"{d2.Date:dd-MMM-yyyy}";
            DetailAccounts acc = DetailAccountService.GetDetailAccountByID(PartyID);
            lblParty.Text = acc.AccountTitle;
            data = new db().Query<vw_SubpartiesSale>($@"
;WITH MarkaSummary AS
(
    SELECT
        Marka,
        SUM(CASE WHEN Remaining > 0 THEN Remaining ELSE 0 END) AS Credit,
        SUM(CASE WHEN Remaining <= 0 THEN ABS(Remaining) ELSE 0 END) AS Debit,
        SUM(CASE WHEN Remaining <= 0 THEN ABS(Remaining) ELSE 0 END) 
          - SUM(CASE WHEN Remaining > 0 THEN ABS(Remaining) ELSE 0 END) AS EndBalance
    FROM vw_SubpartiesSale
    WHERE PartyID = {PartyID} and (ArrivalDate between '{d1:yyyy-MM-dd}' and '{d2:yyyy-MM-dd}')
    GROUP BY Marka
),
Ordered AS
(
    SELECT 
        ROW_NUMBER() OVER (ORDER BY Marka) AS RowNo,
        Marka,
        Credit,
        Debit,
        EndBalance AS hiddenCol
    FROM MarkaSummary 
)
SELECT
    RowNo,
    Marka,
    Credit,
    Debit,
    hiddenCol as EndBalance
FROM Ordered
ORDER BY RowNo;
").ToDataTable();

            vwSubpartiesSaleBindingSource.DataSource = data;
        }

        private void Dgv_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            if (dgv.IsRow())
            {
                var subForm = new frmMarkaDetails(partyID, date1, date2, dgv.CurrentRow.Cells["Marka"].Value.ToString());
                subForm.Show();
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            var rows = dgv.GetCheckedRows();
            if (rows.Length > 0)
            {
                var FinalReport = new XtraReport();
                foreach (var row in rows)
                {
                    string sql = $@"Select * from vw_SubpartiesSale Where PartyID='{partyID}' and Marka Like N'{row.Cells["Marka"].Value.ToString()}' and (ArrivalDate between '{date1:yyyy-MM-dd}' and '{date2:yyyy-MM-dd}')";
                    var records = new db().Query<vw_SubpartiesSale>(sql).ToList();

                    foreach (var record in records)
                    {
                        var rpt = new saleBill(record.ArrivalNo.ToString(), 1);
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

        private void dgv_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
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

                //if (difference < 0)
                //{
                //    e.Row.Cells["State"].Text = "جمع";
                //}
                //else
                //{
                //    e.Row.Cells["State"].Text = "بنام";
                //}
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            var report = new MarkaReportDetail(data, partyID);
            report.CreateDocument();
            if (report != null)
            {
                var fr = new XtraForm1(report);
                fr.Show();
                fr.WindowState = FormWindowState.Maximized;
                fr.BringToFront();
            }
        }
    }
}
