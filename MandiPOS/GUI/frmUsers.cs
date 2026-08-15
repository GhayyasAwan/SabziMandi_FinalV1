using Dapper;

using System;
using System.Linq;
using System.Windows.Forms;

using static MandiPOS.SQL;

namespace MandiPOS.GUI
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
            this.Load += FrmUsers_Load;
        }
        public override void Refresh()
        {
            bs.DataSource = new db().GetList<CLasses.tblUsers>().ToList();
        }
        private void FrmUsers_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            GetEditor(null);
        }

        private void GetEditor(object value)
        {
            using (var frm = new frmUserEditor(value))
            {
                frm.ShowDialog();
                Refresh();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (gridEX1.IsRow())
            {
                GetEditor(gridEX1.GetValue(0));
            }
        }
    }
}
