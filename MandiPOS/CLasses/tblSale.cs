using Dapper;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;

using static MandiPOS.SQL;
namespace MandiPOS.CLasses
{
    public class tblSale
    {
        [Key]

        public int ID { get; set; }

        public int ArrivalNo { get; set; }

        public DateTime ArrivalDate { get; set; }

        public int PartyID { get; set; }
        public string PartyTitle { get; set; }
        public string VehicleNo { get; set; }

        public decimal TotalQty { get; set; } = 0;

        public decimal SoldQty { get; set; } = 0;

        public decimal RemainingQty { get { return TotalQty - SoldQty; } }

        public decimal SaleAmount1 { get; set; } = 0;

        public decimal SaleAmount2 { get; set; } = 0;

        public decimal CommisionPerc { get; set; }

        public decimal CommissionAmount { get; set; }

        public decimal MazdooriPerc { get; set; }

        public decimal MazdooriAmount { get; set; } = 0;

        public decimal MunshianaPerc { get; set; }

        public decimal MunshianaAmount { get; set; } = 0;

        public decimal KarayaAmount { get; set; } = 0;

        public decimal PaidAmount { get; set; } = 0;

        public decimal StoreRent { get; set; } = 0;

        public DateTime? CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public int UpdatedBy { get; set; }

        public string CreationDevice { get; set; } = Environment.MachineName;

        public string UpdationDevice { get; set; } = Environment.MachineName;
        public int VoucherID { get; set; } = 0;
        public string Marka { get; set; }
        public DateTime? PrintTime { get; set; }

    }
    public class tblSaleDetail
    {
        [Key]
        public int ID { get; set; }

        public int? SaleID { get; set; }
        public int? ItemID { get; set; }
        public int PartyID { get; set; }
        public int ItemUnit { get; set; }
        private decimal _itemQty;
        public decimal ItemQty
        {
            get => _itemQty;
            set => _itemQty = Math.Round(value, 0);
        }

        private decimal _lagaRate;
        public decimal LagaRate
        {
            get => _lagaRate;
            set => _lagaRate = Math.Round(value, 0);
        }

        private decimal _lagaAmount;
        public decimal LagaAmount
        {
            get => _lagaAmount;
            set => _lagaAmount = Math.Round(value, 0);
        }

        private decimal _itemWeight;
        public decimal ItemWeight
        {
            get => _itemWeight;
            set => _itemWeight = Math.Round(value, 0);
        }

        private decimal _customerRate;
        public decimal CustomerRate
        {
            get => _customerRate;
            set => _customerRate = Math.Round(value, 0);
        }

        private decimal _customerAmount;
        public decimal CustomerAmount
        {
            get => _customerAmount;
            set => _customerAmount = Math.Round(value, 0);
        }

        private decimal _partyRate;
        public decimal ParyRate
        {
            get => _partyRate;
            set => _partyRate = Math.Round(value, 0);
        }

        private decimal _partyAmount;
        public decimal PartyAmount
        {
            get => _partyAmount;
            set => _partyAmount = Math.Round(value, 0);
        }

        public string Marka { get; set; }

        private decimal _mazdooriRate;
        public decimal MazdooriRate
        {
            get => _mazdooriRate;
            set => _mazdooriRate = Math.Round(value, 0);
        }
        public decimal MazdooriAmount
        {
            get => Math.Round(ItemQty * MazdooriRate, 0);
        }
    }

    public class vwSale1
    {
        [Key]

        public int ID { get; set; }

        [DisplayName("آمد نمبر")]
        public int ArrivalNo { get; set; }
        [DisplayName("تاریخ")]
        public DateTime ArrivalDate { get; set; }
        [DisplayName("بوپاری")]
        public string PartyTitle { get; set; }
        [DisplayName("آمد")]
        public decimal TotalQty { get; set; }
        [DisplayName("نکاس")]
        public decimal SoldQty { get; set; }
        [DisplayName("بقایا")]
        public decimal RemainingQty { get { return TotalQty - SoldQty; } }
        public int Printed { get; set; }

    }
    public class vwSale2
    {
        [Key]

