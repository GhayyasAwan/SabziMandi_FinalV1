using Dapper;
using DevExpress.XtraReports.UI;
using MandiPOS.CLasses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MandiPOS.Reports
{
    public partial class rptAgreementStatistics : DevExpress.XtraReports.UI.XtraReport
    {
        tblAgreements agreement;
        DetailAccounts acc;
        List<tblAgreementDetails> details;
        string items;
        public rptAgreementStatistics(int AgreementID)
        {
            InitializeComponent();
            using (var db = new db())
            {
                agreement = db.Get<tblAgreements>(AgreementID)??new tblAgreements();
                details = db.Query<tblAgreementDetails>($"select * from tblAgreementDetails Where AgreementID={agreement.AgreementID};").ToList();
                acc=db.Get<DetailAccounts>(agreement.PartyID)??new DetailAccounts();
                StringBuilder sb = new StringBuilder();
                foreach (tblAgreementDetails d in details)
                { 
                    tblItems item=db.Get<tblItems>(d.ItemID)??new tblItems();
                    if (sb.ToString().Length > 0)
                        sb.Append(";");
                    sb.Append($"{item.ItemTitle}={d.Area}");
                }
                items = sb.ToString();
            }
            lblDate1.Text = agreement.AgreementStartDate.ToString("dd-MM-yyyy");
            lblDate2.Text = agreement.AgreementEndDate?.ToString("dd-MM-yyyy")??"";
            lblDate2.Visible=lblDate2Title.Visible=!string.IsNullOrEmpty(lblDate2.Text.Trim());
            lblPartyTitle.Text = acc.AccountTitle;
            lblDetails.Text = agreement.Remarks;
            bndRemarks.Visible = !string.IsNullOrEmpty(agreement.Remarks);
            lblItemdetails.Text = items;
            bndItems.Visible = !string.IsNullOrEmpty(items.Trim());
            this.DataSource = usp_ItemRecordViaAgreementID.GetData(AgreementID);
            lblPrintTime.Text = $"Print Time: {DateTime.Now:dd-MM-yyyy hh:mm tt}";
        }

    }
}
