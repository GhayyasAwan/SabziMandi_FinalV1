
ALTER VIEW[dbo].[vwTrx] AS

Select tbl.*,MasterAccounts.AccountTitle as 'MasterAccount',DetailAccounts.AccountTitle+' '+tblCity.CityName as 'AccountTitle' from 
(
--Opening Entries
SELECT 0 as DetailID,
    0 VoucherID,
    '2025-01-01' AS VoucherDate,
    '-1' AS VoucherType,
    ID AS AccountID,
    N'سابقہ' AS Narration, 0 as VoucherNo,
    OpDebit AS DebitAmount,
    OpCredit AS CreditAmount,
    0 AS ItemID,
    0 AS ItemQty,
    0 AS ItemRate,
    '' AS ItemDescription  ,'' as BillNo                           
FROM 
    [DetailAccounts]
Where OpDebit<>0 or OpCredit<>0


    UNION ALL

-- 🔹 VoucherDetails - Debit entry
SELECT vd.EntryID as DetailID,
    V.VoucherID,
    V.VoucherDate,
    V.VoucherType,
    CASE
        WHEN V.VoucherType = 0 THEN VD.PartyID
        WHEN V.VoucherType = 1 THEN VD.CashAccountID
    END AS AccountID,
    VD.Narration,  VoucherNo,
    ISNULL(VD.Amount,0) AS DebitAmount,
    CAST(0 AS DECIMAL(18, 2)) AS CreditAmount,
    CAST(0 AS INT) AS ItemID,
    CAST(0 AS DECIMAL(18, 2)) AS ItemQty,
    CAST(0 AS DECIMAL(18, 2)) AS ItemRate,
    CAST('' AS VARCHAR(200)) AS ItemDescription, v.VoucherNo as BillNo
FROM Vouchers V
JOIN VoucherDetails VD ON V.VoucherID = VD.VoucherID
WHERE V.VoucherType IN (0, 1)

UNION ALL

-- 🔹 VoucherDetails - Credit entry
SELECT vd.EntryID as DetailID,
    V.VoucherID,
    V.VoucherDate,
    V.VoucherType,
    CASE 
        WHEN V.VoucherType = 0 THEN VD.CashAccountID
        WHEN V.VoucherType = 1 THEN VD.PartyID
    END AS AccountID,
    VD.Narration,  VoucherNo,
    CAST(0 AS DECIMAL(18, 2)) AS DebitAmount,
    ISNULL(VD.Amount, 0) AS CreditAmount,
    CAST(0 AS INT) AS ItemID,
    CAST(0 AS DECIMAL(18, 2)) AS ItemQty,
    CAST(0 AS DECIMAL(18, 2)) AS ItemRate,
    CAST('' AS VARCHAR(200)) AS ItemDescription, v.VoucherNo as BillNo
FROM Vouchers V
JOIN VoucherDetails VD ON V.VoucherID = VD.VoucherID
WHERE V.VoucherType IN (0, 1)

UNION ALL

-- 🔹 VoucherBardanaDetails (VoucherType 3)
SELECT VB.ID as DetailID,
    V.VoucherID,
    V.VoucherDate,
    V.VoucherType,
    VB.AccountID,
    VB.Narration,  VoucherNo,
    ISNULL(VB.DebitAmount, 0)  DebitAmount,
    ISNULL(VB.CreditAmount, 0) CreditAmount,
    VB.ItemID,
    VB.ItemQty,
    VB.ItemRate,
    VB.ItemDescription,'' as BillNo
FROM Vouchers V
JOIN VoucherBardanaDetails VB ON V.VoucherID = VB.VoucherID
WHERE V.VoucherType in (3,5)

UNION ALL

-- 🔹 JVEntries (VoucherType 2, 4)
SELECT JV.ID as DetailID,
    V.VoucherID,
    V.VoucherDate,
    V.VoucherType,
    JV.AccountID,
    JV.Narration,
               VoucherNo,
    ISNULL(JV.DebitAmount, 0)DebitAmount,
    ISNULL(JV.CreditAmount, 0)CreditAmount,
    CAST(0 AS INT) AS ItemID,
    CAST(0 AS DECIMAL(18, 2)) AS ItemQty,
    CAST(0 AS DECIMAL(18, 2)) AS ItemRate,
    CAST('' AS VARCHAR(200)) AS ItemDescription, ISNULL(CAST(tblsale.ArrivalNo AS NVARCHAR), '') as BillNo
FROM Vouchers V
JOIN JVEntries JV ON V.VoucherID = JV.VoucherID
left join tblSale on v.VoucherID=tblsale.VoucherID
WHERE V.VoucherType IN (2, 4)
) tbl left join DetailAccounts on tbl.AccountID=DetailAccounts.ID
left join MasterAccounts on DetailAccounts.MasterID=MasterAccounts.ID
left join tblCity on DetailAccounts.CityID=tblCity.id
GO



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
            VoucherDate, narration,TrxType,
            Debit,
            Credit,
            SUM(Debit - Credit) 
                OVER (ORDER BY VoucherDate ROWS UNBOUNDED PRECEDING) AS Balance
        FROM
        (
            /* Opening Balance */
            SELECT 
                DATEADD(DAY, -1, @StartDate) AS VoucherDate, N'سابقہ بیلنس' as Narration  , -1 as TrxType,
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
                VoucherDate, '' as Narration,-2 as TrxType,
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
        VoucherType as TrxType,
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
                THEN VoucherNo 
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