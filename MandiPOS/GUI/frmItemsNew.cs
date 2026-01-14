using MandiPOS.CLasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class frmItemsNew : Form
    {
        clsResize objResizer;
        public frmItemsNew()
        {
            InitializeComponent();
            txtName.Leave += controlLeave;
            txtName.TextChanged += TxtName_TextChanged;
            txtLaga.Leave += controlLeave;
            txtKaraya.Leave += controlLeave;
            txtmazdoori.Leave += controlLeave;
            dgv.KeyDown += Dgv_KeyDown;
            cmbItemType.KeyDown += CmbItemType_KeyDown;
            cmbItemType.Enter += switchToUrdu;
            txtName.KeyDown += TxtName_KeyDown;
            txtKaraya.KeyDown += TxtKaraya_KeyDown;
            txtmazdoori.KeyDown += Txtmazdoori_KeyDown;
            txtLaga.KeyDown += TxtLaga_KeyDown;
            txtName.Enter += switchToUrdu;
            txtLaga.Enter += switchToEnglish;
            txtKaraya.Enter += switchToEnglish;
            txtmazdoori.Enter += switchToEnglish;
            objResizer = new clsResize(this);
            objResizer._get_initial_size();
            this.Resize += FrmItemsNew_Resize;
            itemTypesBindingSource.DataSource = new ItemTypes().GetList();
            cmbItemType.SelectedIndexChanged += CmbItemType_SelectedIndexChanged;
            this.Load += FrmItemsNew_Load;
            dgv.RowDoubleClick += Dgv_RowDoubleClick;
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Focused)
            {
                if (txtName.Text.Trim().Length > 0)
                {
                    tblItemsBindingSource.DataSource = items.Where(x => x.ItemTitle.StartsWith(txtName.Text)).ToList();
                }
                else
                {
                    tblItemsBindingSource.DataSource = items;
                }
                tblItemsBindingSource.ResetBindings(false);
            }
        }

        private void Dgv_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            EditCurrent();
        }

        private void controlLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = SystemColors.Window;
        }

        private void Dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EditCurrent();
            }
        }

        private void EditCurrent()
        {
            if (dgv.CurrentRow.RowIndex != -1 && dgv.CurrentRow.RowType == Janus.Windows.GridEX.RowType.Record)
            {
                item = tblItemsBindingSource[dgv.CurrentRow.RowIndex] as tblItems;
                BindObject();
                txtName.Select();
            }
        }

        private void CmbItemType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtName.Select();
            }
        }

        private void TxtLaga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtKaraya.Select();
            }
        }

        private void Txtmazdoori_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtName.Text.Trim().Length == 0)
                {
                    this.Error("اشیاء کا نام درج کریں۔");
                    return;
                }
                item.ChwanniRate = txtLaga.Text.toDecimal();
                item.LabourRate = txtmazdoori.Text.toDecimal();
                item.fairRate = txtKaraya.Text.toDecimal();
                item.ItemTitle = txtName.Text.Trim();
                item.ItemType = cmbItemType.Text.ToString();
                try
                {
                    if (SQL.SaveItem(item))
                    {
                        Refresh();
                    }
                }
                catch (Exception ex)
                {
                    ex.ExcError("Saving Item....");
                }
            }
        }

        private void TxtKaraya_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtmazdoori.Select();
            }
        }

        private void TxtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLaga.Select();
            }
            if (e.KeyCode == Keys.Down)
            {
                dgv.Select();
            }
        }

        private void switchToEnglish(object sender, EventArgs e)
        {
            Program.UrduInput(false);
        }

        private void switchToUrdu(object sender, EventArgs e)
        {
            Program.UrduInput(true);
            ((Control)sender).BackColor = Color.LightCyan;
        }

        private void FrmItemsNew_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void CmbItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbItemType.SelectedIndex != -1)
            {
                Refresh();
            }
        }
        tblItems item;
        List<tblItems> items = new List<tblItems>();
        public override void Refresh()
        {
            ClearControls();
            item = new tblItems();
            item.Code = SQL.GetNewCode();
            try
            {
                items = SQL.GetAllItems($" where ItemType like N'{cmbItemType.Text.Trim()}'");
                tblItemsBindingSource.DataSource= items;
                tblItemsBindingSource.ResetBindings(false);
                BindObject();
                cmbItemType.Select();
            }
            catch (Exception ex)
            {
                ex.ExcError("Getting Items...");
            }
        }

        private void BindObject()
        {
            txtCode.Text = item.Code.ToString();
            txtName.Text = item.ItemTitle;
            txtLaga.Text = item.ChwanniRate.ToString("0.00");
            txtmazdoori.Text = item.LabourRate.ToString("0.00");
            txtKaraya.Text = item.fairRate.ToString("0.00");
        }

        private void ClearControls()
        {
            txtCode.Clear();
            txtName.Clear();
            txtLaga.Clear();
            txtKaraya.Clear();
            txtmazdoori.Clear();
        }

        private void FrmItemsNew_Resize(object sender, EventArgs e)
        {
            objResizer._resize();
        }
    }
}
