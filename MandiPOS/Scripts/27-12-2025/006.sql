CREATE UNIQUE INDEX UX_Vouchers_UniqueTypeDate
ON Vouchers (VoucherType, VoucherDate)
WHERE VoucherType IN (0, 1, 2,3,5,6,7,8,9);