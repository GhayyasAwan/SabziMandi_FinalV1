using Dapper;

using DevExpress.Utils.Filtering.Internal;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using Janus.Windows.GridEX;
using Janus.Windows.GridEX.EditControls;

using MandiPOS;
using MandiPOS.CLasses;
using MandiPOS.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class frmSaleNew : Form
    {
        clsResize obj;
        
        tblSale _sale = new tblSale();
        private int _currentID;
        int _currentVendor = 0;
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
        int _currentCustomer = 0;

        public int CurrentCustomer
        {
            get => _currentCustomer;
            set
            {
                if (_currentCustomer == value) return;
                _currentCustomer = value;
                onCustomerChange();
            }
        }

        private void onCustomerChange()
        {
            if (CurrentCustomer != 0)
            {
                if(_customer.Text == "نقد سیل")
                    {
                    customerBal.Text = string.Empty;
                }
                    else
                {
                    customerBal.Text = this.GetPartyBalance(CurrentCustomer);
                }
            }
        }

        void CalculateGrandTotals()
        {
            decimal commission = _commission.Text.toDecimal();
            decimal mazdoori = _mazdoori.Text.toDecimal();
            decimal munshiana = _munshiana.Text.toDecimal();
            decimal kraya = _kraya.Text.toDecimal();
            decimal store = _store.Text.toDecimal();
            decimal paid = _paid.Text.toDecimal();
            decimal sale1 = 0;
            foreach (vwSale3 sale in bsCart)
            {
                sale1 += sale.CustomerAmount;
            }
            _grossSale.Text = sale1.ProperDecimals();
            _Expnses.Value = (commission + mazdoori + munshiana + kraya + store).ProperDecimals();
            _totalPaid.Value = paid.ProperDecimals();
            _netSale.Value = (sale1 - (commission + mazdoori + munshiana + kraya + store) - paid).ProperDecimals();
        }
        private void OnIDChanged()
        {
            LoadRecord(CurrentID);
        }
        private void LoadRecord(int iD)
        {
            CurrentID = iD;
            object Cart = new object(); object Summry = new object();
            _sale = SaleService.GetSaleByID(iD, ref Cart, ref Summry);
            CurrentID = _sale.ID;
            bsCart.DataSource = Cart;
            bsCart.ResetBindings(false);
            GetTotals();
            objectToControls();
        }
        public frmSaleNew()
        {
            InitializeComponent();
            commissionPerc.KeyDown += CommissionPerc_KeyDown;
            mazdooriPerc.KeyDown += MazdooriPerc_KeyDown;
            mushianaPerc.KeyDown += MushianaPerc_KeyDown;
            arrivalDate.Enabled=dtp.Enabled=dtp1.Enabled = General.IsAdmin;
            vendorBal.ValueChanged += VendorBal_ValueChanged;
            txtMarkaMain.RegisterFocus(true);
            txtMarkaMain.KeyDown += TxtMarkaMain_KeyDown;
            txtMarkaMain.TextChanged += TxtMarkaMain_TextChanged;
            dgvMarka.KeyDown += DgvMarka_KeyDown;
            dgvMarka.Leave += DgvMarka_Leave;
            txtMarkaMain.Leave += TxtMarkaMain_Leave;
            dtp.RegisterFocus(false);
            dtp1.RegisterFocus(false);
            partysearch.RegisterFocus(true);
            partysearch.KeyDown += Partysearch_KeyDown;
            dtp.KeyDown += Dtp_KeyDown;
            dtp1.KeyDown += Dtp1_KeyDown;
            _partyID.TextChanged += _partyID_TextChanged;
            _commission.KeyDown += _commission_KeyDown;
            _grossSale.TextChanged += _grossSale_TextChanged;
            _netSale.ValueChanged += _netSale_ValueChanged;
            partysearch.KeyDown += TxtPartyTitle_KeyDown;
            _partySearchHelper.KeyDown += SerachhelperParty;
            partysearch.TextChanged += TxtPartyTitle_TextChanged;
            dgv1.RowDoubleClick += Dgv1_RowDoubleClick;
            ArrivalNo.KeyDown += ArrivalNo_KeyDown;
            dgv.RowDoubleClick += Dgv_RowDoubleClick;
            _commission.TextChanged += CalculateInvoiceTotals;
            _mazdoori.TextChanged += CheckMazdoori;
            _munshiana.TextChanged += CalculateInvoiceTotals;
            _kraya.TextChanged += CalculateInvoiceTotals;
            _store.TextChanged += CalculateInvoiceTotals;
            _paid.TextChanged += CalculateInvoiceTotals;
            _ArrivalQty.KeyDown += _ArrivalQty_KeyDown;
            _partyHelper.KeyDown += _partyHelper_KeyDown;
            _vendor.KeyDown += _vendor_KeyDown;
            _vendor.TextChanged += _vendor_TextChanged;
            _vendor.RightToLeft = _customer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            _vendor.Enter += TxtParty_Enter;
            _customer.Enter += _customer_Enter;
            _item.Leave += ControlLeave;
            _customer.Leave += ControlLeave;
            _laga.Enter += _laga_Enter;
            _unit.Enter += _unit_Enter;
            _wt.Enter += _wt_Enter;
            _qty.Enter += _qty_Enter;
            _rate1.Enter += _rate1_Enter;
            _rate2.Enter += _rate2_Enter;
            _marka.Enter += _marka_Enter;
            _wt.Leave += ControlLeave;
            _laga.Leave += ControlLeave;
            _qty.Leave += ControlLeave;
            _unit.Leave += ControlLeave;
            _rate1.Leave += ControlLeave;
            _rate2.Leave += ControlLeave;
            _marka.Leave += ControlLeave;
            _item.Enter += _item_Enter;
            _item.SelectedIndexChanged += _item_SelectedIndexChanged;
            _item.KeyDown += _item_KeyDown;
            _rate1.KeyDown += _rate1_KeyDown;
            _rate2.KeyDown += _rate2_KeyDown;
            _wt.KeyDown += _wt_KeyDown;
            _unit.KeyDown += _unit_KeyDown;
            _laga.KeyDown += _laga_KeyDown;
            _qty.KeyDown += _qty_KeyDown;
            _customer.TextChanged += _customer_TextChanged;
            _CustomerHelper.KeyDown += _CustomerHelper_KeyDown;
            _customer.KeyDown += _customer_KeyDown;
            dgv1.Click += Dgv1_Click;
            _unit.SelectedIndexChanged += _unit_SelectedIndexChanged;
            _dateRemaining.TextChanged += _dateRemaining_TextChanged;
            _rate1.TextChanged += _rate1_TextChanged;
            _rate2.TextChanged += _rate2_TextChanged;
            btnRefresh.Click += BtnRefresh_Click;
            this.KeyPreview = true;
            this.KeyDown += FrmSaleNew_KeyDown;
            obj = new clsResize(this);
            this.Text = "بل فروخت";
            this.Load += FrmSaleNew_Load;
            this.Shown += FrmSaleNew_Shown;
            this.Resize += FrmSaleNew_Resize;
            this.ResizeEnd += FrmSaleNew_ResizeEnd;
            _marka.KeyDown += _marka_KeyDown;
            _mazdoori.KeyDown += _mazdoori_KeyDown;
            _munshiana.KeyDown += _munshiana_KeyDown;
            _kraya.KeyDown += _kraya_KeyDown;
            _paid.KeyDown += _paid_KeyDown;
            _ArrivalQty.Enter += _ArrivalQty_Enter;
            _vendor.Leave += _vendor_Leave;
            _ArrivalQty.Leave += _ArrivalQty_Leave;
        }

        private void CommissionPerc_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            _commission.Value = _grossSale.Value.toDecimal() * commissionPerc.Value.toDecimal() / 100;
        }

        private void MazdooriPerc_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
                _mazdoori.Value = _grossSale.Value.toDecimal() * mazdooriPerc.Value.toDecimal() / 100;
        }

        private void MushianaPerc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _munshiana.Value = _grossSale.Value.toDecimal() * (mushianaPerc.Value.toDecimal()/100);
            }
        }

        private void FrmSaleNew_Shown(object sender, EventArgs e)
        {
            Thread.Sleep(300);
            this.Opacity = 100;
        }

        private void FrmSaleNew_ResizeEnd(object sender, EventArgs e)
        {
            if (!isLoading)
            { 
                SetDGVLocations();  
            }
        }

        private void DgvMarka_Leave(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                if (!txtMarkaMain.Focused && !txtMarkaMain.ContainsFocus)
                {
                    dgvMarka.Visible = false;
                }
            }));
        }

        private void VendorBal_ValueChanged(object sender, EventArgs e)
        {
            if (vendorBal.Value.toDecimal() > 0)
            {
                vendorBal.BackColor = Color.LightCoral;
            }
            else if (vendorBal.Value.toDecimal() < 0)
            {

                vendorBal.BackColor = Color.LightGreen;
            }
            else
            {
                vendorBal.BackColor = Color.White;
            }
        }

        private void TxtMarkaMain_Leave(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                if (!dgvMarka.Focused && !dgvMarka.ContainsFocus)
                {
                    dgvMarka.Visible = false;
                }
            }));
        }

        private void DgvMarka_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.EscapeKey())
            {
                dgvMarka.Hide();
            }
            if (e.EnterKey() && dgvMarka.IsRow())
            {
                string marka = dgvMarka.CurrentRow.Cells[1].Value.ToString();
                if (!string.IsNullOrEmpty(marka))
                {
                    txtMarkaMain.Text = marka;
                    dgvMarka.Hide();
                    txtMarkaMain.Select();
                }
            }
        }

        private void TxtMarkaMain_TextChanged(object sender, EventArgs e)
        {
            if (txtMarkaMain.Text.Trim().Length > 0)
            {
                bsMarka.Filter = $"Marka Like '%{txtMarkaMain.Text.Trim()}%'";
                if (txtMarkaMain.Focused)
                {
                    dgvMarka.Show();
                }
            }
            else
            {
                dgvMarka.Hide();
            }

        }

        private void TxtMarkaMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dgvMarka.Hide();
            }
            if (e.DownKey())
            {
                txtMarkaMain.Select();
                dgvMarka.Show();
                dgvMarka.Select();
            }
            if (e.EnterKey())
            {
                _ArrivalQty.Focus();
                _ArrivalQty.Select();
            }
        }

        private void Partysearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.EnterKey())
            {
                btnSearch.Select();
            }
        }

        private void Dtp1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.EnterKey())
            {
                partysearch.Select();
            }
        }

        private void Dtp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.EnterKey())
            {
                dtp1.Select();
            }
        }

        DataTable dtmarka = new DataTable();
        private void _partyID_TextChanged(object sender, EventArgs e)
        {
            if (_partyID.Text.Length > 0)
            {
                _currentVendor = _partyID.Text.toInt();
                if (_currentVendor > 0)
                {
                    vendorBal.Text = this.GetPartyBalance(_currentVendor); ;
                    dtmarka = new db().Query<vwmarka>($"Select * from vwmarka Where PartyID='{_partyID.Text.Trim()}'").ToDataTable();
                    bsMarka.DataSource = dtmarka;
                    bsMarka.ResetBindings(false);
                    DetailAccounts acc = DetailAccountService.GetDetailAccountByID(_currentVendor);
                    if (acc != null)
                    {
                        _vendor.Text = acc.AccountTitle;
                        _txtref.Text = acc.RefName;
                        // partysearch.Text = acc.AccountTitle;
                        commissionPerc.Text = acc.Commission.ToString();
                    }
                }
            }
            else
            {
                _vendor.Clear();
                vendorBal.Clear();
                _txtref.Clear();
                partysearch.Clear();
                commissionPerc.Value = 0;
            }
        }

        private void _marka_Enter(object sender, EventArgs e)
        {
            ControlEnter(sender, e);
        }

        private void _rate2_Enter(object sender, EventArgs e)
        {
            ControlEnter(sender, e);
        }

        private void _rate1_Enter(object sender, EventArgs e)
        {
            ControlEnter(sender, e);
        }

        private void _qty_Enter(object sender, EventArgs e)
        {
            ControlEnter(sender, e);
        }

        private void _wt_Enter(object sender, EventArgs e)
        {
            ControlEnter(sender, e);
        }

        private void _unit_Enter(object sender, EventArgs e)
        {
            ControlEnter(sender, e);
        }

        private void _laga_Enter(object sender, EventArgs e)
        {
            ControlEnter(sender, e);
        }
        private void ControlEnter(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.Yellow;
        }
        private void ControlLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = SystemColors.Window;
        }

        private void _ArrivalQty_Leave(object sender, EventArgs e)
        {
            _ArrivalQty.BackColor = SystemColors.Window;
        }

        private void _vendor_Leave(object sender, EventArgs e)
        {
            _vendor.BackColor = SystemColors.Window;

        }

        private void _ArrivalQty_Enter(object sender, EventArgs e)
        {
            _ArrivalQty.BackColor = Color.LightYellow;
        }

        private void CheckMazdoori(object sender, EventArgs e)
        {
            if (_grossSale.Value.toDecimal() != 0)
            {
                decimal perc = (_mazdoori.Value.toDecimal() / _grossSale.Value.toDecimal()) * 100;
                mazdooriPerc.Value = perc.ProperDecimals();
                GetTotals();
                CalculateInvoiceTotals(sender, e);
            }
            else
            {
                mazdooriPerc.Value = 0;
            }


        }

        private void _paid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.EnterKey())
            {
                _store.Select();
            }
        }

        private void _kraya_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.EnterKey())
            {
                _paid.Select();
            }
        }

        private void _munshiana_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.EnterKey())
            {
                _kraya.Select();
            }
        }

        private void _mazdoori_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.EnterKey())
            {
                GetTotals();
                CalculateGrandTotals();
                _munshiana.Select();
            }
        }

        private void _commission_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.EnterKey())
            {
                _mazdoori.Select();
            }
        }

        private void _grossSale_TextChanged(object sender, EventArgs e)
        {
            _commission.Value = _grossSale.Value.toDecimal() * commissionPerc.Value.toDecimal() / 100;
            _mazdoori.Value = _grossSale.Value.toDecimal() * mazdooriPerc.Value.toDecimal() / 100;
            _munshiana.Value= _grossSale.Value.toDecimal()*(mushianaPerc.Value.toDecimal()/100);
        }

        private void Dgv1_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            if (dgv1.IsRow())
            {
                LoadRecordByID((dgv1.CurrentRow.DataRow as vwSale1).ID);
                CheckValues();
                dgv.AutoSizeColumns();
                if (_item.Enabled)
                {
                    _item.Select();
                }
                else
                {
                    _commission.Select();
                }
                
            }
        }

        private void CheckValues()
        {
            if (_grossSale.Value.toDecimal() != 0)
            {
                mushianaPerc.Value = (_munshiana.Value.toDecimal() / _grossSale.Value.toDecimal()) * 100;
                commissionPerc.Value = (_commission.Value.toDecimal() / _grossSale.Value.toDecimal()) * 100;
                mazdooriPerc.Value = (_mazdoori.Value.toDecimal() / _grossSale.Value.toDecimal()) * 100;
            }
        }

        private void _netSale_ValueChanged(object sender, EventArgs e)
        {
            if (_netSale.Value.toDecimal() <= 0)
            {
                _netSale.BackColor = Color.LightCoral;
            }
            else if (_netSale.Value.toDecimal() > 0)
            {
                _netSale.BackColor = Color.LightGreen;
            }
        }

        private void TxtPartyTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                _partySearchHelper.Select();
            }
            if (e.EscapeKey())
            {
                _partySearchHelper.Hide();
            }
        }

        private void _partySearchHelper_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void SerachhelperParty(object sender, KeyEventArgs e)
        {
            if (e.EnterKey() && _partySearchHelper.IsRow())
            {
                partysearch.Text = _partySearchHelper.CurrentRow.Cells["AccountTitle"].Value.ToString();
                _partySearchHelper.Hide();
            }
        }

        private void TxtPartyTitle_TextChanged(object sender, EventArgs e)
        {
            if (partysearch.Focused && partysearch.Text.Length > 0)
            {
                _partySearchHelper.Show();
                bindingSource1.Filter = $"AccountTitle Like '%{partysearch.Text.Trim()}%'";
                vwSale1BindingSource.ResetBindings(false);
            }
            else if (!partysearch.Focused)
            {
                _partySearchHelper.Hide();
            }
            else if (partysearch.Text.Length == 0)
            {
                _partySearchHelper.Hide();
                bindingSource1.RemoveFilter();
            }

        }

        private void Dgv_RowDoubleClick1(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {

        }

        private void ArrivalNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.EnterKey() && ArrivalNo.Value.toInt() != 0)
            {
                LoadRecordByArrivalNo(ArrivalNo.Value.toInt());
            }
        }

        private void LoadRecordByArrivalNo(int iD)
        {
            {
                CurrentID = iD;
                object cart = new object();
                object dtsummary = new object();
                _sale = SaleService.GetSaleByArrivalNo(iD, ref cart, ref dtsummary);
                if (_sale.ArrivalDate < DateTime.Now.Date && !General.IsAdmin)
                {
                    this.Info("آپکو پرانے ریکارڈ دیکھنے کی اجازت نہیں ہے۔");
                    return;
                }
                bsCart.DataSource = cart;
                CurrentID = _sale.ID;
                bsCart.ResetBindings(false);
                GetTotals();
                objectToControls();
                _vendor.Select();
            }
        }
        private void Dgv_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            if (dgv.IsRow())
            {
                vwSale3 record = bsCart[dgv.CurrentRow.RowIndex] as vwSale3;
                if (record != null)
                {
                    _item.SelectedValue = record.ItemID;
                    _customer.Text = record.PartyTitle;
                    CurrentCustomer = record.PartyID;
                    _unit.SelectedIndex = record.ItemUnit;
                    _laga.Value = record.LagaRate;
                    _qty.Value = record.ItemQty;
                    _wt.Value = record.ItemWeight;
                    _marka.Text = record.Marka;
                    _rate1.Value = record.CustomerRate;
                    _rate2.Value = record.ParyRate;
                    bsCart.RemoveAt(dgv.CurrentRow.RowIndex);
                    bsCart.ResetBindings(false);
                    GetTotals();
                    CalculateGrandTotals();
                    _item.Select();
                }
            }
        }

        private void CalculateInvoiceTotals(object sender, EventArgs e)
        {
            CalculateGrandTotals();
        }

        private void _item_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.EnterKey())
            {
                _item.Validate();
                var item = bsItems[_item.SelectedIndex] as tblItems;
                _laga.Value = item.ChwanniRate;
                _customer.Select();
            }
        }

        private void _ArrivalQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (_ArrivalQty.Text.Length > 0 && e.EnterKey())
            {
                if (CurrentID == 0)
                {
                    SaveRecord();
                    _item.Select();
                }
                else
                {
                    if (_item.Enabled)
                    {
                        _item.Select();
                        _laga.Enabled = true;
                    }
                    else
                    {
                        _commission.Select();
                        _commission.SelectAll();
                    }

                }
            }
        }
        private bool SaveRecord(bool refreshAfterSave = true)
        {
            MakeObject();
            if (_sale.PartyID == 0)
            {
                this.Error("بیوپاری منتخب کریں۔");
                _vendor.Select();
                return false;
            }
            if (_sale.TotalQty == 0)
            {
                this.Error("آمد نگ کی تعداد درج کریں۔");
                _ArrivalQty.Select();
                return false;
            }
            string validationError = null;
            if (!SQL.CheckDefaultAccounts(ref validationError))
            {
                this.Error(validationError);
                return false;
            }
            if (SaleService.SaveSale(_sale, _saleDetails))
            {
                CurrentID = _sale.ID;
                SearchRecords();
                return true;
            }
            return false;
        }
        List<tblSaleDetail> _saleDetails = new List<tblSaleDetail>();
        private void MakeObject()
        {
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
                    Marka = item.Marka,
                    MazdooriRate = item.MazdooriRate
                };
                _saleDetails.Add(saleDetail);
            }
            _sale = new tblSale
            {
                ArrivalDate = arrivalDate.Value.Date,
                ArrivalNo = ArrivalNo.Text.toInt(),
                PartyID = _partyID.Text.toInt(),
                CreatedOn = DateTime.Now,
                CreatedBy = 1,
                Marka = txtMarkaMain.Text,
                CreationDevice = Environment.MachineName,
                KarayaAmount = _kraya.Text.toDecimal(),
                MazdooriAmount = _mazdoori.Text.toDecimal(),
                MunshianaAmount = _munshiana.Text.toDecimal(),
                PaidAmount = _paid.Text.toDecimal(),
                SaleAmount1 = _saleDetails.Sum(x => x.CustomerAmount).toDecimal(),
                SaleAmount2 = _saleDetails.Sum(x => x.PartyAmount).toDecimal(),
                SoldQty = _saleDetails.Sum(x => x.ItemQty).toDecimal(),
                StoreRent = _store.Text.toDecimal(),
                TotalQty = _ArrivalQty.Text.toDecimal(),
                ID = CurrentID,
                VehicleNo = _vehNo.Text.Trim(),
                CommissionAmount = _commission.Value.toDecimal(),
                CommisionPerc = commissionPerc.Text.toDecimal(),
                MazdooriPerc = mazdooriPerc.Text.toDecimal(),
                MunshianaPerc = mushianaPerc.Text.toDecimal(),
                PartyTitle = txtTitle.Text.Trim(),
                VoucherID = voucherID
            };

        }
        private void _partyHelper_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.EscapeKey())
            {
                _partyHelper.Hide();
            }
            if (e.EnterKey() && _partyHelper.IsRow())
            {
                _vendor.Text = _partyHelper.CurrentRow.Cells["AccountTitle"].Value.ToString();
                _txtref.Text = _partyHelper.CurrentRow.Cells["RefName"].Value.ToString();
                if (CurrentID == 0)
                {
                    commissionPerc.Text = _partyHelper.CurrentRow.Cells["Commission"].Value.ToString();
                }
                _partyID.Text = _partyHelper.CurrentRow.Cells["ID"].Value.ToString();
                _currentVendor = _partyHelper.CurrentRow.Cells["ID"].Value.toInt();
                e.SuppressKeyPress = true;
                _partyHelper.Hide();
                dtp.Select();
                txtMarkaMain.Select();
                txtMarkaMain.SelectAll();
            }

        }

        private void _vendor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.DownKey())
            {
                if (_partyHelper.Visible)
                {
                    _partyHelper.Select();
                }
            }
            if (e.EscapeKey() && _partyHelper.Visible)
            {
                _partyHelper.Hide();
            }
            if (e.EnterKey() && _vendor.Text.Length > 0)

            {
                txtMarkaMain.Focus();
                txtMarkaMain.SelectAll();
            }
        }

        private void _vendor_TextChanged(object sender, EventArgs e)
        {
            if (_vendor.Focused)
            {
                if (_vendor.Text.Length > 0)
                {
                    _partyHelper.Show();
                    bsVendors.Filter = $"AccountTitle Like '%{_vendor.Text.Trim()}%'";
                    bsVendors.ResetBindings(false);
                    _vendor.Select();
                }
                else
                {
                    _txtref.Clear();
                    vendorBal.Clear();
                    _partyHelper.Hide();
                    _vendor.Select();
                }

            }
            _currentVendor = 0;

        }

        private void _item_Enter(object sender, EventArgs e)
        {
            this.SwitchToUrdu();
            _item.BackColor = Color.Yellow;
        }

        private void _customer_Enter(object sender, EventArgs e)
        {
            this.SwitchToUrdu();
            _customer.BackColor = Color.Yellow;
        }

        private void TxtParty_Enter(object sender, EventArgs e)
        {
            this.SwitchToUrdu();
            _vendor.BackColor = Color.Yellow;
        }

        private void _item_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_item.SelectedIndex != -1 && _item.SelectedValue != null)
            {
                var item = bsItems[_item.SelectedIndex] as tblItems;
                if (item != null)
                {
                    _laga.Value = item.ChwanniRate;
                }
            }
        }

        private void _rate2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.EnterKey())
            {
                _marka.Select();
            }
        }

        private void _rate1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.EnterKey())
            {
                if (_rate1.Text.toDecimal() == 0)
                {
                    this.Error("براہ کرم قیمت درج کریں۔");
                    return;
                }
                _rate2.Select();
                _rate2.SelectAll();
            }
        }

        private void _wt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.EnterKey())
            {
                if (_wt.Text.toDecimal() == 0)
                {
                    this.Error("براہ کرم وزن درج کریں۔");
                    return;
                }
                _rate1.Select();
                _rate1.SelectAll();
            }
        }

        private void _unit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.EnterKey())
            {
                if (_unit.SelectedIndex == 0)
                {
                    _rate1.Select();
                    _rate1.SelectAll();
                }
                else
                {
                    _wt.Select();
                    _wt.SelectAll();
                }

            }
        }

        private void _qty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.EnterKey())
            {
                if (_qty.Text.toDecimal() == 0)
                {
                    this.Error("براہ کرم مقدار درج کریں۔");
                    return;
                }
                _unit.Select();
            }
        }

        private void _laga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.EnterKey())
            {
                _qty.Select();
                _qty.SelectAll();
            }
        }

        private void _CustomerHelper_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_CustomerHelper.IsRow())
                {
                    _customer.Text = _CustomerHelper.CurrentRow.Cells["AccountTitle"].Value.ToString();
                    CurrentCustomer = _CustomerHelper.CurrentRow.Cells["ID"].Value.ToString().toInt();
                    e.SuppressKeyPress = true;
                    if (_customer.Text == "نقد سیل")
                    {
                        customerBal.Text = string.Empty;
                    }
                    else
                    {
                        customerBal.Text = this.GetPartyBalance(CurrentCustomer);
                    }
                        
                    _CustomerHelper.Hide();
                    _customer.Select(); _customer.SelectAll();
                }
            }
        }

        private void _customer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.DownKey() && _CustomerHelper.Visible)
            {
                _CustomerHelper.Select();
            }
            if (e.EnterKey())
            {
                if (_customer.Text.Trim() == string.Empty || CurrentCustomer == 0)
                {
                    this.Error("براہ کرم گاہک منتخب کریں۔");
                    return;
                }
                else
                {
                    _qty.Select();
                    _qty.SelectAll();
                }
            }
        }

        private void _customer_TextChanged(object sender, EventArgs e)
        {
            if (_customer.Focused)
            {
                if (_customer.Text.Length > 0)
                {
                    _CustomerHelper.Show();
                    bsCustomers.Filter = $"AccountTitle Like '%{_customer.Text.Trim()}%'";
                    bsCustomers.ResetBindings(false);
                }
                else
                {
                    CurrentCustomer = 0;
                    _CustomerHelper.Hide();
                }

            }
            CurrentCustomer = 0;
            if(_customer.Text == "نقد سیل")
                    {
                customerBal.Text = string.Empty;
            }
                    else
            {
                customerBal.Text = this.GetPartyBalance(CurrentCustomer);
            }
        }

        private void _marka_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_item.SelectedValue == null || _item.SelectedIndex == -1) { this.Error("براہ کرم اشیاء منتخب کریں۔"); return; }
                if (_customer.Text == string.Empty || CurrentCustomer == 0) { this.Error("براہ کرم گاہک منتخب کریں۔"); return; }
                if (_unit.SelectedIndex == -1) { this.Error("براہ کرم یونٹ منتخب کریں۔"); return; }
                if (_rate1.Text.toDecimal() <= 0 && _rate2.Text.toDecimal() <= 0)
                {
                    this.Error("براہ کرم قیمت درج کریں۔");
                    return;
                }
                decimal sold = summary.Sum(x => x.ItemQty);
                decimal arrived= _ArrivalQty.Text.toDecimal();
                decimal currentQty = _qty.Text.toDecimal();
                if (sold + currentQty > arrived)
                {
                    this.Error($"آپ اس گاہک کو {arrived - sold} مقدار سے زیادہ نہیں دے سکتے۔");
                    _qty.Select();
                    return;
                }
                AddToCart();

            }
        }


        private void AddToCart()
        {
            var item = bsItems[_item.SelectedIndex] as tblItems;
            if (item == null)
            {
                this.Error("Unexpected Error");
                return;
            }
            vwSale3 c = new vwSale3()
            {
                CustomerAmount = _amount1.Text.toDecimal(),
                CustomerRate = _rate1.Text.toDecimal(),
                ItemID = _item.SelectedValue.toInt(),
                ItemQty = _qty.Text.toDecimal(),
                ItemTitle = _item.Text,
                ItemUnit = _unit.SelectedIndex,
                LagaRate = _laga.Text.toDecimal(),
                PartyID = CurrentCustomer,
                PartyTitle = _customer.Text,
                SaleID = CurrentID,
                ItemWeight = _wt.Text.toDecimal(),
                ParyRate = _rate2.Text.toDecimal(),
                PartyAmount = _amount2.Text.toDecimal(),
                Marka = _marka.Text,
                MazdooriRate = item.LabourRate
            };
            bsCart.Add(c);
            bsCart.ResetBindings(false);
            ClearEntryPanel();

            GetTotals();
            GetMazddori();
            dgv.ColumnAutoSizeMode = ColumnAutoSizeMode.AllCellsAndHeader;
            dgv.AutoSizeColumns();
            if (_item.Enabled)
            {
                _item.Select();
            }
            else
            {
                _commission.Select();
            }
        }
        private void ClearEntryPanel(bool complete = false)
        {
            // cmbItems.EditValue = null;
            // cmbCustomers.EditValue = null;
            _laga.Clear();
            _qty.Clear();
            _rate1.Clear();
            _rate2.Clear();
            _amount1.Clear();
            _amount2.Clear();
            _rate2.Clear();
            _unit.SelectedIndex = 0;
            if (complete)
            {
                _item.SelectedIndex = -1;
                _customer.Clear();
                _marka.Clear();
            }
        }
        private void Dgv1_Click(object sender, EventArgs e)
        {

        }

        private void LoadRecordByID(int iD)
        {

            {
                CurrentID = iD;
                object cart = new object();
                object dtsummary = new object();
                _sale = SaleService.GetSaleByID(iD, ref cart, ref dtsummary);
                bsCart.DataSource = cart;
                bsCart.ResetBindings(false);
                objectToControls();
                GetTotals();

            }
        }
        void GetMazddori()
        {
            decimal itemMazdoori = 0;
            foreach (vwSale3 item in bsCart)
            {
                itemMazdoori += item.MazdooriAmount;
            }
            _mazdoori.Value = itemMazdoori.toInt();
        }
        List<vwSale2> summary = new List<vwSale2>();
        private void GetTotals()
        {

            summary.Clear();
            bsSummry.Clear();
            decimal __totalLaga = 0;
            decimal _sale1 = 0;
            decimal _sale2 = 0;
            decimal tobesold = _sale.TotalQty;
            decimal sold = 0;
            decimal rem = 0;
            decimal itemMazdoori = 0;
            foreach (vwSale3 item in bsCart)
            {
                sold += item.ItemQty;
                __totalLaga += item.LagaAmount;
                _sale1 += item.CustomerAmount;
                _sale2 += item.PartyAmount;
                rem = tobesold - sold;
                itemMazdoori += item.MazdooriAmount;
                vwSale2 s = new vwSale2()
                {
                    ID = _sale.ID,
                    ItemQty = item.ItemQty,
                    ItemTitle = item.ItemTitle
                };
                summary.Add(s);
            }
            bsSummry.DataSource = summary.GroupBy(x => new { x.ID, x.ItemTitle }).Select(g => new vwSale2
            {
                ID = g.Key.ID,
                ItemTitle = g.Key.ItemTitle,
                ItemQty = g.Sum(x => x.ItemQty)
            }).ToList();
            bsSummry.ResetBindings(false);
            _grossSale.Value = _sale1.ProperDecimals();

            SetEntryPanel(tobesold - sold == 0);
        }
        private void SetEntryPanel(bool v)
        {
            _item.Enabled = _customer.Enabled = _wt.Enabled = _marka.Enabled = !v;
            _laga.Enabled = _qty.Enabled = _unit.Enabled = _rate1.Enabled = _rate2.Enabled = _amount1.Enabled = _amount2.Enabled = !v;
        }

        int voucherID = 0;
        private void objectToControls()
        {
            _partyID.Text = _sale.PartyID.ToString();
            voucherID = _sale.VoucherID;
            _grossSale.Value = _sale.SaleAmount1.ProperDecimals();
            _ArrivalQty.Text = _sale.TotalQty.ProperDecimals();
            txtTitle.Text = _sale.PartyTitle;
            _commission.Text = _sale.CommissionAmount.ProperDecimals();
            //commissionPerc.Text = _sale.CommisionPerc.ProperDecimals();
            _kraya.Text = _sale.KarayaAmount.ToString("0.##");
            _mazdoori.Text = _sale.MazdooriAmount.ToString("0.##");
            _munshiana.Text = _sale.MunshianaAmount.ToString("0.##");
            _store.Text = _sale.StoreRent.ToString("0.##");
            _paid.Text = _sale.PaidAmount.ToString("0.##");
            arrivalDate.Value = _sale.ArrivalDate;
            ArrivalNo.Text = _sale.ArrivalNo.ToString();
            _vehNo.Text = _sale.VehicleNo;
            txtMarkaMain.Text = _sale.Marka;
        }

        private void _dateRemaining_TextChanged(object sender, EventArgs e)
        {
            if (_dateRemaining.Text.toDecimal() > 0)
            {
                _dateRemaining.BackColor = Color.FromArgb(255, 224, 192);
            }
            else
            {
                _dateRemaining.BackColor = SystemColors.Window;
            }

        }

        private void _unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            _wt.Enabled = _unit.SelectedIndex != 0;
            if (!_wt.Enabled)
            {
                _wt.Value = 0;
            }

        }

        private void _rate2_TextChanged(object sender, EventArgs e)
        {
            CalculateAmounts();
        }

        private void _rate1_TextChanged(object sender, EventArgs e)
        {
            if (_rate1.Focused)
            {
                _rate2.Text = _rate1.Text;
            }
            CalculateAmounts();
        }

        private void CalculateAmounts()
        {
            if (_unit.SelectedIndex == 0) //Qty Based Amount
            {
                _amount1.Value = (_rate1.Value.toDecimal() * _qty.Value.toDecimal());
                _amount2.Value = (_rate2.Value.toDecimal() * _qty.Value.toDecimal());
            }
            else if (_unit.SelectedIndex != 0) //Weight Based Amount
            {
                _amount1.Value = (_rate1.Value.toDecimal() * _wt.Value.toDecimal());
                _amount2.Value = (_rate2.Value.toDecimal() * _wt.Value.toDecimal());
            }
        }

        private void BtnRefresh_Click(object sender, System.EventArgs e)
        {
            Refresh();
        }

        DataTable dtvendors = new DataTable();
        public override void Refresh()
        {
            dtp.Value = dtp1.Value = System.DateTime.Today.Date;
            CurrentID = 0;
            _partyID.Clear();
            SearchRecords();
            loadItems();
            LoadCustomers();
            LoadVendors();
            arrivalDate.Value = DateTime.Now;
            ArrivalNo.Text = SQL.GetNextArrivalNo();
            _vendor.Clear();
            _unit.SelectedIndex = 0;
            mushianaPerc.Value = 0.20;
            CalculateGrandTotals();
            ClearEntryPanel(true);
            _vendor.Select();

        }

        private void LoadVendors()
        {
            dtvendors = DetailAccountService.VendorAccounts().ToDataTable();
            bindingSource1.DataSource = dtvendors;
            bindingSource1.ResetBindings(false);
            bsVendors.DataSource = dtvendors;
            bsVendors.ResetBindings(false);
        }

        DataTable dtCustomers = new DataTable();
        private void LoadCustomers()
        {
            dtCustomers = DetailAccountService.CustomerAccounts().ToDataTable();
            bsCustomers.DataSource = dtCustomers;
        }
        private void loadItems()
        {
            string itemtypes = "";
            itemtypes = "N'فروٹ',N'سبزی'"; // Fruits and Vegetables
            bsItems.DataSource = ItemService.GetItems(itemtypes).OrderBy(x => x.ItemTitle).ToList();
        }

        private void FrmSaleNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                btnRefresh.PerformClick();
            }
            if (e.Alt && e.KeyCode == Keys.N)
            {
                btnRefresh.PerformClick();
            }
            if (e.Alt && e.KeyCode == Keys.P)
            {
                if (CurrentID != 0)
                {
                    using (new waitForm())
                    {
                        XtraReport FinalReport = null;
                        FinalReport = PrintReport(FinalReport, CurrentID, 0);
                        if (FinalReport != null)
                        {
                            FinalReport.ShowPreview();
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.F1)
            {
                if (SaveRecord(true))
                {
                    this.Info("ریکارڈ کامیابی سے محفوظ ہو گیا۔");
                    LoadRecordByID(CurrentID);
                }
            }
        }
        private System.Windows.Forms.Timer resizeTimer;
        private void FrmSaleNew_Resize(object sender, System.EventArgs e)
        {
            obj._resize();
            if (resizeTimer == null)
            {
                resizeTimer = new System.Windows.Forms.Timer();
                resizeTimer.Interval = 300; // milliseconds
                resizeTimer.Tick += ResizeTimer_Tick;
            }

            resizeTimer.Stop();
            resizeTimer.Start();

        }
        private void PositionGridBelowTextboxRTL(EditBox txt, GridEX dgv)
        {
            // Calculate bottom-right of the textbox
            int txtRight = txt.Left + txt.Width;
            int txtBottom = txt.Top + txt.Height;

            // Set DGV location so its top-right aligns with textbox bottom-right
            int dgvLeft = txtRight - dgv.Width;
            int dgvTop = txtBottom + 2; // small vertical gap

            dgv.Location = new Point(dgvLeft, dgvTop);
        }
        private void ResizeTimer_Tick(object sender, EventArgs e)
        {
            resizeTimer.Stop();
            if (!isLoading)
            {
                SetDGVLocations(); 
            }
        }

        bool isLoading = true;
        Point loc_dgvMarka ;
        Point loc__partyHelper ;
        Point loc__CustomerHelper ;
        Point loc__partySearchHelper;
        private void FrmSaleNew_Load(object sender, System.EventArgs e)
        {
            this.Opacity = 0;
            obj._get_initial_size();
            this.WindowState = FormWindowState.Maximized;
            loc_dgvMarka = dgvMarka.Location;
            loc__partyHelper= _partyHelper.Location;
            loc__CustomerHelper = _CustomerHelper.Location;
            loc__partySearchHelper = _partySearchHelper.Location;
            isLoading = false;
            Refresh();
        }
        void SetDGVLocations()
        {
            // dgvMarka.Location= loc_dgvMarka;
            //_partyHelper.Location=loc__partyHelper;
            //_CustomerHelper.Location= loc__CustomerHelper;
            //_partySearchHelper.Location= loc__partySearchHelper;

            PositionGridBelowTextboxRTL(txtMarkaMain, dgvMarka);
            PositionGridBelowTextboxRTL(_customer, _CustomerHelper);
            PositionGridBelowTextboxRTL(partysearch, _partySearchHelper);
            PositionGridBelowTextboxRTL(_vendor, _partyHelper);

        }
        private void label20_Click(object sender, System.EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            SearchRecords();
        }

        private void SearchRecords()
        {
            if (dtp.Value.Date > dtp1.Value.Date)
            {
                this.Error("تارخ درست نہیں۔");
                return;
            }
            vwSale1BindingSource.DataSource = SaleService.GetviewSale1(dtp.Value.Date, dtp1.Value.Date, partysearch.Text.Trim()).OrderByDescending(x => x.ArrivalNo).ToList();
            GetStatus();
            ArrivalNo.Maximum = SaleService.GetMaxSaleNo();
            //dgv1.AutoSizeColumns();

        }

        private void GetStatus()
        {
            decimal arrived = 0;
            decimal sold = 0;
            foreach (vwSale1 record in vwSale1BindingSource)
            {
                arrived += record.TotalQty;
                sold += record.SoldQty;
            }
            _dateTotal.Text = arrived.ProperDecimals();
            _DateSold.Text = sold.ProperDecimals();
            _dateRemaining.Text = (arrived - sold).ProperDecimals();
        }

        private void txtPartyTitle_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void _netSale_Click(object sender, EventArgs e)
        {

        }

        private void _amount2_Click(object sender, EventArgs e)
        {

        }

        private void _amount1_Click(object sender, EventArgs e)
        {

        }

        private void _rate2_Click(object sender, EventArgs e)
        {

        }

        private void _rate1_Click(object sender, EventArgs e)
        {

        }

        private void _wt_Click(object sender, EventArgs e)
        {

        }

        private void uiButton3_Click(object sender, EventArgs e)
        {

            var rows = dgv1.GetCheckedRows();
            if (rows.Length == 0 && CurrentID == 0)
            {
                this.Error("پرنٹ کے لئے بل منتخب کریں۔");
                return;
            }

            using (new waitForm())
            {
                XtraReport Finalreport = null;
                if (rows.Length == 0 && CurrentID != 0)
                {
                    Finalreport = PrintReport(Finalreport, CurrentID, 0);
                }
                List<int> saleIds = new List<int>();
                foreach (GridEXRow row in rows)
                {
                    vwSale1 record = row.DataRow as vwSale1;
                    saleIds.Add(record.ID);
                }
                if (saleIds.Any())
                {
                    saleIds.Sort();
                    foreach (int id in saleIds)
                    {
                        Finalreport = PrintReport(Finalreport, id, 0);
                    }
                }
                if (Finalreport != null)
                {
                    Finalreport.ShowPreview();
                }
            }

        }

        private static XtraReport PrintReport(XtraReport Finalreport, int id, int idType)
        {
            var report = new saleBill(id.ToString(), idType);
            report.CreateDocument();
            if (Finalreport == null)
            {
                Finalreport = report;
            }
            else
            {
                Finalreport.Pages.AddRange(report.Pages);
            }

            return Finalreport;
        }

        private void _item_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (_item.Focused)
            {
                _item.DroppedDown = true;
            }
        }

        private void customerBal_TextChanged(object sender, EventArgs e)
        {
            if (customerBal.Text.toDecimal() > 0)
            {
                customerBal.BackColor = Color.LightCoral;
            }
            else if (customerBal.Text.toDecimal() < 0)
            {
                customerBal.BackColor = Color.LightGreen;
            }
            else
            {
                customerBal.BackColor = Color.White;
            }

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            loadItems();
            LoadCustomers();
            LoadVendors();
        }

       
    }
}
public class waitForm : IDisposable
{
    private readonly SplashScreenManager _splashScreenManager;
    private readonly Form _parentForm;
    private readonly Type _waitFormType;
    private readonly string _title;
    private readonly string _caption;
    public waitForm(Type waitFormType = null, string title = "Please Wait", string caption = "Processing...")
    {
        _parentForm = Form.ActiveForm ?? Application.OpenForms[0];
        _waitFormType = waitFormType ?? typeof(WaitForm1);
        _title = title;
        _caption = caption;
        _splashScreenManager = new SplashScreenManager(
            _parentForm,
            _waitFormType,
            true,
            true);
        _splashScreenManager.ShowWaitForm();
        _splashScreenManager.SetWaitFormCaption(_title);
        _splashScreenManager.SetWaitFormDescription(_caption);
    }
    public void UpdateStatus(string caption, string description = null)
    {
        if (!string.IsNullOrEmpty(caption))
            _splashScreenManager.SetWaitFormCaption(caption);

        if (!string.IsNullOrEmpty(description))
            _splashScreenManager.SetWaitFormDescription(description);
    }
    public void Dispose()
    {
        if (_splashScreenManager != null && _splashScreenManager.IsSplashFormVisible)
        {
            _splashScreenManager.CloseWaitForm();
            _splashScreenManager.Dispose();
        }
    }
}
