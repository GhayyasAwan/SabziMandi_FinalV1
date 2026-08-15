

	If Object_Id('dbo.vwTrx') is not null
Begin
DROP VIEW dbo.vwTrx
	End



GO

CREATE VIEW dbo.vwTrx AS

Select tbl.*,MasterAccounts.AccountTitle as 'MasterAccount',DetailAccounts.AccountTitle+' '+tblCity.CityName as 'AccountTitle' from 
(
--Opening Entries
SELECT 0 as DetailID,
    0 VoucherID,
    '2025-01-01' AS VoucherDate,
    '-1' AS VoucherType,
    ID AS AccountID,
    N'سابقہ' AS Narration, 0 as VoucherNo,
    OpDebit AS DebitAmount,
    OpCredit AS CreditAmount,
    0 AS ItemID,
    0 AS ItemQty,
    0 AS ItemRate,
    '' AS ItemDescription  ,'' as BillNo                           
FROM 
    [DetailAccounts]
Where OpDebit<>0 or OpCredit<>0


    UNION ALL

-- 🔹 VoucherDetails - Debit entry
SELECT vd.EntryID as DetailID,
    V.VoucherID,
    V.VoucherDate,
    V.VoucherType,
    CASE
        WHEN V.VoucherType = 0 THEN VD.PartyID
        WHEN V.VoucherType = 1 THEN VD.CashAccountID
    END AS AccountID,
    VD.Narration,  VoucherNo,
    ISNULL(VD.Amount,0) AS DebitAmount,
    CAST(0 AS DECIMAL(18, 2)) AS CreditAmount,
    CAST(0 AS INT) AS ItemID,
    CAST(0 AS DECIMAL(18, 2)) AS ItemQty,
    CAST(0 AS DECIMAL(18, 2)) AS ItemRate,
    CAST('' AS VARCHAR(200)) AS ItemDescription, v.VoucherNo as BillNo
FROM Vouchers V
JOIN VoucherDetails VD ON V.VoucherID = VD.VoucherID
WHERE V.VoucherType IN (0, 1)

UNION ALL

-- 🔹 VoucherDetails - Credit entry
Select Top 100 PERCENT * From ( SELECT vd.EntryID as DetailID,
    V.VoucherID,
    V.VoucherDate,
    V.VoucherType,
    CASE 
        WHEN V.VoucherType = 0 THEN VD.CashAccountID
        WHEN V.VoucherType = 1 THEN VD.PartyID
    END AS AccountID,
    VD.Narration,  VoucherNo,
    CAST(0 AS DECIMAL(18, 2)) AS DebitAmount,
    ISNULL(VD.Amount, 0) AS CreditAmount,
    CAST(0 AS INT) AS ItemID,
    CAST(0 AS DECIMAL(18, 2)) AS ItemQty,
    CAST(0 AS DECIMAL(18, 2)) AS ItemRate,
    CAST('' AS VARCHAR(200)) AS ItemDescription, v.VoucherNo as BillNo
FROM Vouchers V
JOIN VoucherDetails VD ON V.VoucherID = VD.VoucherID
WHERE V.VoucherType IN (0, 1)	) tbl order by DetailID

UNION ALL

-- 🔹 VoucherBardanaDetails (VoucherType 3)
Select Top 100 PERCENT * from (
SELECT VB.ID as DetailID,
    V.VoucherID,
    V.VoucherDate,
    V.VoucherType,
    VB.AccountID,
    VB.Narration,  VoucherNo,
    ISNULL(VB.DebitAmount, 0)  DebitAmount,
    ISNULL(VB.CreditAmount, 0) CreditAmount,
    VB.ItemID,
    VB.ItemQty,
    VB.ItemRate,
    VB.ItemDescription,'' as BillNo
FROM Vouchers V
JOIN VoucherBardanaDetails VB ON V.VoucherID = VB.VoucherID
WHERE V.VoucherType in (3,5) ) tbl2 Order by DetailID

UNION ALL

-- 🔹 JVEntries (VoucherType 2, 4)
Select Top 100 Percent * from (
SELECT JV.ID as DetailID,
    V.VoucherID,
    V.VoucherDate,
    V.VoucherType,
    JV.AccountID,
    JV.Narration,
               VoucherNo,
    ISNULL(JV.DebitAmount, 0)DebitAmount,
    ISNULL(JV.CreditAmount, 0)CreditAmount,
    CAST(0 AS INT) AS ItemID,
    CAST(0 AS DECIMAL(18, 2)) AS ItemQty,
    CAST(0 AS DECIMAL(18, 2)) AS ItemRate,
    CAST('' AS VARCHAR(200)) AS ItemDescription, ISNULL(CAST(tblsale.ArrivalNo AS NVARCHAR), '') as BillNo
FROM Vouchers V
JOIN JVEntries JV ON V.VoucherID = JV.VoucherID
left join tblSale on v.VoucherID=tblsale.VoucherID
WHERE V.VoucherType IN (2, 4)) tbl3 Order by DetailID
) tbl left join DetailAccounts on tbl.AccountID=DetailAccounts.ID
left join MasterAccounts on DetailAccounts.MasterID=MasterAccounts.ID
left join tblCity on DetailAccounts.CityID=tblCity.id 
GO


