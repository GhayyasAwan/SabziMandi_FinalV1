CREATE OR ALTER FUNCTION dbo.ufn_GetCommissionLagaMazdooriMunshianaPendingSale
(
    @VoucherDate DATE
)
RETURNS DECIMAL(18,2)
AS
BEGIN
    DECLARE @Amount DECIMAL(18,2);

    SELECT @Amount = SUM(ISNULL(vd.CreditAmount,0))
    FROM Vouchers vm
    LEFT JOIN JVEntries vd ON vm.VoucherID = vd.VoucherID
    WHERE vm.VoucherDate = @VoucherDate
      AND vd.AccountID IN (
            SELECT CAST(ConfigValue AS INT)
            FROM tblConfigs
            WHERE ConfigName IN ('commission','laga','mazdoori','munshiana','pendingsale')
      );

    RETURN ISNULL(@Amount,0);
END;

