

using Dapper;
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
    public partial class frmUserEditor : Form
    {
        tblUsers user;
        public frmUserEditor(object RecordID)
        {
            InitializeComponent();
            user = new db().Get<tblUsers>(RecordID) ?? new tblUsers();
            bs.DataSource = user;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            bs.EndEdit();
            user = bs[0] as tblUsers;
            if (user == null) { return; }
            using (var db = new db())
            {
                using (var trx = db.BeginTransaction())
                {
                    try
                    {
                        db.Upsert(user, trx);
                        trx.Commit();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        trx.Rollback();
                        ex.ExcError();
                    }
                }
            }
        }
    }
}
