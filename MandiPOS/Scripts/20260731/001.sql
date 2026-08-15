IF OBJECT_ID('dbo.vwTrx2', 'V') IS NOT NULL
	DROP VIEW dbo.vwTrx2
GO
CREATE  VIEW [dbo].[vwTrx2]
AS

    SELECT
            tbl.*,
            MasterAccounts.AccountTitle                          AS 'MasterAccount',
            MasterAccounts.ID                                    AS MasterID,
            MasterAccounts.AccountType,
            DetailAccounts.AccountTitle + ' ' + tblCity.CityName AS 'AccountTitle'
    FROM
            (
    --Opening Entries  
    SELECT
            0                          AS DetailID,
            0                          VoucherID,

            CAST('2025-01-01' AS DATE) AS VoucherDate,
            '-1'                       AS VoucherType,
            ID                         AS AccountID,
            N'سابقہ بیلنس'             AS Narration,
            OpDebit                    AS DebitAmount,
            OpCredit                   AS CreditAmount,
            0                          AS ItemID,
            0                          AS ItemQty,
            0                          AS ItemRate,
            ''                         AS ItemDescription,
            ''                         AS BillNo,
            0                          AS Vno
    FROM
            [DetailAccounts]

    UNION ALL

    SELECT
            VD.EntryID                AS DetailID,
            V.VoucherID,

            V.VoucherDate,
            V.VoucherType,
            CASE
                    WHEN V.VoucherType = 0
                        THEN
                        VD.PartyID
                    WHEN V.VoucherType = 1
                        THEN
                        VD.CashAccountID
            END                       AS AccountID,

            CASE
                    WHEN accCash.MasterID NOT IN (10)
                        THEN
                        VD.Narration + ' ' + accParty.AccountTitle
                    ELSE
                    VD.Narration
            END                       AS Narration,




            ISNULL(VD.Amount, 0)      AS DebitAmount,
            CAST(0 AS DECIMAL(18, 2)) AS CreditAmount,
            CAST(0 AS INT)            AS ItemID,
            CAST(0 AS DECIMAL(18, 2)) AS ItemQty,
            CAST(0 AS DECIMAL(18, 2)) AS ItemRate,
            CAST('' AS VARCHAR(200))  AS ItemDescription,
            ''                        AS BillNo,
            V.VoucherNo
    FROM
            Vouchers V
        JOIN
            VoucherDetails VD
                ON V.VoucherID = VD.VoucherID
        LEFT JOIN
            DetailAccounts accCash
                ON VD.CashAccountID = accCash.ID
        LEFT JOIN
            DetailAccounts accParty
                ON VD.partyid = accParty.ID
    WHERE
            V.VoucherType IN (0, 1)
    UNION ALL

    SELECT TOP (100) PERCENT
            tbl.*
    FROM
            (   SELECT
                        VD.EntryID AS DetailID,
                        V.VoucherID,

                        V.VoucherDate,
                        V.VoucherType,
                        CASE
                                WHEN V.VoucherType = 0
                                    THEN
                                    VD.CashAccountID
                                WHEN V.VoucherType = 1
                                    THEN
                                    VD.PartyID
                        END AS AccountID,

                        CASE
                                WHEN V.VoucherType = 1
                                    THEN
                                    CASE
                                            WHEN accCash.MasterID <> 10
                                                THEN
                                                VD.Narration + ' ' + accParty.AccountTitle
                                            ELSE
                                            VD.Narration
                                    END
                                ELSE
                                CASE
                                        WHEN accParty.MasterID <> 10
                                            THEN
                                            VD.Narration + ' ' + accParty.AccountTitle
                                        ELSE
                                        VD.Narration
                                END
                        END
                        AS Narration,

                        CAST(0 AS DECIMAL(18, 2)) AS DebitAmount,
                        ISNULL(VD.Amount, 0) AS CreditAmount,
                        CAST(0 AS INT) AS ItemID,
                        CAST(0 AS DECIMAL(18, 2)) AS ItemQty,
                        CAST(0 AS DECIMAL(18, 2)) AS ItemRate,
                        CAST('' AS VARCHAR(200)) AS ItemDescription,
                        '' AS BillNo,
                        V.VoucherNo
                FROM
                        Vouchers V
                    JOIN
                        VoucherDetails VD
                            ON V.VoucherID = VD.VoucherID
                    LEFT JOIN
                        DetailAccounts accCash
                            ON VD.CashAccountID = accCash.ID
                    LEFT JOIN
                        DetailAccounts accParty
                            ON VD.PartyID = accParty.ID
                WHERE
                        V.VoucherType IN (0, 1)) tbl
        LEFT JOIN
            DetailAccounts acc
                ON tbl.AccountID = acc.ID
    ORDER BY
            acc.MasterID DESC



    UNION ALL

    -- 🔹 VoucherBardanaDetails (VoucherType 3)  
    SELECT
            VB.ID                      AS DetailID,
            V.VoucherNo                AS VoucherID,

            V.VoucherDate,
            V.VoucherType,
            VB.AccountID,
            VB.Narration,
            ISNULL(VB.DebitAmount, 0)  DebitAmount,
            ISNULL(VB.CreditAmount, 0) CreditAmount,
            VB.ItemID,
            VB.ItemQty,
            VB.ItemRate,
            VB.ItemDescription,
            ''                         AS BillNo,
            V.VoucherNo
    FROM
            Vouchers V
        JOIN
            VoucherBardanaDetails VB
                ON V.VoucherID = VB.VoucherID
    WHERE
            V.VoucherType = 3
    UNION ALL

    -- 🔹 VoucherBardanaDetails (VoucherType 5)  
    SELECT
            VB.ID                      AS DetailID,
            V.VoucherNo                AS VoucherID,

            V.VoucherDate,
            V.VoucherType,
            VB.AccountID,
            VB.Narration,
            ISNULL(VB.DebitAmount, 0)  DebitAmount,
            ISNULL(VB.CreditAmount, 0) CreditAmount,
            VB.ItemID,
            VB.ItemQty,
            VB.ItemRate,
            VB.ItemDescription,
            ''                         AS BillNo,
            V.VoucherNo
    FROM
            Vouchers V
        JOIN
            VoucherBardanaDetails VB
                ON V.VoucherID = VB.VoucherID
    WHERE
            V.VoucherType = 5

    UNION ALL

    -- 🔹 JVEntries (VoucherType 2, 4)  
    SELECT
            JV.ID                                           AS DetailID,
            V.VoucherID,
            V.VoucherDate,
            V.VoucherType,
            JV.AccountID,
            JV.Narration,
            ISNULL(JV.DebitAmount, 0)                       DebitAmount,
            ISNULL(JV.CreditAmount, 0)                      CreditAmount,
            CAST(0 AS INT)                                  AS ItemID,
            CAST(0 AS DECIMAL(18, 2))                       AS ItemQty,
            CAST(0 AS DECIMAL(18, 2))                       AS ItemRate,
            CAST('' AS VARCHAR(200))                        AS ItemDescription,
            ISNULL(CAST(tblsale.ArrivalNo AS NVARCHAR), '') AS BillNo,
            V.VoucherNo
    FROM
            Vouchers V
        JOIN
            JVEntries JV
                ON V.VoucherID = JV.VoucherID
        LEFT JOIN
            tblSale
                ON V.VoucherID = tblsale.VoucherID
    WHERE
            V.VoucherType IN (2, 4)) tbl
        LEFT JOIN
            DetailAccounts
                ON tbl.AccountID = DetailAccounts.ID
        LEFT JOIN
            MasterAccounts
                ON DetailAccounts.MasterID = MasterAccounts.ID
        LEFT JOIN
            tblCity
                ON DetailAccounts.CityID = tblCity.id
    GO


