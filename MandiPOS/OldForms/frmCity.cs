using DevExpress.XtraEditors;

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
    public partial class frmCity : DevExpress.XtraEditors.XtraForm
    {
        tblCity city;
        public frmCity()
        {
            InitializeComponent();
            this.KeyPreview = true;
            gridView1.Columns[1].OptionsColumn.AllowEdit = false;
            this.Load += FrmCity_Load;
            this.FormClosing += FrmCity_FormClosing;
            txtTitle.Enter += TxtTitle_Enter;
            txtTitle.Leave += TxtTitle_Leave;
            gridView1.Click += GridView1_Click;
            gridView1.KeyDown += GridView1_KeyDown;
            gridView1.DoubleClick += GridView1_DoubleClick;
            txtTitle.KeyDown += TxtTitle_KeyDown;
            this.KeyDown += FrmCity_KeyDown;
        }

        private void FrmCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Refresh();
            }
        }

        private void TxtTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                gridView1.Focus();
            }
        }

        private void GridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteCurrent();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                EditCurrent();
            }
        }

        private void FrmCity_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.UrduInput(false);
        }

        private void TxtTitle_Leave(object sender, EventArgs e)
        {
            Program.UrduInput(false);
        }

        private void TxtTitle_Enter(object sender, EventArgs e)
        {
            Program.UrduInput(true);
        }

        private void GridView1_Click(object sender, EventArgs e)
        {
            EditCurrent();
        }

        private void EditCurrent()
        {
            var row = gridView1.FocusedRowHandle;
            if (row != -1)
            {
                city = bs.Current as tblCity;
                if (city != null)
                {
                    try
                    {
                        txtTitle.Text = city.CityName;
                        txtTitle.Focus();
                        txtTitle.SelectionStart = txtTitle.Text.Length; // Move cursor to end
                        txtTitle.SelectionLength = 0;                   // No selection

                    }
                    catch (Exception ex)
                    {
                        ex.ExcError("Editing City...");
                    }
                }

            }
        }

        private void TextEdit1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void GridView1_DoubleClick(object sender, EventArgs e)
        {


        }

        private void DeleteCurrent()
        {
            var row = gridView1.FocusedRowHandle;
            if (row != -1)
            {
                city = bs.Current as tblCity;
                if (city != null && this.Delete("شہر"))
                {
                    try
                    {
                        SQL.DeleteCity(city.ID);
                        Refresh();
                    }
                    catch (Exception ex)
                    {
                        ex.ExcError("Deleting City...");
                    }
                }

            }
        }

        public override void Refresh()
        {
            city = new tblCity();
            txtTitle.Clear();
            bs.DataSource = SQL.GetCities();
        }
        private void FrmCity_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                this.Error("شہر کا نام درج کریں");
                return;
            }
            {
                city.CityName = txtTitle.Text;
                try
                {
                    SQL.SaveCity(city);
                    Refresh();
                }
                catch (Exception ex)
                {
                    ex.ExcError("Saving City...");
                }
            }

        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            if (txtTitle.Focused)
            {
                if (txtTitle.Text.Trim().Length > 0)
                {
                    bs.RemoveFilter();
                }
                else
                {
                    bs.Filter = $"CityName like '%{txtTitle.Text}%'";
                    bs.ResetBindings(false);
                }
            }
        }
    }
}