
CREATE OR ALTER   VIEW [dbo].[vw_BanamRokar]
AS

-- 1. VoucherType = 0 and Bank Account
SELECT 
    0 AS EntryID,
    acc.AccountTitle + ' ' + city.CityName AS AccountTitle,
    vd.Narration + ' =>'+ acc2.AccountTitle AS Narration,
    vd.Amount AS Amount,
    vm.VoucherDate AS EntryDate
FROM Vouchers vm
LEFT JOIN VoucherDetails vd ON vm.VoucherID = vd.VoucherID
LEFT JOIN DetailAccounts acc ON vd.PartyID = acc.ID
LEFT JOIN tblCity city ON acc.CityID = city.ID
LEFT JOIN DetailAccounts acc2 ON vd.CashAccountID = acc2.ID
WHERE vm.VoucherType = 0
  AND vd.CashAccountID IN (SELECT ID FROM vwBankAccounts)

UNION ALL

-- 2. VoucherType = 0 and Not in Bank Account
SELECT 
    0 AS EntryID,
    acc.AccountTitle + ' ' + city.CityName AS AccountTitle,
    vd.Narration,
    vd.Amount AS Amount,
    vm.VoucherDate AS EntryDate
FROM Vouchers vm
LEFT JOIN VoucherDetails vd ON vm.VoucherID = vd.VoucherID
LEFT JOIN DetailAccounts acc ON vd.PartyID = acc.ID
LEFT JOIN DetailAccounts acc2 ON vd.CashAccountID = acc2.ID
LEFT JOIN tblCity city ON acc.CityID = city.ID
WHERE vm.VoucherType = 0
  AND vd.CashAccountID NOT IN (SELECT ID FROM vwBankAccounts)

UNION ALL

-- 3. VoucherType = 1 and Bank Account
SELECT 
    0 AS EntryID,
    acc2.AccountTitle + ' ' + city.CityName AS AccountTitle,
    vd.Narration + ' =>'+ acc.AccountTitle AS Narration,
    vd.Amount AS Amount,
    vm.VoucherDate AS EntryDate
FROM Vouchers vm
LEFT JOIN VoucherDetails vd ON vm.VoucherID = vd.VoucherID
LEFT JOIN DetailAccounts acc ON vd.PartyID = acc.ID
LEFT JOIN DetailAccounts acc2 ON vd.CashAccountID = acc2.ID
LEFT JOIN tblCity city ON acc2.CityID = city.ID
WHERE vm.VoucherType = 1
  AND vd.CashAccountID IN (SELECT ID FROM vwBankAccounts)

UNION ALL

-- 4. Sale Debit Entries from JVEntries (MasterID = 4)
--SELECT 
--    sale.ArrivalNo AS EntryID,
--    acc.AccountTitle + ' ' + city.CityName AS AccountTitle,
--    Narration,
--    DebitAmount AS Amount,
--    sale.ArrivalDate AS EntryDate
--FROM tblSale sale
--LEFT JOIN tblSaleDetail detail ON sale.ID = detail.SaleID
--LEFT JOIN JVEntries jv ON sale.VoucherID = jv.VoucherID
--LEFT JOIN DetailAccounts acc ON jv.AccountID = acc.ID
--LEFT JOIN tblCity city ON acc.CityID = city.ID
--WHERE jv.DebitAmount <> 0
--  AND acc.MasterID = 4


SELECT 
    sale.ArrivalNo AS EntryID,
    acc.AccountTitle + ' ' + city.CityName AS AccountTitle,
    jv.Narration,
    jv.DebitAmount AS Amount,
    sale.ArrivalDate AS EntryDate
FROM tblSale sale
LEFT JOIN JVEntries jv ON sale.VoucherID = jv.VoucherID
LEFT JOIN DetailAccounts acc ON jv.AccountID = acc.ID
LEFT JOIN tblCity city ON acc.CityID = city.ID
WHERE jv.DebitAmount <> 0
  AND acc.MasterID = 4


UNION ALL

-- 5. Sale Narration based on Items (excluding نقد سیل)
SELECT 
    main.ArrivalNo AS EntryID,
    acc.AccountTitle + ' ' + city.CityName AS AccountTitle,
    ItemTitle + ' ' + 
    CAST(
        CASE 
            WHEN ItemUnit = 0 THEN CAST(FLOOR(ItemQty) AS NVARCHAR)
            ELSE CAST(FLOOR(ItemWeight) AS NVARCHAR)
        END AS NVARCHAR
    ) + '*' + CAST(FLOOR(CustomerRate) AS NVARCHAR) AS Narration,
    CustomerAmount + LagaAmount AS Amount,
    main.ArrivalDate AS EntryDate
FROM tblSale main
LEFT JOIN tblSaleDetail sdetail ON main.ID = sdetail.SaleID
LEFT JOIN tblItems ON sdetail.ItemID = tblItems.ID
LEFT JOIN DetailAccounts acc ON sdetail.PartyID = acc.ID
LEFT JOIN tblCity city ON acc.CityID = city.ID
WHERE acc.AccountTitle NOT LIKE N'نقد سیل';



