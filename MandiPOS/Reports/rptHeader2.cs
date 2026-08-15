using DevExpress.XtraReports.UI;

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace MandiPOS.Reports
{
    public partial class rptHeader2 : DevExpress.XtraReports.UI.XtraReport
    {
        public rptHeader2(int PartyID)
        {
            InitializeComponent();
            CLasses.DetailAccounts account = SQL.GetDetailsAccountByID(PartyID);
            var city=SQL.GetCities().Where(x=>x.ID==account.CityID).FirstOrDefault()??new CLasses.tblCity();
            //cellCity.Text=city.CityName;
           
            this.bindingSource1.DataSource = account;
            if (account.RefName == null)
            { 
                account.RefName=string.Empty;
            }
            //int len= account.RefName.TrimEnd().TrimStart().Trim().Replace(" ",string.Empty).Length;
            //if (len<=1)
            //{
            //    SubBand1.Visible = false;
            //}
            //else
            //{
            //    SubBand1.Visible =true;
            //}
                
        }

    }
}
