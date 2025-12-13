using Dapper;

using DevExpress.XtraEditors;

using Janus.Data;

using MandiPOS.CLasses;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MandiPOS
{




    public static class SQL
    {
        public static int LastArrivalNo { 
            get 
            {
                try
                {
                    string sql = "select isnull(max([ArrivalNo]),0) from [tblSale]";
                    using (var xdb = new db())
                    {
                        return xdb.ExecuteScalar<int>(sql);
                    }
                }
                catch
                {
                    return 0;
                }
            } }

        internal static bool DeleteCity(int iD)
        {
            try
            {
                using (var xdb = new db())
                {
                    var data = xdb.Delete<tblCity>(iD);
                    return data;
                }
            }
            catch (Exception ex)
            {
                ex.ExcError("Deleting City...");
                return false;
            }
        }

        internal static bool DeleteItem(int v)
        {
            try
            {
                using (var xdb = new db())
                {
                    var data = xdb.Delete<tblItems>(v);
                    return data;
                }
            }
            catch (Exception ex)
            {
                ex.ExcError("Deleting Item...");
                return false;
            }
        }

        internal static void FillCombo(LookUpEdit control, object itemTypes, string valueMember, string displayMember)
        {
            control.Properties.DataSource = itemTypes;
            control.Properties.DisplayMember = displayMember;
            control.Properties.ValueMember = valueMember;
            if (control.Properties.DataSource != null)
            {
                control.ItemIndex = 0;
            }
        }
        public static int NetSaleAccount
        {
            get
            {
                string sql = "SELECT dbo.fn_GetNetSaleAccount()";
               return new db().ExecuteScalar<int>(sql);
            }
        }

        internal static List<tblItems> GetAllItems(string searchTerm = "")
        {
            try
            {
                using (var xdb = new db())
                {
                    var data = xdb.GetList<tblItems>(searchTerm).ToList();
                    return data;
                }
            }
            catch (Exception ex)
            {
                ex.ExcError("Getting Items...");
                return default;
            }
        }


        internal static List<tblCity> GetCities()
        {
            try
            {
                using (var xdb = new db())
                {
                    var data = xdb.GetList<tblCity>().ToList();
                    return data;
                }
            }
            catch (Exception ex)
            {

                ex.ExcError("while Getting Cities");
                return default;
            }
        }
        internal static tblCity GetCity(string whercondition="")
        {
            try
            {
                using (var xdb = new db())
                {
                    var data = xdb.Query<tblCity>($"Select * from tblCity {whercondition}").FirstOrDefault();
                    return data;
                }
            }
            catch (Exception ex)
            {

                ex.ExcError("while Getting Cities");
                return default;
            }
        }





        internal static void SetDefaultAccount()
        {
            var data = new db().GetList<tblConfigs>();
            foreach (tblConfigs c in data)
            {
                switch (c.ConfigName.ToLower())
                {
                    case "commission": General.CommissionAccount = c.ConfigValue.toInt(); break;
                    case "karaya": General.KarayaAccount = c.ConfigValue.toInt(); break;
                    case "mazdoori": General.MazdooriAccount = c.ConfigValue.toInt(); break;
                    case "munshiana": General.MunshianaAccount = c.ConfigValue.toInt(); break;
                    case "netpaid": General.NetPaidAccount = c.ConfigValue.toInt(); break;
                    case "pendingsale": General.PendingSaleAccount = c.ConfigValue.toInt(); break;
                    case "store": General.StoreAccount = c.ConfigValue.toInt(); break;
                    case "laga": General.LagaAccount = c.ConfigValue.toInt(); break;
                }
            }
        }
        internal static bool CheckDefaultAccounts(ref string message)
        {
            if (General.CommissionAccount == 0)
            {
                message = "کمیشن اکاؤنٹ منتخب کریں";
                return false;
            }
            if (General.KarayaAccount == 0)
            {
                message = "کرایہ اکاؤنٹ منتخب کریں";
                return false;
            }
            if (General.MazdooriAccount == 0)
            {
                message = "مزدوری اکاؤنٹ منتخب کریں";
                return false;
            }
            if (General.MunshianaAccount == 0)
            {
                message = "منشیانہ اکاؤنٹ منتخب کریں";
                return false;
            }
            if (General.NetPaidAccount == 0)
            {
                message = "نقد ادا اکاؤنٹ منتخب کریں";
                return false;
            }
            if (General.PendingSaleAccount == 0)
            {
                message = "بقایا اکاؤنٹ منتخب کریں";
                return false;
            }
            if (General.StoreAccount == 0)
            {
                message = "سٹور کرایہ اکاؤنٹ منتخب کریں";
                return false;
            }
            if (General.LagaAccount == 0)
            {
                message = "لاگا اکاؤنٹ منتخب کریں";
                return false;
            }
            return true;
        }

        internal static DetailAccounts GetDetailsAccountByID(object AccountID)
        {
            return new db().Get<DetailAccounts>(AccountID);
        }

        internal static List<DetailAccounts> GetDetailsAccounts(int masterAccountID)
        {
            using (var connection = new db())
            {
                return connection.GetList<DetailAccounts>($" where MasterID={masterAccountID}").ToList();
            }
        }

        internal static int GetNewCode(IDbConnection conn = null)
        {
            bool isNewConnection = false;
            if (conn == null) { conn = new db(); isNewConnection = true; }
            string sql = "select isnull(max([code]),0)+1 from [tblitems]";
            var data = conn.ExecuteScalar<int>(sql);
            if (isNewConnection)
            {
                conn.Close();
                conn.Dispose();
            }
            return data;
        }

        internal static string GetNextArrivalNo()
        {
            using (var db = new db())
            {
                string sql = "select isnull(max([ArrivalNo]),0)+1 from [tblSale]";
                return db.ExecuteScalar<string>(sql);
            }
        }

        internal static bool SaveCity(tblCity city)
        {
            try
            {
                using (var xdb = new db())
                {
                    if (city.ID == 0)
                    {
                        xdb.Insert<tblCity>(city);
                    }
                    else
                    {
                        xdb.Update(city);
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                ex.ExcError("Saving City...");
                return false;
            }
        }

        internal static bool SaveItem(tblItems item)
        {
            try
            {
                using (var xdb = new db())
                {
                    var xItem = xdb.GetList<tblItems>($" where itemTitle like N'{item.ItemTitle}' and ID<>{item.ID}").FirstOrDefault();
                    if (xItem != null)
                    {
                        throw new Exception("یہ اشیاء پہلے ہی موجود ہے۔");
                    }
                    if (item.ID == 0)
                    {
                        item.Code = GetNewCode(xdb);
                        xdb.Insert<tblItems>(item);
                    }
                    else
                    {
                        xdb.Update(item);
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void PrintBillByNo(string billNo)
        {
            throw new NotImplementedException();
        }

        internal static void GetStats(DateTime date, ref decimal banam, ref decimal jama, ref decimal income)
        {
            using (var db = new db())
            {
                (DateTime VoucherDate, decimal TotalBanam, decimal TotalJama) data = db.Query<(DateTime VoucherDate, decimal TotalBanam, decimal TotalJama)>(
    $"SELECT * FROM dbo.ufn_GetVoucherSummaryByDate('{date:yyyy-MM-dd}')").FirstOrDefault();
                if (data != default)
                {
                    banam = data.TotalBanam;
                    jama = data.TotalJama;
                }
               income= db.ExecuteScalar<decimal>($"SELECT dbo.ufn_GetCommissionLagaMazdooriMunshianaPendingSale('{date:yyyy-MM-dd}') AS Amount");
            }
        }

        internal static bool IsDateAssigned(DateTime date, int vType)
        {
            try
            {
                string Sql = "Select count(*) from Vouchers where VoucherDate=@date and VoucherType=@vType";
                return new db().ExecuteScalar<int>(Sql, new { date = date.Date, vType }) > 0;
            }
            catch (Exception ex)
            {
                ex.ExcError();
                return true;
            }
        }

        internal static void ChangeVoucherDate(int vID, DateTime date)
        {
            try
            {
                string sql = "Update Vouchers set VoucherDate=@date where VoucherID=@vID";
                new db().Execute(sql, new { date = date.Date, vID });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static object GetNextVoucherNo(int vType)
        {
            return new db().ExecuteScalar<object>($"Select ISNULL(MAx(VoucherNo),0)+1 from Vouchers Where VoucherType="+vType);
        }
    }



    public class db : IDbConnection
    {
        private readonly SqlConnection _connection;
        public db()
        {
            _connection = new SqlConnection(Program.MainConnectionstring);
            _connection.Open();
        }

        public string ConnectionString
        {
            get => _connection.ConnectionString;
            set => _connection.ConnectionString = value;
        }

        public int ConnectionTimeout => _connection.ConnectionTimeout;
        public string Database => _connection.Database;
        public ConnectionState State => _connection.State;

        public IDbTransaction BeginTransaction() => _connection.BeginTransaction();
        public IDbTransaction BeginTransaction(IsolationLevel il) => _connection.BeginTransaction(il);
        public void ChangeDatabase(string databaseName) => _connection.ChangeDatabase(databaseName);
        public void Close() => _connection.Close();
        public IDbCommand CreateCommand() => _connection.CreateCommand();
        public void Open()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
        }
        public void Dispose() => _connection.Dispose();

        internal long GetNextAccountCode()
        {
            throw new NotImplementedException();
        }
    }


}