IF OBJECT_ID('dbo.sp_Ledger') IS NOT NULL
    DROP PROCEDURE dbo.sp_Ledger
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_Ledger]
    @AccountID            INT,
    @StartDate            DATE = NULL,
    @EndDate              DATE = NULL,
    @GetBalanceBeforeDate DATE = NULL
AS
    BEGIN
        SET NOCOUNT ON;

        IF @GetBalanceBeforeDate IS NOT NULL
            BEGIN
                SELECT
                        SUM(DebitAmount - CreditAmount) AS EndingBalance
                FROM
                        vwTrx
                WHERE
                        AccountID = @AccountID
                        AND VoucherDate < @GetBalanceBeforeDate;

                RETURN;  -- Exit early if just getting balance
            END


        BEGIN
            SELECT
                    VoucherDate,
                    TrxType,
                    VoucherType,
                    BillNo,
                    Narration,
                    debit,
                    Credit,
                    SUM(Debit - Credit) OVER (ORDER BY VoucherDate, RowNum ROWS UNBOUNDED PRECEDING) AS Balance
            FROM
                    (
                        -- Opening Balance Row (single row with summed amounts)
                        SELECT
                                DATEADD(DAY, -1, @StartDate) AS VoucherDate,
                                0 AS VoucherID,
                                -1 AS trxType,
                                -1 AS vouchertype,
                                0 AS BillNo,
                                N'سابقہ بیلنس' AS Narration,
                                CASE
                                        WHEN SUM(DebitAmount - CreditAmount) > 0
                                            THEN
                                            SUM(DebitAmount - CreditAmount)
                                        ELSE
                                        0
                                END AS Debit,
                                CASE
                                        WHEN SUM(DebitAmount - CreditAmount) < 0
                                            THEN
                                            ABS(SUM(DebitAmount - CreditAmount))
                                        ELSE
                                        0
                                END AS Credit,
                                0 AS RowNum
                        FROM
                                vwTrx2
                        WHERE
                                AccountID = @AccountID
                                AND VoucherDate < @StartDate

                        UNION ALL

                        -- Transactions within date range
                        SELECT
                                VoucherDate,
                                VoucherID,
                                VoucherType,
                                CASE
                                        WHEN VoucherType = 4
                                            THEN
                                            1
                                        ELSE
                                        0
                                END AS TrxType,
                                CASE
                                        WHEN ISNULL(BillNo, 0) = 0
                                            THEN
                                            Vno
                                        ELSE
                                        BillNo
                                END AS 'BillNo',
                                Narration + ' ' + ItemDescription AS 'Narration',
                                DebitAmount,
                                CreditAmount,
                                ROW_NUMBER() OVER (ORDER BY VoucherDate, VoucherID) AS RowNum
                        FROM
                                vwTrx2
                        WHERE
                                AccountID = @AccountID
                                AND VoucherDate BETWEEN @StartDate AND @EndDate) TBL
            ORDER BY
                    VoucherDate,
                    RowNum;
        END
    END
GO


