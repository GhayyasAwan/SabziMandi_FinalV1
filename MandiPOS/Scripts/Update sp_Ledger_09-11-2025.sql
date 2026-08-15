ALTER PROC [dbo].[sp_Ledger]
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
    sELECT VoucherDate,TrxType,VoucherType,BillNo,Narration,debit,Credit,SUM(Debit - Credit) OVER (ORDER BY VoucherDate, RowNum ROWS UNBOUNDED PRECEDING) AS Balance FROM (
        -- Opening Balance Row (single row with summed amounts)
        SELECT 
            DATEADD(DAY, -1, @StartDate) AS VoucherDate,
            0 AS VoucherID,
            -1 AS trxType,
            -1 as vouchertype,
            0 AS BillNo,
            'Opening Balance' AS Narration,
            CASE WHEN SUM(DebitAmount - CreditAmount) > 0 THEN SUM(DebitAmount - CreditAmount) ELSE 0 END AS Debit,
            CASE WHEN SUM(DebitAmount - CreditAmount) < 0 THEN ABS(SUM(DebitAmount - CreditAmount)) ELSE 0 END AS Credit,
            0 AS RowNum
        FROM vwTrx
        WHERE AccountID = @AccountID AND VoucherDate < @StartDate
       
        UNION ALL
        
        -- Transactions within date range
        SELECT 
            VoucherDate,
            VoucherID,
            VoucherType,
            CASE WHEN ISNULL(BillNo,0) = 0 THEN 0 ELSE 1 END AS TrxType,
            CASE WHEN ISNULL(BillNo,0) = 0 THEN VoucherID ELSE BillNo END AS 'BillNo',
            Narration+' '+ItemDescription as 'Narration',
            DebitAmount,
            CreditAmount,
            ROW_NUMBER() OVER (ORDER BY VoucherDate, VoucherID) AS RowNum
        FROM vwTrx
        WHERE AccountID = @AccountID
          AND VoucherDate BETWEEN @StartDate AND @EndDate
    ) TBL ORDER BY VoucherDate, RowNum;
	End
END