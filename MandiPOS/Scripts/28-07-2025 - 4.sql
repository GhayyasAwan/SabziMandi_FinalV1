
CREATE OR ALTER VIEW [dbo].[vw_JamaRokar]
AS

-- 1. Bank Credits from vw_BankEntries
SELECT 
    0 AS EntryID,
    AccountTitle,
    Narration,
    SUM(CreditAmount) AS Amount,
    VoucherDate AS EntryDate
FROM vw_BankEntries
WHERE CreditAmount <> 0
  AND AccountID IN (SELECT ID FROM vwBankAccounts)
GROUP BY AccountTitle, Narration, VoucherDate

UNION ALL

-- 2. VoucherType = 1, Non-Bank Credit Entries from vwTrx
SELECT 
    0 AS EntryID,
    AccountTitle,
    Narration,
    SUM(CreditAmount) AS Amount,
    VoucherDate AS EntryDate
FROM vwTrx
WHERE VoucherType = 1
  AND CreditAmount <> 0
  AND AccountID NOT IN (SELECT ID FROM vwBankAccounts)
GROUP BY AccountTitle, Narration, VoucherDate

UNION ALL

-- 3. Credit to Customers (MasterID = 2)
SELECT 
    0 AS EntryID,
    AccountTitle,
    '' AS Narration,
    SUM(CreditAmount) AS Amount,
    VoucherDate AS EntryDate
FROM vwTrx
WHERE CreditAmount <> 0
  AND AccountID IN (SELECT ID FROM DetailAccounts WHERE MasterID = 2)
GROUP BY AccountTitle, VoucherDate

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



