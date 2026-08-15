

using Dapper;
using MandiPOS.CLasses;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class frmAgreementInfo : Form
    {
        private tblAgreements agreement;
        int CurrentID = 0;
        public frmAgreementInfo(tblAgreements _agreement)
        {
            InitializeComponent();
            dgv.RowDoubleClick += Dgv_RowDoubleClick;
            cmbItems.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { txtArea.Select(); } };
            txtArea.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { uiButton1.Select(); } };
            dtp1.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { dtp2.Select(); } };
            dtp2.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { txtRemarks.Select(); } };
            agreement = _agreement;
            using (var db = new db())
            {
                tblItemsBindingSource.DataSource = db.GetList<tblItems>();
                tblItemsBindingSource.ResetBindings(false);
                list = db.Query<tblAgreementDetails>($"Select * from tblAgreementDetails Where AgreementID={agreement.AgreementID};").ToList();
            }
            BindObject();
        }

        private void Dgv_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            if (dgv.IsRow())
            {
                tblAgreementDetails d = bs.Current as tblAgreementDetails;
                if (d != null)
                {
                    cmbItems.SelectedValue = d.ItemID;
                    txtArea.Text = d.Area;
                    bs.RemoveCurrent();
                    cmbItems.Select();
                }
            }


        }
        List<tblAgreementDetails> list = new List<tblAgreementDetails>();
        private void BindObject()
        {
            CurrentID = agreement.AgreementID;
            txtPartyID.Text = agreement.PartyID.ToString();
            txtPartyName.Text = agreement.PartyName;
            dtp1.Value = agreement.AgreementStartDate.Date;
            dtp2.BindableValue = agreement.AgreementEndDate;
            txtRemarks.Text = agreement.Remarks;
            bs.DataSource = list;
            bs.ResetBindings(false);
        }

        private void editBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (cmbItems.SelectedIndex == -1)
            {
                this.Error("نام اشیاء منتخب کریں۔");
                return;
            }
            if (string.IsNullOrEmpty(txtArea.Text.Trim()))
            {
                this.Error("برائے مہرابنی رقبہ متخب کریں۔");
                return;
            }
            tblAgreementDetails d = new tblAgreementDetails()
            {
                ItemID = cmbItems.SelectedValue.toInt(),
                Area = txtArea.Text.Trim()
            };
            if (list.Any(x => x.ItemID == d.ItemID))
            {
                this.Error("اندراج پہلے سے موجود ہے۔");
                return;
            }
            else
            {
                list.Add(d);
                bs.DataSource = null;
                bs.DataSource = list;
                bs.ResetBindings(false);
                cmbItems.SelectedIndex = -1;
                txtArea.Clear();
                cmbItems.Select();
            }

        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            var agr = new tblAgreements();
            agr.PartyID = agreement.PartyID;
            agr.AgreementID = agreement.AgreementID;
            agr.AgreementEndDate = null;
            object ooo = dtp2.BindableValue;
            if (ooo != null && ooo.ToString().Trim() != string.Empty&& ooo.ToString().Trim() != "")
            {
                agr.AgreementEndDate = dtp2.Value.Date;
            }

            agr.AgreementStartDate = dtp1.Value.Date;
            agr.Remarks = txtRemarks.Text.Trim();
            try
            {
                using (var db = new db())
                {
                    using (var trx = db.BeginTransaction())
                    {
                        try
                        {
                            int recordid = db.ExecuteScalar<int>("usp_SaveAgreement", new { AgreementID = agr.AgreementID, PartyID = agr.PartyID, AgreementStartDate = agr.AgreementStartDate, AgreementEndDate = agr.AgreementEndDate, Remarks = agr.Remarks }, trx, commandType: System.Data.CommandType.StoredProcedure);
                            db.Execute($"Delete From tblAgreementDetails Where AgreementID={recordid}", transaction: trx);
                            foreach (tblAgreementDetails d in list)
                            {
                                d.AgreementID = recordid;
                                db.Insert<tblAgreementDetails>(d, transaction: trx);
                            }
                            trx.Commit();
                            this.DialogResult = DialogResult.OK;
                        }
                        catch (Exception ex)
                        {
                            trx.Rollback();
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ExcError();
            }
        }
    }
}
