
using Dapper;
using MandiPOS.CLasses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class frmImportAccounts : Form
    {
        public frmImportAccounts()
        {
            InitializeComponent();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Select CSV or Text File";
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv|Text Files (*.txt)|*.txt";
            openFileDialog.Multiselect = false;
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = openFileDialog.FileName;

                LoadCsvToBindingSource(selectedFile, excelFormatBindingSource);
                excelFormatBindingSource.ResetBindings(false);
            }
        }
        List<ExcelFormat> data = new List<ExcelFormat>();
        private void LoadCsvToBindingSource(string filePath, BindingSource bindingSource)
        {
            data = new List<ExcelFormat>();

            using (var reader = new StreamReader(filePath, System.Text.Encoding.UTF8))
            {
                string headerLine = reader.ReadLine(); // skip or read headers

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var parts = line.Split(',');

                    // Make sure there are enough columns
                    if (parts.Length < 10) continue;

                    var record = new ExcelFormat
                    {
                        AccountHead = parts[0].Trim(),
                        AccountName = parts[1].Trim(),
                        Contact = parts[2].Trim(),
                        City = parts[3].Trim(),
                        OpDebit = ParseDecimal(parts[4]),
                        opCredit = ParseDecimal(parts[5]),
                        Remarks = parts[6].Trim(),
                        CreditLimit = ParseDecimal(parts[7]),
                        Commission = ParseDecimal(parts[8]),
                        RefName = parts[9].Trim()
                    };

                    data.Add(record);
                }
            }

            bindingSource.DataSource = data;
        }

        private decimal ParseDecimal(string input)
        {
            decimal.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result);
            return result;
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            string message = "یہ عمل آپکی سابقہ تمام ٹرانزیکشنز اور کھاتہ انفارمینش ختم کر دے گا۔ کیا آپ آگے بڑھنا چاہتے ہیں؟";
            if (this.Ask(message))
            {
                if (TransactionsCleared() && MasterAccountsCreated() && CitiesCreated())
                {
                    if (DetailAccountsCreated() && AppendRef())
                    {
                        this.Info("تمام کھاتہ اور شہر کامیابی سے درآمد ہو گئے ہیں۔");
                        this.Close();
                    }

                }
            }
        }

        private bool AppendRef()
        {
            using (var db = new db())
            {
                using (var trx = db.BeginTransaction())
                {
                    try
                    {
                        List<DetailAccounts> detailAccounts = db.GetList<DetailAccounts>(transaction: trx).ToList();
                        foreach (DetailAccounts d in detailAccounts)
                        {
                            if (string.IsNullOrWhiteSpace(d.RefName))
                                continue;
                            // Check if the reference name already exists
                            var existingRef = db.GetList<DetailAccounts>($"WHERE AccountTitle = @RefName", new { RefName = d.RefName }, transaction: trx).FirstOrDefault();
                            if (existingRef == null)
                                continue; // Skip if it already exists
                            // Update the reference name
                            d.RefName = d.RefName.Trim();
                            d.RefrenceID = existingRef.ID;
                            d.RefrenceType = existingRef.MasterID;
                            db.Update<DetailAccounts>(d, transaction: trx);
                        }
                        trx.Commit(); return true;
                    }
                    catch (Exception rx)
                    {
                        trx.Rollback();
                        return rx.ExcError("While Appending Reference Names....");
                    }
                }
            }
        }

        private bool CitiesCreated()
        {
            List<string> cities = data
   .Select(x => x.City?.Trim())
   .Where(x => !string.IsNullOrWhiteSpace(x))
   .Distinct()
   .ToList();
            var sb = new System.Text.StringBuilder();

            foreach (var title in cities)
            {
                string safeTitle = title.Replace("'", "''");
                sb.AppendLine($@"
IF NOT EXISTS (SELECT 1 FROM tblCity WHERE CityName = N'{safeTitle}')
    INSERT INTO tblCity (CityName, CityNameEnglish)
    VALUES (N'{safeTitle}', '');");
            }

            string sqlQuery = sb.ToString();
            using (var db = new db())
            {
                using (var trx = db.BeginTransaction())
                {
                    try
                    {
                        db.Execute(sqlQuery, transaction: trx);
                        trx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trx.Rollback();
                        return ex.ExcError("While Creating Cities....");
                    }
                }
            }
        }

        private bool DetailAccountsCreated()
        {
            using (var db = new db())
            {
                using (var Trx = db.BeginTransaction())
                {
                    try
                    {
                        foreach (var item in data)
                        {
                            if (string.IsNullOrWhiteSpace(item.AccountHead) || string.IsNullOrWhiteSpace(item.AccountName))
                                continue;
                            MasterAccounts master = db.GetList<MasterAccounts>($"WHERE AccountTitle = @AccountTitle", new { AccountTitle = item.AccountHead.Trim() }, transaction: Trx).FirstOrDefault();
                            if (master == null)
                            {
                                throw new Exception($"Master Account '{item.AccountHead}' not found. Please ensure all account heads are created before importing detail accounts.");
                            }
                            tblCity city = db.GetList<tblCity>($"WHERE CityName = @CityName", new { CityName = item.City.Trim() }, transaction: Trx).FirstOrDefault();
                            if (city == null)
                            {
                                throw new Exception($"City '{item.City}' not found. Please ensure all cities are created before importing detail accounts.");
                            }
                            string accountCode = DetailAccountService.GenerateNextAccountCode(master.ID, db, Trx);
                            var detailAccount = new DetailAccounts
                            {
                                AccountCode = accountCode.toInt(),
                                AccountTitle = item.AccountName,
                                Contact = item.Contact,
                                CityID = city.ID,
                                OpDebit = item.OpDebit,
                                OpCredit = item.opCredit,
                                Remarks = item.Remarks,
                                CreditLimit = item.CreditLimit,
                                Commission = item.Commission,
                                RefName = item.RefName,
                                MasterID = master.ID
                            };
                            db.Insert(detailAccount, transaction: Trx);
                        }
                        Trx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Trx.Rollback();
                        return ex.ExcError("While Creating Detail Accounts....");
                    }
                }
            }
        }

        private bool MasterAccountsCreated()
        {
            List<string> distinctAccountHeads = data
   .Select(x => x.AccountHead?.Trim())
   .Where(x => !string.IsNullOrWhiteSpace(x))
   .Distinct()
   .ToList();
            var sb = new System.Text.StringBuilder();

            foreach (var title in distinctAccountHeads)
            {
                string safeTitle = title.Replace("'", "''"); // Escape single quotes for SQL
                sb.AppendLine($@"
IF NOT EXISTS (SELECT 1 FROM MasterAccounts WHERE AccountTitle = N'{safeTitle}')
    INSERT INTO MasterAccounts (AccountTitle, AccountType, isSystem)
    VALUES (N'{safeTitle}', 'Assets', 1);");
            }

            string sqlQuery = sb.ToString();
            using (var db = new db())
            {
                using (var trx = db.BeginTransaction())
                {
                    try
                    {
                        db.Execute(sqlQuery, transaction: trx);
                        trx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        return ex.ExcError("While Creating Master Accounts....");
                    }
                }
            }
        }

        private bool TransactionsCleared()
        {
            using (var db = new db())
            {
                using (var trx = db.BeginTransaction())
                {
                    try
                    {
                        List<string> tables = new List<string>()
                        {
                            "BankCashAccounts","JVEntries","tblConfigs","tblSaleDetail","tblSale","VoucherBardanaDetails","VoucherDetails","Vouchers","DetailAccounts"
                        };
                        foreach (var table in tables)
                        {
                            db.Execute($"DELETE FROM {table}", transaction: trx);
                        }
                        trx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        return ex.ExcError("While Clearing Transations....");
                    }
                }
            }
        }
    }
}
