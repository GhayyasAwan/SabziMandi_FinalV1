
ALTER     VIEW [dbo].[vw_JamaRokar]
AS

-- 1. Bank Credits from vw_BankEntries
SELECT 
    BillNo AS EntryID,
    AccountTitle,
    Narration,
    SUM(CreditAmount) AS Amount,
    VoucherDate AS EntryDate
FROM vw_BankEntries
WHERE CreditAmount <> 0
  AND AccountID IN (SELECT ID FROM vwBankAccounts)
GROUP BY AccountTitle, Narration, VoucherDate, Billno

UNION ALL

-- 2. VoucherType = 1, Non-Bank Credit Entries from vwTrx
SELECT 
    BillNo AS EntryID,
    AccountTitle,
    Narration,
    SUM(CreditAmount) AS Amount,
    VoucherDate AS EntryDate
FROM vwTrx
WHERE VoucherType = 1
  AND CreditAmount <> 0
  AND AccountID NOT IN (SELECT ID FROM vwBankAccounts)
GROUP BY AccountTitle, Narration, VoucherDate,BillNo

UNION ALL

-- 3. Credit to Customers (MasterID = 2)
SELECT 
    BillNo AS EntryID,
    AccountTitle,
    '' AS Narration,
    SUM(CreditAmount) AS Amount,
    VoucherDate AS EntryDate
FROM vwTrx
WHERE CreditAmount <> 0
  AND AccountID IN (SELECT ID FROM DetailAccounts WHERE MasterID = 2)
GROUP BY AccountTitle, VoucherDate,BillNo

UNION ALL

-- 4. VoucherType = 4 Credit Entries with MasterAccount = 'Customer'
SELECT 
    BillNo AS EntryID,
    AccountTitle,
    Narration,
    CreditAmount AS Amount,
    VoucherDate AS EntryDate
FROM vwTrx
WHERE VoucherType = 4
  AND CreditAmount <> 0
  AND MasterAccount IN (SELECT AccountTitle FROM MasterAccounts WHERE ID = 4)

  union all

  Select vm.VoucherNo as 'EntryID',acc.AccountTitle,vd.Narration+N' '+vd.ItemDescription,
vd.CreditAmount as Amount,vm.VoucherDate as 'EntryDate'
from Vouchers vm
left join VoucherBardanaDetails vd on vm.VoucherID=vd.VoucherID
left join DetailAccounts acc on vd.AccountID=acc.ID
Where vm.VoucherType in (3,5) and vd.CreditAmount<>0
GO


