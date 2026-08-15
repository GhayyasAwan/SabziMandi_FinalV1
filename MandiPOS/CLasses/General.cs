

using Dapper;
using DevExpress.XtraEditors;

using Janus.Windows.GridEX;
using Janus.Windows.GridEX.EditControls;

using MandiPOS.CLasses;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace MandiPOS
{
    public static class KeyEventArgsExtensions
    {

        public static void HideWarnings(this DevExpress.XtraReports.UI.XtraReport rpt)
        {
            rpt.ShowPrintMarginsWarning = false;
        }
        public static bool EnterKey(this KeyEventArgs e)
        {
            return e.KeyCode == Keys.Enter;
        }
        public static bool DownKey(this KeyEventArgs e)
        {
            return e.KeyCode == Keys.Down;
        }
        public static bool EscapeKey(this KeyEventArgs e)
        {
            return e.KeyCode == Keys.Escape;
        }
    }

    public static class General
    {
        public static int PendingSaleAccount = 0;
        public static int CommissionAccount = 0;
        public static int MazdooriAccount = 0;
        public static int KarayaAccount = 0;
        public static int MunshianaAccount = 0;
        public static int StoreAccount = 0;
        public static int NetPaidAccount = 0;
        public static int LagaAccount = 0;
        internal static string dbSystemName;
        internal static bool CheckIsApplicationLocked()
        {
            return SQL.IsLocked;
        }
        public static bool IsVerified(this Form f,int VerficationID = 1)
        {
            using (var frm = new frmVerfication(VerficationID))
            { 
                return frm.ShowDialog()== DialogResult.OK;
            }
        }
        public static string GetPartyBalance(this Form f, int AccountID)
        {
            if (General.IsAdmin)
            {
                decimal bal = new db().ExecuteScalar<decimal>($"Select ISNULL(Sum(ISNULL(DebitAmount,0)-ISNULL(CreditAmount,0)),0) as Bal from vwTrx Where AccountID='{AccountID}'");

                return $"{bal.ToString("#,0.##")}";
            }
            else
            {
                return string.Empty;
            }
        }

        public static void EnterToNext(this Control c, KeyEventArgs e)
        {
            if (e.EnterKey())
            {
                c.Parent.SelectNextControl(c, true, true, true, true);
            }
        }
        public static void EnterToNext(this Control c)
        {

            c.KeyDown += ((s, e) =>
            {
                if (e.EnterKey())
                {
                    c.Parent.SelectNextControl(c, true, true, true, true);
                }
            });

        }
        public static void RegisterFocus(this Control c, bool isUrdu = false)
        {
            c.Enter += (s, e) =>
            {

                if (c is TextBox tb)
                {
                    tb.BackColor = System.Drawing.Color.Yellow;
                }
                else if (c is EditBox eb)
                {
                    eb.BackColor = System.Drawing.Color.Yellow;
                }
                else
                {
                    c.BackColor = System.Drawing.Color.Yellow;
                }
                if (isUrdu)
                {
                    c.Padding = new Padding(10, 0, 10, 0);
                    c.RightToLeft = RightToLeft.Yes;
                    Program.UrduInput(true);
                }
            };
            c.Leave += (s, e) =>
            {
                if (c is TextBox tb)
                {
                    tb.BackColor = System.Drawing.Color.White;
                }
                else if (c is EditBox eb)
                {
                    eb.BackColor = System.Drawing.Color.White;
                }
                else
                {
                    c.BackColor = System.Drawing.Color.White;
                }
            };
        }
        public static void SwitchToUrdu(this Form f)
        {
            Program.UrduInput(true);
        }
        public static void Hide(this Control c)
        {
            c.Visible = false;
        }
        public static void Show(this Control c)
        {
            c.Visible = true;
        }
        public static void SwitchToEnglish(this Form f)
        {
            Program.UrduInput(false);
        }
        public static DataTable ToDataTable<T>(this IEnumerable<T> data)
        {
            DataTable table = new DataTable();
            if (data == null) return table;

            var properties = typeof(T).GetProperties();

            foreach (var prop in properties)
            {
                Type propType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                table.Columns.Add(prop.Name, propType);
            }

            foreach (var item in data)
            {
                var values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(item, null);
                }
                table.Rows.Add(values);
            }

            return table;
        }
        public static bool IsRow(this GridEX dgv)
        {
            return dgv.CurrentRow != null && dgv.CurrentRow.RowIndex != -1 && dgv.CurrentRow.RowType == RowType.Record;
        }

        public static void setFormat(this GridEX dgv)
        {
            if (dgv.RootTable == null) return;
            foreach (GridEXColumn col in dgv.RootTable.Columns)
            {
                if (col.FormatString == "c") //decimal
                {
                    col.FormatString = "0.##";
                    col.TotalFormatString = "0.##";
                }
                if (col.FormatString == "d") //date
                {
                    col.FormatString = "dd-MM-yyyy";
                }
            }
        }
        public static void setReadOnly(this GridEX dgv)
        {
            if (dgv.RootTable == null) return;
            foreach (GridEXColumn col in dgv.RootTable.Columns)
            {
                if (col.ActAsSelector)
                {
                    continue;
                }
                col.SelectableCells = SelectableCells.FilterRowCells;
                if (col.FormatString == "c")
                {
                    col.FormatString = "N2";
                }
                if (col.FormatString == "d")
                {
                    col.FormatString = "dd-MMM-yyyy";
                }
            }
        }
        public static object RecordID(this GridEX dgv, int columIndex = 0)
        {
            if (dgv.CurrentRow != null && dgv.CurrentRow.RowIndex != -1 && dgv.CurrentRow.RowType == RowType.Record)
            {
                return dgv.GetValue(columIndex);
            }
            return null;
        }
        public static int CurrentUserID { get; internal set; } = 1; // Default to 1 for testing, should be set to actual user ID on login
        public static bool IsAdmin { get; internal set; }
        public static string UserName { get; internal set; }
        public static int MultanCityID { get; internal set; }
        public static DateTime MinimumDate { get; internal set; }
        public static DateTime ServerDate { get { return SQL.ServerDate; } }

        public static tblSecurity Security { get; internal set; }

        internal static int GetMultanCityID()
        {
            var cities = SQL.GetCities();
            if (cities.Any(x => x.CityName == "ملتان"))
            {
                return cities.Where(x => x.CityName == "ملتان").FirstOrDefault().ID;
            }
            if (cities.Any(x => x.CityName == "مُلتان"))
            {
                return cities.Where(x => x.CityName == "مُلتان").FirstOrDefault().ID;
            }
            return 0;
        }


        #region MessageBox
        public static bool Ask(this Form f, string message)
        {
            return ShowMessage(message, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static bool Info(this Form f, string message)
        {
            return ShowMessage(message, "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
        public static bool Error(this Form f, string message)
        {
            return ShowMessage(message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }
        public static bool ExcError(this Form f, Exception ex)
        {
            return ShowMessage(ex.Message + $"{ex.Message}\r\nDetails:{ex.InnerException}", "Exception", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }
        public static bool ExcError(this XtraForm f, Exception ex)
        {
            return ShowMessage(ex.Message + $"{ex.Message}\r\nDetails:{ex.InnerException}", "Exception", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }
        private static string ExtractCleanSqlErrorMessage(Exception ex)
        {
            if (ex == null || string.IsNullOrWhiteSpace(ex.Message))
                return string.Empty;

            string fullMessage = ex.Message;

            // SQL Keywords jin ka index check karna hai
            string[] sqlKeywords = new string[] { "SELECT", "INSERT", "UPDATE", "DELETE" };

            int firstKeywordIndex = -1;

            // Sabse pehle aane wale keyword ka index nikalen
            foreach (var keyword in sqlKeywords)
            {
                int index = fullMessage.IndexOf(keyword, StringComparison.OrdinalIgnoreCase);

                if (index != -1)
                {
                    if (firstKeywordIndex == -1 || index < firstKeywordIndex)
                    {
                        firstKeywordIndex = index;
                    }
                }
            }

            // Agar SQL Keyword mil jaye, toh us se pehle wala text return karein
            if (firstKeywordIndex > 0)
            {
                return fullMessage.Substring(0, firstKeywordIndex).Trim();
            }

            return fullMessage.Trim();
        }
        public static bool ExcError(this Exception ex, string errorPoint = "")
        {
            string message =ExtractCleanSqlErrorMessage(ex);
            
            if (ex.InnerException != null && ex.InnerException.Message.Length > 0)
            {
                message +="\n"+ ex.InnerException.ToString();
            }

            string caption = string.IsNullOrEmpty(errorPoint) ? "Exception" : $"Error on: {errorPoint}";

            return ShowMessage(message, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

        }
        private static bool ShowMessage(string message, string caption, MessageBoxButtons btn, MessageBoxIcon icon)
        {
            // return CustomMessageBoxForm.Show(message, caption, btn);
            return MessageBox.Show(message, caption, btn, icon) == DialogResult.Yes;
        }

        public static string GetPakistaniFiscalYear(this Form f)
        {
            DateTime now = DateTime.Now;
            int startYear = now.Month >= 7 ? now.Year : now.Year - 1;
            int endYear = startYear + 1;
            return $"{startYear}-{endYear}";
        }

        public static bool Ask(this XtraForm f, string message)
        {
            return XtraMessageBox.Show(message, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
        public static bool Delete(this XtraForm f, string recordTitle)
        {
            return XtraMessageBox.Show($"کیا آپ واقی اس {recordTitle} کو ڈیلیٹ کرنا چاہتے ہیں؟", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
        public static bool Delete(this Form f, string recordTitle)
        {
            return XtraMessageBox.Show($"کیا آپ واقی اس {recordTitle} کو ڈیلیٹ کرنا چاہتے ہیں؟", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
        public static bool Info(this XtraForm f, string message)
        {
            return XtraMessageBox.Show(message, "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Yes;
        }
        public static bool Error(this XtraForm f, string message)
        {
            return XtraMessageBox.Show(message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.Yes;
        }
        #endregion

        #region Converters
        public static int toInt(this object o)
        {
            if (o == null)
                return 0;

            if (decimal.TryParse(o.ToString(), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal result))
                return (int)result;

            return 0;
        }
        public static string Decrypt(this string cipherText)
        {
            try
            {
                return Eramake.eCryptography.Decrypt(cipherText);
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public static string Encrypt(this string simpleText)
        {
            try
            {
                return Eramake.eCryptography.Encrypt(simpleText);
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public static decimal toDecimal(this object o)
        {
            decimal.TryParse(
                o?.ToString(),
                NumberStyles.Number, // includes AllowDecimalPoint, AllowThousands, AllowLeadingSign, etc.
                CultureInfo.InvariantCulture,
                out decimal result
            );
            return result;
        }

        public static decimal toRound(this decimal o)
        {
            return Math.Round(o, 0, MidpointRounding.AwayFromZero);
        }

        public static string ProperDecimals(this decimal d)
        {
            return d.ToString("0.##");
        }
        public static bool toBool(this object o)
        {
            bool.TryParse(o?.ToString(), out bool result);
            return result;
        }
        #endregion

        #region OtherExtentions
        public static void SetColumnsFormat(this GridEX dgv, bool footerRow, string[] totalColumns, string[] countColumns)
        {
            if (dgv.RootTable != null)
            {
                foreach (GridEXColumn col in dgv.RootTable.Columns)
                {
                    if (col.FormatString == "d")
                    {
                        col.FormatString = "dd-MM-yyyy";
                    }
                    else if (col.FormatString == "c")
                    {
                        col.FormatString = "0.##";
                    }
                }
            }
            if (footerRow)
            {
                dgv.TotalRowFormatStyle.BackColor = System.Drawing.SystemColors.Info;
                dgv.TotalRowFormatStyle.FontBold = TriState.True;
                dgv.TotalRow = InheritableBoolean.True;
                dgv.TotalRowPosition = TotalRowPosition.BottomFixed;
            }
            foreach (string col in totalColumns)
            {
                if (dgv.RootTable.Columns.Contains(col))
                {
                    dgv.RootTable.Columns[col].AggregateFunction = AggregateFunction.Sum;
                    dgv.RootTable.Columns[col].TotalFormatString = "0.##";
                }
            }
            foreach (string col in countColumns)
            {
                if (dgv.RootTable.Columns.Contains(col))
                {
                    dgv.RootTable.Columns[col].AggregateFunction = AggregateFunction.Count;
                    dgv.RootTable.Columns[col].TotalFormatString = "0";
                }
            }
        }

        internal static DataTable FetchRecords(string sql, object value)
        {
            using (var conn = new db())
            {
                var reader = conn.ExecuteReader(sql, param: value);
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
        }
        #endregion
    }
}
