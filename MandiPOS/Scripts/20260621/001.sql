
IF OBJECT_ID('dbo.usp_VoucherDetails_Insert') IS NOT NULL
BEGIN 
    DROP PROC dbo.usp_VoucherDetails_Insert
END 
GO
CREATE PROC dbo.usp_VoucherDetails_Insert
    @VoucherID int,
    @PartyID int,
    @CashAccountID int,
    @Narration nvarchar(Max),
    @Amount numeric(18, 2),
    @EnteredBy int, @EntryID int
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON
	SET IDENTITY_INSERT dbo.VoucherDetails ON;
	INSERT INTO dbo.VoucherDetails (EntryID, VoucherID, PartyID, CashAccountID, Narration, Amount, EnteredBy)
		SELECT
			@EntryID
		   ,@VoucherID
		   ,@PartyID
		   ,@CashAccountID
		   ,@Narration
		   ,@Amount
		   ,@EnteredBy;
	SET IDENTITY_INSERT dbo.VoucherDetails OFF;
GO

