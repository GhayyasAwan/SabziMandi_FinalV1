using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;

using MandiPOS.CLasses;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class frmItems : DevExpress.XtraEditors.XtraForm
    {
        tblItems item;
        public frmItems()
        {
            InitializeComponent();
            this.KeyPreview = true;
            comboBoxEdit1.Properties.DataSource = new ItemTypes().GetList();
            comboBoxEdit1.EditValue = 1;
            txtMazdoori.KeyDown += TxtMazdoori_KeyDown;
            txtMazdoori.KeyUp += TxtMazdoori_KeyUp;
            txtName.KeyDown += TxtName_KeyDown;
            comboBoxEdit1.KeyUp += ComboBoxEdit1_KeyUp;
            gridView1.Click += GridView1_Click;
            foreach (GridColumn col in gridView1.Columns)
            {
                col.OptionsColumn.AllowEdit = false;
            }
            gridView1.KeyDown += GridView1_KeyDown;
            this.KeyDown += FrmItems_KeyDown;
        }

        private void TxtMazdoori_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SaveRecord();
            }
        }

        private void FrmItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Refresh();
            }
        }

        private void GridView1_Click(object sender, EventArgs e)
        {
            EditCurrent();
        }

        private void GridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EditCurrent();
            }
            if (e.KeyCode == Keys.Delete)
            {
                if (gridView1.FocusedRowHandle >= 0 && this.Delete("ریکارڈ"))
                {
                    var id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]);
                    if (SQL.DeleteItem(Convert.ToInt32(id)))
                    {
                        Refresh();
                    }
                }
            }

        }

        private void EditCurrent()
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                item = (tblItems)gridView1.GetRow(gridView1.FocusedRowHandle);
                BindObject();
                txtName.Select();
            }

        }

        private void TxtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                gridView1.Focus();
            }
        }

        private void TxtMazdoori_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void SaveRecord()
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                this.Error("اشیاء کا نام درج کریں۔");
                return;
            }
            if (string.IsNullOrEmpty(txtLaga.Text.Trim()))
            {
                this.Error("لاگا درج کریں۔");
                return;
            }
            if (string.IsNullOrEmpty(txtMazdoori.Text.Trim()))
            {
                this.Error("مزدوری درج کریں۔");
                return;
            }
            if (string.IsNullOrEmpty(txtKaraya.Text.Trim()))
            {
                this.Error("کرایہ درج کریں۔");
                return;
            }
            item.ItemTitle = txtName.Text.Trim();
            item.ChwanniRate = Convert.ToDecimal(txtLaga.Text.Trim());
            item.LabourRate = Convert.ToDecimal(txtMazdoori.Text.Trim());
            item.fairRate = Convert.ToDecimal(txtKaraya.Text.Trim());
            item.ItemType = comboBoxEdit1.Text.Trim();
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

        private void ComboBoxEdit1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtName.Select();
            }
        }

        public override void Refresh()
        {
            ClearControls();
            item = new tblItems();
            item.Code = SQL.GetNewCode();
            try
            {
                tblItemsBindingSource.DataSource = SQL.GetAllItems($" where ItemType like N'{comboBoxEdit1.Text.Trim()}'");
                BindObject();
                comboBoxEdit1.Select();
            }
            catch (Exception ex)
            {
                ex.ExcError("Getting Items...");
            }
        }

        private void ClearControls()
        {
            txtCode.Clear();
            txtName.Clear();
            txtLaga.Clear();
            txtKaraya.Clear();
            txtMazdoori.Clear();
        }

        private void BindObject()
        {
            txtCode.EditValue = item.Code;
            txtName.EditValue = item.ItemTitle;
            txtKaraya.EditValue = item.fairRate;
            txtMazdoori.EditValue = item.LabourRate;
            txtLaga.EditValue = item.ChwanniRate;
        }

        private void comboBoxEdit1_Enter(object sender, EventArgs e)
        {
            Program.UrduInput(true);
        }

        private void comboBoxEdit1_Leave(object sender, EventArgs e)
        {
            Program.UrduInput(false);
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            Program.UrduInput(false);
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            Program.UrduInput(true);
        }

        private void comboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}