ALTER VIEW dbo.vw_JamaRokar
AS

-- 1. 
SELECT 
    BillNo AS EntryID,
    AccountTitle,
    Narration,
    SUM(CreditAmount) AS Amount,
    VoucherDate AS EntryDate, 111 as SortOrder
FROM VwTrx
WHERE VoucherID in (Select Distinct VoucherID from vwTrx Where AccountID in (Select ID from DetailAccounts Where MasterID=3)) and CreditAmount <> 0
  AND AccountID IN (SELECT ID FROM vwBankAccounts)
GROUP BY Billno, AccountTitle, Narration, VoucherDate

UNION ALL

-- 2. VoucherType = 1, Non-Bank Credit Entries from vwTrx


SELECT Top 100 Percent
    BillNo AS EntryID,
    AccountTitle,
    Narration,
    SUM(CreditAmount) AS Amount,
    VoucherDate AS EntryDate,222 as SortOrder
FROM vwTrx
WHERE VoucherType = 1
  AND CreditAmount <> 0
  AND AccountID NOT IN (SELECT ID FROM vwBankAccounts)
GROUP BY AccountTitle, Narration, VoucherDate,BillNo,DetailID
	Order BY vwTrx.DetailID

UNION ALL

-- 3. Credit to Customers (MasterID = 2)
SELECT 
    0 AS EntryID,
    AccountTitle,
    '' AS Narration,
    SUM(CreditAmount) AS Amount,
    VoucherDate AS EntryDate	,333 as SortOrder
FROM vwTrx
WHERE CreditAmount <> 0
  AND AccountID IN (SELECT ID FROM DetailAccounts WHERE MasterID = 2)
  AND VoucherType=4
GROUP BY AccountTitle, VoucherDate

UNION ALL

-- 4. VoucherType = 4 Credit Entries with MasterAccount = 'Customer'
Select Top 100 Percent *,333 as SortOrder FROM ( SELECT 
    BillNo AS EntryID,
    AccountTitle,
    Narration,
    CreditAmount AS Amount,
    VoucherDate AS EntryDate
FROM vwTrx
WHERE VoucherType = 4
  AND CreditAmount <> 0
  AND MasterAccount IN (SELECT AccountTitle FROM MasterAccounts WHERE ID = 4)) tbl Order By EntryID

  union all

  Select vm.VoucherNo as 'EntryID',acc.AccountTitle,vd.Narration+N' '+vd.ItemDescription,
vd.CreditAmount as Amount,vm.VoucherDate as 'EntryDate',444 as SortOrder
from Vouchers vm
left join VoucherBardanaDetails vd on vm.VoucherID=vd.VoucherID
left join DetailAccounts acc on vd.AccountID=acc.ID
Where vm.VoucherType in (3,5) and vd.CreditAmount<>0
GO
