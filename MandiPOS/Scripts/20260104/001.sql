
ALTER         VIEW [dbo].[vw_JamaRokar]
AS

-- 1. Bank Credits from vw_BankEntries
SELECT 
    0 AS EntryID,
    AccountTitle,
    Narration,
    CreditAmount AS Amount,
    VoucherDate  AS EntryDate, Vno,MasterID, 777 as SortOrder
FROM vwTrx
WHERE 
   CreditAmount <> 0
  AND AccountID IN (SELECT ID FROM vwBankAccounts) and VoucherType<>2

UNION ALL

-- 2. VoucherType = 1, Non-Bank Credit Entries from vwTrx
SELECT 
    0 AS EntryID,
    AccountTitle,
    Narration,
    CreditAmount AS Amount,
    VoucherDate  AS EntryDate, Vno,MasterID, Case MasterID When 4 Then 666 WHen 6 Then 555 When 7 Then 444 Else MasterID End as SortOrder
FROM vwTrx
WHERE VoucherType = 1
  AND CreditAmount <> 0
  AND AccountID NOT IN (SELECT ID FROM vwBankAccounts)

UNION ALL

-- 3. Credit to Customers (MasterID = 2)
Select 0 as EntryID,AccountTitle,'', Sum(Amount) Amount,
EntryDate,0 as Vno, MasterID, 888 as SortOrder
From (
SELECT 
    
    AccountTitle,
    
    SUM(CreditAmount) AS Amount,
    VoucherDate AS EntryDate, MasterID
FROM vwTrx
WHERE CreditAmount <> 0
  AND AccountID IN (SELECT ID FROM DetailAccounts WHERE MasterID = 2)
GROUP BY VoucherDate,MasterID,AccountTitle,Vno) tbl
Group by EntryDate,AccountTitle,MasterID

UNION ALL

-- 4. VoucherType = 4 Credit Entries with MasterAccount = 'Customer'
SELECT 
    BillNo AS EntryID,
    AccountTitle,
    Narration,
    CreditAmount AS Amount,
    VoucherDate AS EntryDate, Vno,MasterID, 999 as SortOrder
FROM vwTrx
WHERE VoucherType = 4
  AND CreditAmount <> 0
  AND MasterAccount IN (SELECT AccountTitle FROM MasterAccounts WHERE ID = 4)
  
  Union ALL
Select Vno, acc.AccountTitle,ItemDescription,CreditAmount,VoucherDate,Vno,acc.MasterID,9999 as SortOrder

from vwTrx 
left join DetailAccounts acc on vwTrx.AccountID=acc.ID
where Vouchertype in (3,5) and CreditAmount<>0 ;
GO