        public int ID { get; set; }
        [DisplayName("اشیاء")]
        public string ItemTitle { get; set; }
        [DisplayName("تعداد")]
        public decimal ItemQty { get; set; }

    }
    public class vwSale3
    {
        [Key]
        [Browsable(false)]
        public int SaleID { get; set; }
        [Browsable(false)]
        public int ItemID { get; set; }
        [Browsable(false)]
        public decimal MazdooriRate { get; set; }
        [Browsable(false)]
        public decimal MazdooriAmount { get { return ItemQty * MazdooriRate; } }
        [DisplayName("اشیاء")]
        public string ItemTitle { get; set; }
        [Browsable(false)]
        public int PartyID { get; set; }
        [DisplayName("نام گاہک")]
        public string PartyTitle { get; set; }
        [DisplayName("لاگا")]
        public decimal LagaRate { get; set; }
        [DisplayName("رقم لاگا")]
        public decimal LagaAmount { get { return LagaRate * ItemQty; } }
        [DisplayName("تعداد")]
        public decimal ItemQty { get; set; }
        [Browsable(false)]
        public int ItemUnit { get; set; }
        [DisplayName("یونٹ")]
        public string UnitTitle
        {
            get
            {
                switch (ItemUnit)
                {
                    case 1: return "کلو";
                    case 2: return "من";
                    case 0: return "تعداد";
                    case -1: return "";
                    default: return "";
                }
            }
        }
        [DisplayName("وزن")]
        public decimal ItemWeight { get; set; }
        [DisplayName("گاہک ریٹ")]
        public decimal CustomerRate { get; set; }
        [DisplayName("رقم گاہک")]
        public decimal CustomerAmount { get; set; }
        [DisplayName("بیوپاری ریٹ")]
        public decimal ParyRate { get; set; }
        [DisplayName("رقم بیوپاری")]
        public decimal PartyAmount { get; set; }
        [DisplayName("مارکہ")]
        public string Marka { get; set; }

    }
    public static class SaleService
    {

        public static int CreateNewSale(int PartyID, DateTime saleDate, int SaleNo)
        {
            tblSale sale = new tblSale()
            {
                ArrivalDate = saleDate,
                ArrivalNo = SaleNo,
                CreatedBy = General.CurrentUserID,
                CreatedOn = DateTime.Now,
                CreationDevice = Environment.MachineName,
                ID = 0,
                PartyID = PartyID,
                KarayaAmount = 0,
                MazdooriAmount = 0,
                MunshianaAmount = 0,
                SaleAmount1 = 0,
                SaleAmount2 = 0,
                StoreRent = 0,
                PaidAmount = 0,
                TotalQty = 0,
                SoldQty = 0
            };
            using (db db = new db())
            {
                db.Insert<tblSale>(sale);
                return sale.ID;
            }
        }

        internal static tblSale GetSaleByID(int iD, ref object bsCart, ref object bsSummry)
        {
            using (var db = new db())
            {
                tblSale sale = db.Get<tblSale>(iD) ?? new tblSale();
                if (sale.ID == 0)
                {
                    sale.ArrivalNo = SQL.GetNextArrivalNo().toInt();
                    sale.ArrivalDate = DateTime.Now.Date;
                }
                bsCart = db.Query<vwSale3>($"Select * from vwSale3 Where SaleID={iD}").ToList();
                return sale;
            }
        }
        internal static tblSale GetSaleByArrivalNo(int iD, ref object cart, ref object bsSummry)
        {
            using (var db = new db())
            {
                tblSale sale = db.Query<tblSale>($"Select Top 1 * from tblSale Where ArrivalNo='{iD}'").FirstOrDefault() ?? new tblSale();
                if (sale.ID == 0)
                {
                    sale.ArrivalNo = SQL.GetNextArrivalNo().toInt();
                    sale.ArrivalDate = DateTime.Now.Date;

                }
                cart = db.Query<vwSale3>($"Select * from vwSale3 Where SaleID={sale.ID}").ToList();
                return sale;
            }
        }

