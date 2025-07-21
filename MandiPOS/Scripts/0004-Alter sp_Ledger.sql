

ALTER   PROC [dbo].[sp_Ledger]
    @AccountID INT,
    @StartDate DATE=null,
    @EndDate DATE=null ,
	@GetBalanceBeforeDate DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;

	IF @GetBalanceBeforeDate IS NOT NULL
    BEGIN
        SELECT 
            SUM(DebitAmount - CreditAmount) AS EndingBalance
        FROM vwTrx
        WHERE AccountID = @AccountID 
          AND VoucherDate < @GetBalanceBeforeDate;
        
        RETURN;  -- Exit early if just getting balance
    END


    Begin
    -- Step 1: Opening + Transactions Combined
    WITH CombinedLedger AS (
        -- Opening Balance Row (single row with summed amounts)
        SELECT 
            DATEADD(DAY, -1, @StartDate) AS VoucherDate,
            0 AS VoucherID,
            0 AS trxType,vouchertype,
            0 AS BillNo,
            'Opening Balance' AS Narration,
            CASE WHEN SUM(DebitAmount - CreditAmount) > 0 THEN SUM(DebitAmount - CreditAmount) ELSE 0 END AS Debit,
            CASE WHEN SUM(DebitAmount - CreditAmount) < 0 THEN ABS(SUM(DebitAmount - CreditAmount)) ELSE 0 END AS Credit,
            0 AS RowNum
        FROM vwTrx
        WHERE AccountID = @AccountID AND VoucherDate < @StartDate
        Group by VoucherType
        UNION ALL
        
        -- Transactions within date range
        SELECT 
            VoucherDate,
            VoucherID,
            VoucherType,
            CASE WHEN ISNULL(BillNo,0) = 0 THEN 0 ELSE 1 END AS TrxType,
            CASE WHEN ISNULL(BillNo,0) = 0 THEN VoucherID ELSE BillNo END AS 'BillNo',
            Narration,
            DebitAmount,
            CreditAmount,
            ROW_NUMBER() OVER (ORDER BY VoucherDate, VoucherID) AS RowNum
        FROM vwTrx
        WHERE AccountID = @AccountID 
          AND VoucherDate BETWEEN @StartDate AND @EndDate
    )
    
    -- Step 2: Running Total Calculation
    SELECT 
        VoucherDate,
        TrxType,
        BillNo,
        Narration,
        Debit,
        Credit,
        SUM(Debit - Credit) OVER (ORDER BY VoucherDate, RowNum ROWS UNBOUNDED PRECEDING) AS Balance
    FROM CombinedLedger
    ORDER BY VoucherDate, RowNum;
	End
END



