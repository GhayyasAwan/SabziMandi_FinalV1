using DevExpress.Utils.Behaviors;
using MandiPOS.CLasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class frmCityNew : Form
    {
        clsResize objResize;
        public frmCityNew()
        {
            InitializeComponent();
            objResize = new clsResize(this);
            dgv.RowDoubleClick += Dgv_RowDoubleClick;
            this.Resize += FrmCityNew_Resize;
            objResize._get_initial_size();
            this.Load += FrmCityNew_Load;
            txtName.Enter += TxtName_Enter;
            txtName.Leave += TxtName_Leave;
            txtName.KeyDown += TxtName_KeyDown;
            dgv.KeyDown += Dgv_KeyDown;
            btnSave.Click += BtnSave_Click;
        }

        private void Dgv_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            EditCurrent();
        }

        private void FrmCityNew_Resize(object sender, EventArgs e)
        {
            objResize._resize();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                this.Error("شہر کا نام درج کریں");
                return;
            }
            city.CityName = txtName.Text;
            try
            {
                if (SQL.SaveCity(city)) { Refresh(); }
            }
            catch (Exception ex)
            {
                ex.ExcError("While Saving City...");
            }
        }

        private void Dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { EditCurrent(); }
            if(e.KeyCode==Keys.Delete) { DeleteCurrent(); }
        }

        private void DeleteCurrent()
        {
            if (dgv.CurrentRow.RowIndex != -1 && dgv.CurrentRow.RowType == Janus.Windows.GridEX.RowType.Record)
            {
                if (this.Delete("شہر") && SQL.DeleteCity(dgv.CurrentRow.Cells[0].Value.toInt()))
                {
                    Refresh();
                }
            }
        }

        tblCity city;
        private void EditCurrent()
        {
            if (dgv.CurrentRow.RowIndex != -1 && dgv.CurrentRow.RowType == Janus.Windows.GridEX.RowType.Record)
            {
                city = tblCityBindingSource[dgv.CurrentRow.RowIndex] as tblCity;
                txtName.Text=city.CityName;
                txtName.Select();
            }

        }

        private void TxtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { 
                btnSave.Select();
            }
            if (e.KeyCode == Keys.Down)
            { 
                dgv.Select();
            }
        }

        private void TxtName_Leave(object sender, EventArgs e)
        {
            txtName.BackColor=SystemColors.Window;
        }

        private void TxtName_Enter(object sender, EventArgs e)
        {
            Program.UrduInput(true);
            txtName.BackColor = Color.Cyan;
        }

        private void FrmCityNew_Load(object sender, EventArgs e)
        {
            Refresh();
        }
        List<tblCity> cities = new List<tblCity>();
        public override void Refresh()
        {
            cities=SQL.GetCities();
            tblCityBindingSource.DataSource = cities;
            city =new tblCity();
            txtName.Clear();
            txtName.Select();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Focused)
            {
                if (txtName.Text.Trim().Length == 0)
                {
                    tblCityBindingSource.DataSource = cities;
                }
                else
                {
                    tblCityBindingSource.DataSource = cities.Where(x=>x.CityName.StartsWith(txtName.Text.Trim()));
                    
                }
                tblCityBindingSource.ResetBindings(false);
            }
        }
    }
}