        internal static List<vwSale1> GetviewSale1(DateTime date1, DateTime date2, string v)
        {
            string whereClause = $"Where ArrivalDate Between '{date1:yyyy-MM-dd}' and '{date2:yyyy-MM-dd}'";
            if (!string.IsNullOrEmpty(v))
            {
                whereClause += $" and PartyTitle Like N'%{v}%'";
            }
            return new db().Query<vwSale1>($"Select * from vwSale1 {whereClause}").ToList();
        }

        public static bool RepostSales(waitForm frm)
        {
            try
            {
                using (var db = new db())
                {
                    using (var trx = db.BeginTransaction())
                    {
                        var sales = db.Query<tblSale>("Select * from tblSale", transaction: trx).ToList();
                        if (sales.Count == 0)
                        {
                            return true;
                        }
                        int count = sales.Count;
                        int progress = 1;
                        int running = 1;
                        foreach (var sale in sales)
                        {
                            progress = (running / count) * 100;
                            frm.UpdateStatus($"{running} of {count}", $"Processing Sale No: {sale.ArrivalNo}");
                            var saleDetails = db.Query<tblSaleDetail>($"Select * from tblSaleDetail Where SaleID={sale.ID}", transaction: trx).ToList();
                            int voucherID = 0;
                            PostAccountEntries(sale, saleDetails, db, trx, ref voucherID);
                            sale.VoucherID = voucherID;
                            db.Update<tblSale>(sale, transaction: trx);
                            running++;
                            Application.DoEvents();
                        }
                        trx.Commit();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.ExcError("While Re-Posting Sales....");
            }

        }


        internal static bool SaveSale(tblSale sale, List<tblSaleDetail> saleDetails)
        {
            using (var bd = new db())
            {
                using (var trx = bd.BeginTransaction())
                {
                    try
                    {
                        int voucherID = 0;
                        if (sale.ID == 0)
                        {
                            string sql = "select isnull(max([ArrivalNo]),0)+1 from [tblSale]";
                            sale.ArrivalNo = bd.ExecuteScalar<string>(sql, transaction: trx).toInt();
                        }
                        if (sale.ID != 0)
                        {

                            voucherID = sale.VoucherID;
                        }
                        PostAccountEntries(sale, saleDetails, bd, trx, ref voucherID);
                        sale.VoucherID = voucherID;
                        if (sale.ID == 0)
                        {
                            sale.CreatedBy = General.CurrentUserID;
                            sale.CreatedOn = DateTime.Now;
                            sale.CreationDevice = Environment.MachineName;
                            sale.VoucherID = voucherID;
                            bd.Insert<tblSale>(sale, transaction: trx);
                        }
                        else
                        {
                            sale.UpdatedBy = General.CurrentUserID;
                            sale.UpdatedOn = DateTime.Now;
                            sale.UpdationDevice = Environment.MachineName;
                            bd.Update<tblSale>(sale, transaction: trx);
                        }
                        bd.Execute($"Delete from tblSaleDetail Where SaleID={sale.ID}", transaction: trx);
                        foreach (tblSaleDetail detail in saleDetails)
                        {
                            detail.SaleID = sale.ID;
                            bd.Insert<tblSaleDetail>(detail, transaction: trx);
                        }


                        trx.Commit(); return true;

                    }
                    catch (Exception ex)
                    {
                        trx.Rollback();
                        return ex.ExcError("While Saving Sale Details");
                    }
                }
            }
        }

        private static void PostAccountEntries(tblSale sale, List<tblSaleDetail> saleDetails, db connecion, System.Data.IDbTransaction trx, ref int voucherID)
        {

            string partyNarration = "";
            List<string> items = new List<string>();
            var result = saleDetails
                .GroupBy(s => new { s.ItemID })
                .Select(g => new
                {
                    ItemID = g.Key.ItemID,
                    TotalQuantity = g.Sum(x => x.ItemQty),
                    TotalWeight = g.Sum(x => x.ItemWeight)
                })
                .ToList();

            foreach (var record in result)
            {
                var item = connecion.Get<tblItems>(record.ItemID, transaction: trx);
                string itemText = $"{item.ItemTitle} {(record.TotalQuantity != 0 ? record.TotalQuantity.ToString("N0") : record.TotalWeight.ToString("N0"))} نگ";
                items.Add(itemText);
            }

            partyNarration = "بکری ";
            partyNarration = partyNarration + string.Join(", ", items);


            Vouchers main = new Vouchers();
            if (sale.VoucherID == 0)
            {
                main = new Vouchers()
                {
                    VoucherNo = connecion.ExecuteScalar<int>("Select Max(ISNULL(VoucherNo,0))+1 as nextNo from Vouchers", transaction: trx),
                    VoucherType = 4,
                    VoucherDate = sale.ArrivalDate
                };
                connecion.Insert<Vouchers>(main, transaction: trx);
            }
            else
            {
                main = connecion.Get<Vouchers>(sale.VoucherID, transaction: trx);
                main.VoucherDate = sale.ArrivalDate;
                connecion.Update<Vouchers>(main, transaction: trx);

            }
            connecion.Execute($"Delete from VoucherDetails Where VoucherID='{main.VoucherID}'", transaction: trx);
            connecion.Execute($"Delete from JVEntries Where VoucherID='{main.VoucherID}'", transaction: trx);
            connecion.Execute($"Delete from VoucherBardanaDetails Where VoucherID='{main.VoucherID}'", transaction: trx);
            List<JVEntries> details = new List<JVEntries>();
            //Post to Vendor
            if (sale.SaleAmount2 != 0)
            {

                decimal remainingAmoun = sale.SaleAmount2 - sale.KarayaAmount
                    - sale.MazdooriAmount - sale.MunshianaAmount - sale.CommissionAmount - sale.StoreRent - sale.PaidAmount;
                decimal debit = 0;
                decimal credit = 0;
                if (remainingAmoun > 0)
                {
                    credit = remainingAmoun;
                    debit = 0;

                }
                else if (remainingAmoun < 0)
                {
                    debit = Math.Abs(remainingAmoun);
                    credit = 0;
                }

                if (debit != 0 || credit != 0)
                {
                    JVEntries jv = new JVEntries()
                    {
                        VoucherID = main.VoucherID,
                        AccountID = sale.PartyID,
                        CreditAmount = credit,
                        DebitAmount = debit,
                        Narration = $"{partyNarration}"
                    };
                    details.Add(jv);
                }

            }



            //Paid Amount
            if (sale.PaidAmount != 0)
            {
                JVEntries jv = new JVEntries()
                {
                    VoucherID = main.VoucherID,
                    AccountID = General.NetPaidAccount,
                    CreditAmount = sale.PaidAmount,
                    DebitAmount = 0,
                    Narration = $"نقد ادا آمد نمبر {sale.ArrivalNo}"
                };
                details.Add(jv);
            }
            //Sale Difference
            if (sale.SaleAmount1 != sale.SaleAmount2)
            {
                var diff = sale.SaleAmount1 - sale.SaleAmount2;
                if (diff > 0)
                {
                    JVEntries jv = new JVEntries()
                    {
                        VoucherID = main.VoucherID,
                        AccountID = General.PendingSaleAccount,
                        CreditAmount = Math.Abs(diff),
                        DebitAmount = 0,
                        Narration = $"بقایا سیل آمد نمبر {sale.ArrivalNo}"
                    };
                    details.Add(jv);
                }
                else
                {
                    JVEntries jv = new JVEntries()
                    {
                        VoucherID = main.VoucherID,
                        AccountID = General.PendingSaleAccount,
                        DebitAmount = Math.Abs(diff),
                        CreditAmount = 0,
                        Narration = $"بقایا سیل آمد نمبر {sale.ArrivalNo}"
                    };
                    details.Add(jv);
                }
            }
            //commission
            if (sale.CommissionAmount != 0)
            {

                JVEntries jv = new JVEntries()
                {
                    VoucherID = main.VoucherID,
                    AccountID = General.CommissionAccount,
                    CreditAmount = sale.CommissionAmount,
                    DebitAmount = 0,
                    Narration = $"کمیشن رقم آمد نمبر {sale.ArrivalNo}"
                };
                details.Add(jv);
            }
            //mazdoori
            if (sale.MazdooriAmount != 0)
            {
                JVEntries jv = new JVEntries()
                {
                    VoucherID = main.VoucherID,
                    AccountID = General.MazdooriAccount,
                    CreditAmount = sale.MazdooriAmount,
                    DebitAmount = 0,
                    Narration = $"مزدوری رقم آمد نمبر {sale.ArrivalNo}"
                };
                details.Add(jv);
            }
            //munshiana
            if (sale.MunshianaAmount != 0)
            {
                JVEntries jv = new JVEntries()
                {
                    VoucherID = main.VoucherID,
                    AccountID = General.MunshianaAccount,
                    CreditAmount = sale.MunshianaAmount,
                    DebitAmount = 0,
                    Narration = $"منشیانہ رقم آمد نمبر {sale.ArrivalNo}"
                };
                details.Add(jv);
            }
            //karaya
            if (sale.KarayaAmount != 0)
            {
                JVEntries jv = new JVEntries()
                {
                    VoucherID = main.VoucherID,
                    AccountID = General.KarayaAccount,
                    CreditAmount = sale.KarayaAmount,
                    DebitAmount = 0,
                    Narration = $"کرایہ رقم آمد نمبر {sale.ArrivalNo}"
                };
                details.Add(jv);
            }
            //store
            if (sale.StoreRent != 0)
            {
                JVEntries jv = new JVEntries()
                {
                    VoucherID = main.VoucherID,
                    AccountID = General.StoreAccount,
                    CreditAmount = sale.StoreRent,
                    DebitAmount = 0,
                    Narration = $"سٹور کرایہ آمد نمبر {sale.ArrivalNo}"
                };
                details.Add(jv);
            }


            if (saleDetails.Count > 0)
            {
                foreach (tblSaleDetail record in saleDetails)
                {
                    tblItems items1 = connecion.Get<tblItems>(record.ItemID, transaction: trx);

                    JVEntries jv = new JVEntries()
                    {
                        VoucherID = main.VoucherID,
                        AccountID = (int)record.PartyID,
                        CreditAmount = 0,
                        DebitAmount = record.CustomerAmount + record.LagaAmount,
                        Narration = $"{items1.ItemTitle} {record.CustomerRate:N0}/{record.ItemQty:N0} => {(record.ItemWeight == 0 ? string.Empty : ($"{record.ItemWeight:N0} {(record.ItemUnit == 1 ? "کلو" : "من")}"))}"
                    }; details.Add(jv);
                }
                decimal laga_amount = saleDetails.Sum(x => x.LagaAmount).toDecimal();
                if (laga_amount != 0)
                {
                    JVEntries jv = new JVEntries()
                    {
                        VoucherID = main.VoucherID,
                        AccountID = General.LagaAccount,
                        CreditAmount = laga_amount,
                        DebitAmount = 0,
                        Narration = $"لاگا آمد {sale.ArrivalNo}"
                    }; details.Add(jv);
                }
            }

            if (details.Any())
            {
                foreach (JVEntries jv in details)
                {
                    connecion.Insert<JVEntries>(jv, transaction: trx);
                }
            }


            voucherID = main.VoucherID;

        }

        internal static int GetMaxSaleNo()
        {
            return new db().ExecuteScalar<int>("Select Max(coalesce(ArrivalNo,0))+1 from tblsale");
        }
    }
}
