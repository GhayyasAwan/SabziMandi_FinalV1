
CREATE OR ALTER   FUNCTION [dbo].[ufn_GetVoucherSummaryByDate]
(
    @VoucherDate DATE
)
RETURNS TABLE
AS
RETURN
(
   SELECT 
    vm.VoucherDate,
    SUM(CASE WHEN vm.VoucherType = 0 THEN vd.Amount ELSE 0 END) AS TotalBanam,
    SUM(CASE WHEN vm.VoucherType = 1 THEN vd.Amount ELSE 0 END) AS TotalJama
FROM Vouchers vm
INNER JOIN VoucherDetails vd 
    ON vm.VoucherID = vd.VoucherID
WHERE CAST(vm.VoucherDate AS DATE) = '2025-12-11'
  AND (
        vm.VoucherType <> 1
        OR vd.CashAccountID NOT IN (SELECT ID FROM vwBankAccounts)
      )
GROUP BY vm.VoucherDate

);
GO


