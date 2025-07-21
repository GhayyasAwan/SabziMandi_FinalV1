using MandiPOS.CLasses;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class frmSale : Form
    {
        tblSale _sale = new tblSale();
        private int _currentID;
        clsResize resizer;
        public int CurrentID
        {
            get => _currentID;
            set
            {
                if (_currentID == value) return;
                _currentID = value;
                OnIDChanged();
            }
        }

        private void OnIDChanged()
        {
            LoadRecord(CurrentID);
        }

        public frmSale()
        {
            InitializeComponent();
            this.resizer = new clsResize(this);
            this.KeyPreview = true;
            this.KeyDown += FrmSale_KeyDown;
            this.Load += FrmSale_Load;
            this.Resize += FrmSale_Resize;
            cmbCustomers.Enter += CmbCustomers_Enter;
            txtParty.Enter += SwitchtoUrdu;
            txtParty.KeyDown += txtParty_KeyDown;
            txtQty.KeyDown += TxtQty_KeyDown;
            txtQty.KeyPress += TxtQty_KeyPress;
            txtParty.KeyDown += TxtParty_KeyDown;
            // Fix for the errors related to the assignment of KeyPress event handlers
            // The issue is caused by chaining assignments and incorrect usage of the NumericOnly method.
            txtSale1.TextChanged += TxtSale1_TextChanged;
            txtLaga.KeyPress += NumericOnly;
            txtItemQty.KeyPress += NumericOnly;
            txtRate1.KeyPress += NumericOnly;
            txtRate2.KeyPress += NumericOnly;
            txtmarka.KeyDown += txtmarkaKeyDown;
            bsCart.DataSourceChanged += BsCart_DataSourceChanged;
            txtParty.EditValueChanged += (s, e) =>
            {

                if (CurrentID == 0)
                {
                    var party = DetailAccountService.GetDetailAccountByID(txtParty.EditValue.toInt());
                    if (party != null)
                    {
                        commissionPerc.Text = party.Commission.toDecimal().ToString("0.##");
                    }
                }
            };

            txtComissionAmount.TextChanged += TxtComissionAmount_TextChanged;
            txtMazdooriAmount.TextChanged += TxtMazdooriAmount_TextChanged;
            txtMunshianaAmount.TextChanged += TxtMunshianaAmount_TextChanged;
            txtKaraya.TextChanged += TxtKaraya_TextChanged;
            txtCashPaid.TextChanged += TxtCashPaid_TextChanged;
            txtStoreRent.TextChanged += TxtStoreRent_TextChanged;
            commissionPerc.KeyDown += CommissionPerc_KeyDown;
            mazdooriPerc.KeyDown += MazdooriPerc_KeyDown;
            mushianaPerc.KeyDown += MunshianaPerc_KeyDown;
            txtKaraya.KeyDown += TxtKaraya_KeyDown;

        }

        private void FrmSale_Resize(object sender, EventArgs e)
        {
            this.resizer._resize();
        }

        private void CmbCustomers_Enter(object sender, EventArgs e)
        {
            cmbCustomers.SelectAll();
        }

        private void TxtKaraya_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCashPaid.Select();
            }
        }

        private void MunshianaPerc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtKaraya.Select();
            }
        }

        private void MazdooriPerc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMunshianaAmount.Select();
            }
        }

        private void CommissionPerc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtComissionAmount.Select();
            }
        }

        private void TxtStoreRent_TextChanged(object sender, EventArgs e)
        {
            CalcuateGrandTotals();
        }

        private void TxtCashPaid_TextChanged(object sender, EventArgs e)
        {
            CalcuateGrandTotals();
        }

        private void TxtKaraya_TextChanged(object sender, EventArgs e)
        {
            CalcuateGrandTotals();
        }

        private void TxtSale1_TextChanged(object sender, EventArgs e)
        {
            txtGrossSale.Text = txtSale1.Text.toDecimal().ToString("0.##");
        }

        void CalcuateGrandTotals()
        {
            decimal commission = txtComissionAmount.Text.toDecimal();
            decimal mazdoori = txtMazdooriAmount.Text.toDecimal();
            decimal munshiana = txtMunshianaAmount.Text.toDecimal();
            decimal karaya = txtKaraya.Text.toDecimal();
            decimal storeRent = txtStoreRent.Text.toDecimal();
            decimal paid = txtCashPaid.Text.toDecimal();


            txtTotalExpenses.Text = (commission + mazdoori + munshiana + karaya + storeRent).ToString("0.##");
            txtPaid.Text = paid.ToString("0.##");
            txtNetSale.Text = (txtSale1.Text.toDecimal() - txtTotalExpenses.Text.toDecimal()).ToString("0.##");
        }
        private void TxtMunshianaAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtMunshianaAmount.Focused)
            {
                if (txtSale1.Text.toDecimal() > 0 && txtMunshianaAmount.Text.toDecimal() > 0)
                {
                    mushianaPerc.Text = (txtMunshianaAmount.Text.toDecimal() * 100 / txtSale1.Text.toDecimal()).ToString("0.##");
                }
                else
                {
                    mushianaPerc.Text = 0.ToString();
                }
            }
            CalcuateGrandTotals();
        }

        private void TxtMazdooriAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtMazdooriAmount.Focused)
            {
                if (txtSale1.Text.toDecimal() > 0 && txtMazdooriAmount.Text.toDecimal() > 0)
                {
                    mazdooriPerc.Text = (txtMazdooriAmount.Text.toDecimal() * 100 / txtSale1.Text.toDecimal()).ToString("0.##");
                }
                else
                {
                    mazdooriPerc.Text = 0.ToString();
                }
            }
            CalcuateGrandTotals();
        }

        private void TxtComissionAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtComissionAmount.Focused)
            {
                if (txtSale1.Text.toDecimal() > 0 && txtComissionAmount.Text.toDecimal() > 0)
                {
                    commissionPerc.Text = (txtComissionAmount.Text.toDecimal() * 100 / txtSale1.Text.toDecimal()).ToString("0.##");
                }
                else
                {
                    commissionPerc.Text = 0.ToString();
                }
            }
            CalcuateGrandTotals();
        }

        private void BsCart_DataSourceChanged(object sender, EventArgs e)
        {

        }

        private void FrmSale_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1)
            {
                if (SaveRecord(false))
                {
                    this.Info("ریکارڈ کامیابی سے محفوظ ہو گیا۔");
                }
            }
        }

        private void txtmarkaKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbItems.EditValue == null) { this.Error("براہ کرم اشیاء منتخب کریں۔"); return; }
                if (cmbCustomers.EditValue == null) { this.Error("براہ کرم گاہک منتخب کریں۔"); return; }
                if (txtItemUnit.SelectedIndex == -1) { this.Error("براہ کرم یونٹ منتخب کریں۔"); return; }
                if (txtRate1.Text.toDecimal() <= 0 && txtRate2.Text.toDecimal() <= 0)
                {
                    this.Error("براہ کرم قیمت درج کریں۔");
                    return;
                }
                AddToCart();

            }
        }

        private void AddToCart()
        {
            vwSale3 c = new vwSale3()
            {
                CustomerAmount = txtAmount1.Text.toDecimal(),
                CustomerRate = txtRate1.Text.toDecimal(),
                ItemID = cmbItems.EditValue.toInt(),
                ItemQty = txtItemQty.Text.toDecimal(),
                ItemTitle = cmbItems.Text,
                ItemUnit = txtItemUnit.SelectedIndex,
                LagaRate = txtLaga.Text.toDecimal(),
                PartyID = cmbCustomers.EditValue.toInt(),
                PartyTitle = cmbCustomers.Text,
                SaleID = CurrentID,
                ItemWeight = txtWt.Text.toDecimal(),
                ParyRate = txtRate2.Text.toDecimal(),
                PartyAmount = txtAmount2.Text.toDecimal(),
                Marka = txtmarka.Text
            };
            bsCart.Add(c);
            bsCart.ResetBindings(false);
            ClearEntryPanel();
            GetTotals();
            if (cmbItems.Enabled)
            {
                cmbItems.Select();
            }
            else
            {
                txtComissionAmount.Select();
            }
        }

        private void SetEntryPanel(bool v)
        {
            cmbItems.Enabled = cmbCustomers.Enabled = txtWt.Enabled = txtmarka.Enabled = !v;
            txtLaga.Enabled = txtItemQty.Enabled = txtItemUnit.Enabled = txtRate1.Enabled = txtRate2.Enabled = txtAmount1.Enabled = txtAmount2.Enabled = txtLaga.Enabled = !v;
        }

        private void ClearEntryPanel()
        {
            // cmbItems.EditValue = null;
            // cmbCustomers.EditValue = null;
            txtLaga.Clear();
            txtItemQty.Clear();
            txtItemUnit.Clear();
            txtRate1.Clear();
            txtRate2.Clear();
            txtAmount1.Clear();
            txtAmount2.Clear();
            txtWt.Clear();
            txtItemUnit.SelectedIndex = 0;
        }

        // Ensure the NumericOnly method matches the KeyPressEventHandler delegate signature
        private static void NumericOnly(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxtParty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQty.Select();
            }
        }

        private void TxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumericOnly(e);
        }

        private static void NumericOnly(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (CurrentID == 0 && txtParty.EditValue != null && txtQty.Text.toDecimal() != 0)
                {
                    SaveRecord();
                }
                cmbItems.Select();

            }
        }

        private bool SaveRecord(bool refreshAfterSave = false)
        {
            MakeObject();
            if (SaleService.SaveSale(_sale, _saleDetails))
            {
                CurrentID = _sale.ID;
                if (refreshAfterSave)
                {
                    refreshSale1();
                }
                return true;
            }
            return false;
        }

        List<tblSaleDetail> _saleDetails = new List<tblSaleDetail>();
        private void MakeObject()
        {
            _sale = new tblSale
            {
                ArrivalDate = ArrivalDate.Value.Date,
                ArrivalNo = ArrivalNo.Text.toInt(),
                PartyID = txtParty.EditValue.toInt(),
                CreatedOn = DateTime.Now,
                CreatedBy = 1,
                CreationDevice = Environment.MachineName,
                KarayaAmount = txtKaraya.Text.toDecimal(),
                MazdooriAmount = txtMazdooriAmount.Text.toDecimal(),
                MunshianaAmount = txtMunshianaAmount.Text.toDecimal(),
                PaidAmount = txtCashPaid.Text.toDecimal(),
                SaleAmount1 = txtSale1.Text.toDecimal(),
                SaleAmount2 = txtSale2.Text.toDecimal(),
                SoldQty = txtTotalQty.Text.toDecimal(),
                StoreRent = txtStoreRent.Text.toDecimal(),
                TotalQty = txtQty.Text.toDecimal(),
                ID = CurrentID,
                VehicleNo = txtVehicle.Text.Trim(),
                CommisionPerc = commissionPerc.Text.toDecimal(),
                MazdooriPerc = mazdooriPerc.Text.toDecimal(),
                MunshianaPerc = mushianaPerc.Text.toDecimal(),
                PartyTitle = txtTitle.Text.Trim()
            };
            _saleDetails.Clear();
            foreach (vwSale3 item in bsCart)
            {
                tblSaleDetail saleDetail = new tblSaleDetail
                {
                    SaleID = _sale.ID,
                    ItemID = item.ItemID,
                    PartyID = item.PartyID,
                    ItemQty = item.ItemQty,
                    ItemUnit = item.ItemUnit,
                    LagaRate = item.LagaRate,
                    LagaAmount = item.LagaAmount,
                    CustomerRate = item.CustomerRate,
                    CustomerAmount = item.CustomerAmount,
                    ParyRate = item.ParyRate,
                    PartyAmount = item.PartyAmount,
                    ItemWeight = item.ItemWeight,
                    Marka = item.Marka
                };
                _saleDetails.Add(saleDetail);
            }
        }

        private void refreshSale1()
        {
            vwSale1BindingSource.DataSource = SaleService.GetviewSale1(dt1.Value.Date, dt2.Value.Date, txtPartyTitle.Text.Trim());
            dgv1.AutoSizeColumns();
        }

        private void txtParty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQty.Select();
            }
        }

        private void SwitchtoUrdu(object sender, EventArgs e)
        {
            Program.UrduInput(true);
        }
        DataTable dtVendors = new DataTable();
        public override void Refresh()
        {
            CurrentID = 0;
            refreshSale1();
            loadItems();
            LoadCustomers();
            ArrivalDate.Value = DateTime.Now;
            ArrivalNo.Text = SQL.GetNextArrivalNo();
            dtVendors = DetailAccountService.VendorAccounts().ToDataTable();
            bsVendors.DataSource = dtVendors;
            PrepareAutoComplete();
            bsVendors.ResetBindings(false);
            txtParty.EditValue = null;
            txtParty.Select();
            txtItemUnit.SelectedIndex = 0;
        }

        private void PrepareAutoComplete()
        {
            var autoCompleteSource = new AutoCompleteStringCollection();
            var list = bsVendors.List.Cast<DetailAccountView>().Select(x => x.AccountTitle).ToArray();
            autoCompleteSource.AddRange(list);
            txtPartyTitle.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtPartyTitle.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPartyTitle.AutoCompleteCustomSource = autoCompleteSource;
        }

        private void LoadCustomers()
        {
            bsCustomers.DataSource = DetailAccountService.CustomerAccounts();
        }

        private void loadItems()
        {
            string itemtypes = "";
            itemtypes = "N'فروٹ',N'سبزی'"; // Fruits and Vegetables
            tblItemsBindingSource.DataSource = ItemService.GetItems(itemtypes);
        }

        private void FrmSale_Load(object sender, EventArgs e)
        {
            this.resizer._get_initial_size();
            Refresh();
        }

        public void ResetControls()
        {
            txtParty.EditValue = null;
            txtPartyBal.Clear();
            txtRef.Clear();
            txtQty.Clear();
        }

        private void dgv1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dgv1_Click(object sender, EventArgs e)
        {
            if (dgv1.CurrentRow.RowIndex != -1 && dgv1.CurrentRow.RowType == Janus.Windows.GridEX.RowType.Record)
            {
                LoadRecord((dgv1.CurrentRow.DataRow as vwSale1).ID);
            }
        }


        private void LoadRecord(int iD)
        {
            CurrentID = iD;
            object cart = new object();
            object summry = new object();
            _sale = SaleService.GetSaleByID(iD, ref cart, ref summry);
            bsCart.DataSource = cart;
            bsCart.ResetBindings(false);
            GetTotals();
            objectToControls();
        }

        private void GetTotals()
        {
            txtTotalRecords.Text = bsCart.Count.ToString("N0");
            bsSummry.Clear();
            decimal __totalLaga = 0;
            decimal _sale1 = 0;
            decimal _sale2 = 0;
            decimal tobesold = _sale.TotalQty;
            decimal sold = 0;
            decimal rem = 0;
            foreach (vwSale3 item in bsCart)
            {
                sold += item.ItemQty;
                __totalLaga += item.LagaAmount;
                _sale1 += item.CustomerAmount;
                _sale2 += item.PartyAmount;
                rem = tobesold - sold;
                vwSale2 s = new vwSale2()
                {
                    ID = _sale.ID,
                    ItemQty = item.ItemQty,
                    ItemTitle = item.ItemTitle
                };
                bsSummry.Add(s);
            }
            txtTotalQty.Text = sold.ToString("0.##");
            txtTotalLaga.Text = __totalLaga.ToString("0.##");
            txtSale1.Text = _sale1.ToString("0.##");
            txtSale2.Text = _sale2.ToString("0.##");
            bsSummry.ResetBindings(false);
            TotalQty.Text = _sale.TotalQty.ToString("0.##");
            TotalSold.Text = sold.ToString("0.##");
            TolalRemaining.Text = rem.ToString("0.##");
            SetEntryPanel(tobesold - sold == 0);
        }

        private void objectToControls()
        {
            txtParty.EditValue = _sale.PartyID;
            txtTitle.Text = _sale.PartyTitle;
            txtQty.Text = _sale.TotalQty.ToString("0.##");
            txtKaraya.Text = _sale.KarayaAmount.ToString("0.##");
            txtMazdooriAmount.Text = _sale.MazdooriAmount.ToString("0.##");
            txtMunshianaAmount.Text = _sale.MunshianaAmount.ToString("0.##");
            txtStoreRent.Text = _sale.StoreRent.ToString("0.##");
            txtCashPaid.Text = _sale.PaidAmount.ToString("0.##");
            ArrivalDate.Value = _sale.ArrivalDate;
            ArrivalNo.Text = _sale.ArrivalNo.ToString();
            txtVehicle.Text = _sale.VehicleNo;
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            dt1.Value = dt2.Value = DateTime.Now.Date;
            Refresh();
        }

        private void cmbItems_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbItems.EditValue != null)
            {
                tblItems item = tblItemsBindingSource[cmbItems.ItemIndex] as tblItems;
                if (item != null)
                {
                    txtLaga.Text = item.ChwanniRate.ToString("0.##");
                    cmbCustomers.Select();
                }
                else
                {
                    txtLaga.Text = 0.ToString("0.##");
                }
            }
            else
            {
                txtLaga.Text = 0.ToString("0.##");
            }
        }

        private void txtItemUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtItemUnit.SelectedIndex == 0)
                {
                    txtRate1.Select();
                }
                else
                {
                    txtWt.Select();
                }
            }
        }

        private void txtRate1_TextChanged(object sender, EventArgs e)
        {
            if (txtItemUnit.SelectedIndex == 0 && txtRate1.Text.toDecimal() > 0 && txtItemQty.Text.toDecimal() > 0)
            {
                txtAmount1.Text = (txtRate1.Text.toDecimal() * txtItemQty.Text.toDecimal()).ToString("0.##");
            }
            else if (txtItemUnit.SelectedIndex == 1 && txtRate1.Text.toDecimal() > 0 && txtItemQty.Text.toDecimal() > 0)
            {
                txtAmount1.Text = (txtRate1.Text.toDecimal() * txtWt.Text.toDecimal()).ToString("0.##");
            }
            if (txtRate1.Focused)
            {
                txtRate2.Text = txtRate1.Text; // Copy rate1 to rate2 if focused on rate1
            }
        }

        private void txtRate2_TextChanged(object sender, EventArgs e)
        {
            if (txtItemUnit.SelectedIndex == 0 && txtRate2.Text.toDecimal() > 0 && txtItemQty.Text.toDecimal() > 0)
            {
                txtAmount2.Text = (txtRate2.Text.toDecimal() * txtItemQty.Text.toDecimal()).ToString("0.##");
            }
            else if (txtItemUnit.SelectedIndex == 1 && txtRate2.Text.toDecimal() > 0 && txtWt.Text.toDecimal() > 0)
            {
                txtAmount2.Text = (txtRate2.Text.toDecimal() * txtWt.Text.toDecimal()).ToString("0.##");
            }
        }

        private void txtLaga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtItemQty.Select();
            }
        }

        private void txtItemQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtItemUnit.Select();
            }
        }


        private void txtSale1_TextChanged(object sender, EventArgs e)
        {
            if (txtSale1.Text.toDecimal() > 0)
            {
                if (commissionPerc.Text.toDecimal() > 0)
                {
                    txtComissionAmount.Text = (txtSale1.Text.toDecimal() * commissionPerc.Text.toDecimal() / 100).ToString("0.##");
                }
                if (mazdooriPerc.Text.toDecimal() > 0)
                {
                    txtMazdooriAmount.Text = (txtSale1.Text.toDecimal() * mazdooriPerc.Text.toDecimal() / 100).ToString("0.##");
                }
                if (txtMunshianaAmount.Text.toDecimal() > 0)
                {
                    txtMunshianaAmount.Text = (txtSale1.Text.toDecimal() * mushianaPerc.Text.toDecimal() / 100).ToString("0.##");
                }
            }

        }

        private void txtStoreRent_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCashPaid_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtKaraya_TextChanged(object sender, EventArgs e)
        {

        }

        private void gridEX3_DoubleClick(object sender, EventArgs e)
        {
            if (dgv.CurrentRow.RowIndex != -1 && dgv.CurrentRow.RowType == Janus.Windows.GridEX.RowType.Record)
            {
                vwSale3 item = dgv.CurrentRow.DataRow as vwSale3;
                if (item != null)
                {
                    cmbItems.EditValue = item.ItemID;
                    cmbCustomers.EditValue = item.PartyID;
                    txtLaga.Text = item.LagaRate.ToString("0.##");
                    txtItemQty.Text = item.ItemQty.ToString("0.##");
                    txtItemUnit.SelectedIndex = item.ItemUnit;
                    txtRate1.Text = item.CustomerRate.ToString("0.##");
                    txtRate2.Text = item.ParyRate.ToString("0.##");
                    txtWt.Text = item.ItemWeight.ToString("0.##");
                    txtmarka.Text = item.Marka;
                }
                bsCart.Remove(item);
                bsCart.ResetBindings(false);
                GetTotals();
                cmbItems.Select();
            }
        }

        private void txtRate1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRate2.Select();
            }
        }

        private void txtRate2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtmarka.Select();
            }
        }

        private void txtComissionAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMazdooriAmount.Select();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void txtWt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRate1.Select();
            }
        }

        private void txtParty_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
