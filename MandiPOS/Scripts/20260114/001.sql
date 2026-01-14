Drop Function ufn_GetCommissionLagaMazdooriMunshianaPendingSale
GO
Create   FUNCTION [dbo].[ufn_GetCommissionLagaMazdooriMunshianaPendingSale]
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
            Select AccountID from DetailAccounts Where MasterID IN(Select MasterAccounts.ID from MasterAccounts Where AccountType like 'Income')
      );

    RETURN ISNULL(@Amount,0);
END;