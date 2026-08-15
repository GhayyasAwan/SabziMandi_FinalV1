IF OBJECT_ID('vw_BardanLedger', 'V') IS NOT NULL
BEGIN
  DROP VIEW vw_BardanLedger
END
GO
IF OBJECT_ID('vw_BardanaLedger', 'V') IS NOT NULL
BEGIN
  DROP VIEW vw_BardanaLedger
END
GO
Create VIEW vw_BardanaLedger
as
SELECT top 100 PERCENT
  v.VoucherID,
  v.VoucherNo
 ,v.VoucherDate AS [Date]
 ,vbd.itemid
 ,vbd.AccountID
 ,da.AccountTitle
 ,i.ItemTitle
 ,ItemRate
 ,vbd.ItemQty
 ,vbd.ItemWeight
 ,vbd.DebitAmount
 ,vbd.CreditAmount
 ,
  -- Running Total: Sum of (Debit - Credit) over time
  ABS(SUM(vbd.DebitAmount - vbd.CreditAmount) OVER (
  ORDER BY v.VoucherDate, v.VoucherID,
  (CASE
    WHEN vbd.CreditAmount > 0 THEN 0
    ELSE 1
  END) -- Priority: Credit first
  ROWS UNBOUNDED PRECEDING
  )) AS RunningBalance
FROM VoucherBardanaDetails vbd
LEFT JOIN Vouchers v
  ON vbd.VoucherID = v.VoucherID
LEFT JOIN DetailAccounts da
  ON vbd.AccountID = da.ID
LEFT JOIN tblItems i
  ON vbd.ItemID = i.ID
WHERE i.ItemType LIKE N'دیگر%'
ORDER BY v.VoucherDate,
v.VoucherID,
CASE
  WHEN vbd.CreditAmount > 0 THEN 0
  ELSE 1
END; -- Sorts Credits (In) before Debits (Out)