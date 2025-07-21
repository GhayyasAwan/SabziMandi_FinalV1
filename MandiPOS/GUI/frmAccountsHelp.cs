using Janus.Windows.GridEX;
using MandiPOS.CLasses;
using System;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class frmAccountsHelp : Form
    {
        public GridEXRow row;
        public frmAccountsHelp()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;
            this.MinimizeBox = false; MaximizeBox = false;
            this.Load += FrmAccountsHelp_Load;
            this.KeyDown += (s, e) =>
            {
                if (e.EscapeKey())
                {
                    row = null;
                    this.DialogResult = DialogResult.Cancel;
                }
            };
            gridEX1.KeyDown += (s, e) =>
            {
                if (e.EnterKey())
                {
                    if (gridEX1.IsRow())
                    {
                        row = gridEX1.CurrentRow;
                        e.SuppressKeyPress = true;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                if (e.EscapeKey())
                {
                    row = null;
                    this.DialogResult = DialogResult.Cancel;
                }
            };
        }
        int filterRow = GridEX.filterRowPosition;
        private void FrmAccountsHelp_Load(object sender, EventArgs e)
        {
            detailAccountViewBindingSource.DataSource = DetailAccountService.GetAccountsViewList();
            gridEX1.Row = filterRow;
            gridEX1.Col = gridEX1.RootTable.Columns["AccountTitle"].Index;
            this.SwitchToUrdu();
            gridEX1.EditMode = EditMode.EditOn;
        }
    }
}
