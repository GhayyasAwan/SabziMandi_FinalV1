ALTER PROC [dbo].[sp_Ledger]
    @AccountID INT,
    @StartDate DATE = NULL,
    @EndDate DATE = NULL,
    @GetBalanceBeforeDate DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;

    /*---------------------------------------------
      Balance before date (early exit)
    ---------------------------------------------*/
    IF @GetBalanceBeforeDate IS NOT NULL
    BEGIN
        SELECT 
            SUM(DebitAmount - CreditAmount) AS EndingBalance
        FROM vwTrx
        WHERE AccountID = @AccountID
          AND VoucherDate < @GetBalanceBeforeDate;

        RETURN;
    END;

    /*---------------------------------------------
      Get MasterID
    ---------------------------------------------*/
    DECLARE @MasterID INT;

    SELECT @MasterID = MasterId
    FROM DetailAccounts
    WHERE ID = @AccountID;

    /*---------------------------------------------
      MASTERID = 2  → DATE-WISE SUMMARY LEDGER
    ---------------------------------------------*/
    IF @MasterID = 2
    BEGIN
        SELECT
            VoucherDate, narration,
            Debit,
            Credit,
            SUM(Debit - Credit) 
                OVER (ORDER BY VoucherDate ROWS UNBOUNDED PRECEDING) AS Balance
        FROM
        (
            /* Opening Balance */
            SELECT 
                DATEADD(DAY, -1, @StartDate) AS VoucherDate, N'سابقہ بیلنس' as Narration  ,
                CASE 
                    WHEN SUM(DebitAmount - CreditAmount) > 0 
                    THEN SUM(DebitAmount - CreditAmount) 
                    ELSE 0 
                END AS Debit,
                CASE 
                    WHEN SUM(DebitAmount - CreditAmount) < 0 
                    THEN ABS(SUM(DebitAmount - CreditAmount)) 
                    ELSE 0 
                END AS Credit
            FROM vwTrx
            WHERE AccountID = @AccountID
              AND VoucherDate < @StartDate

            UNION ALL

            /* Date-wise Transactions */
            SELECT
                VoucherDate, '' as Narration,
                SUM(DebitAmount) AS Debit,
                SUM(CreditAmount) AS Credit
            FROM vwTrx
            WHERE AccountID = @AccountID
              AND VoucherDate BETWEEN @StartDate AND @EndDate
            GROUP BY VoucherDate
        ) T
        ORDER BY VoucherDate;

        RETURN;
    END;

    /*---------------------------------------------
      OTHER MASTERIDs → FULL DETAILED LEDGER
    ---------------------------------------------*/
    SELECT
        VoucherDate,
        TrxType,
        VoucherType,
        BillNo,
        Narration,
        Debit,
        Credit,
        SUM(Debit - Credit) 
            OVER (ORDER BY VoucherDate, RowNum ROWS UNBOUNDED PRECEDING) AS Balance
    FROM
    (
        /* Opening Balance */
        SELECT 
            DATEADD(DAY, -1, @StartDate) AS VoucherDate,
            0 AS VoucherID,
            -1 AS TrxType,
            -1 AS VoucherType,
            0 AS BillNo,
            N'سابقہ' AS Narration,
            CASE 
                WHEN SUM(DebitAmount - CreditAmount) > 0 
                THEN SUM(DebitAmount - CreditAmount) 
                ELSE 0 
            END AS Debit,
            CASE 
                WHEN SUM(DebitAmount - CreditAmount) < 0 
                THEN ABS(SUM(DebitAmount - CreditAmount)) 
                ELSE 0 
            END AS Credit,
            0 AS RowNum
        FROM vwTrx
        WHERE AccountID = @AccountID
          AND VoucherDate < @StartDate

        UNION ALL

        /* Detailed Transactions */
        SELECT 
            VoucherDate,
            VoucherID,
            CASE 
                WHEN ISNULL(BillNo, 0) = 0 THEN 0 
                ELSE 1 
            END AS TrxType,
            VoucherType,
            CASE 
                WHEN ISNULL(BillNo, 0) = 0 
                THEN VoucherID 
                ELSE BillNo 
            END AS BillNo,
            Narration + ' ' + ItemDescription AS Narration,
            DebitAmount AS Debit,
            CreditAmount AS Credit,
            ROW_NUMBER() 
                OVER (ORDER BY VoucherDate, VoucherID) AS RowNum
        FROM vwTrx
        WHERE AccountID = @AccountID
          AND VoucherDate BETWEEN @StartDate AND @EndDate
    ) X
    ORDER BY VoucherDate, RowNum;
END;
GO
