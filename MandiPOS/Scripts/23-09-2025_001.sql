Create view vwDailyJamaBanam
as
SELECT 
    vm.VoucherDate,
    vm.VoucherType,
    ISNULL(vd.TotalAmount, 0) AS Amount
FROM Vouchers vm
OUTER APPLY (
    SELECT SUM(Amount) AS TotalAmount
    FROM VoucherDetails vd
    WHERE vd.VoucherID = vm.VoucherID
) vd
WHERE ISNULL(vd.TotalAmount, 0) <> 0;
