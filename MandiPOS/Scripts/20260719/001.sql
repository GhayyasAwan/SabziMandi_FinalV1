IF OBJECT_ID('[dbo].[vwTrx]') IS NOT NULL
    BEGIN
        DROP VIEW [dbo].[vwTrx]
    END
GO
CREATE VIEW [dbo].[vwTrx]
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
                        0 AS DetailID,
                        0 VoucherID,

                        CAST('2025-01-01' AS DATE) AS VoucherDate,
                        '-1' AS VoucherType,
                        ID AS AccountID,
                        N'سابقہ بیلنس' AS Narration,
                        OpDebit AS DebitAmount,
                        OpCredit AS CreditAmount,
                        0 AS ItemID,
                        0 AS ItemQty,
                        0 AS ItemRate,
                        '' AS ItemDescription,
                        '' AS BillNo,
                        0 AS Vno
                FROM
                        [DetailAccounts]

                UNION ALL

                SELECT
                        VD.EntryID AS DetailID,
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
                        END AS AccountID,

                        CASE
                                WHEN accCash.MasterID NOT IN (10)
                                    THEN
                                    VD.Narration + ' ' + accCash.AccountTitle
                                ELSE
                                VD.Narration
                        END AS Narration,




                        ISNULL(VD.Amount, 0) AS DebitAmount,
                        CAST(0 AS DECIMAL(18, 2)) AS CreditAmount,
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
                                                            VD.Narration + ' ' + accCash.AccountTitle
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
                        VB.ID AS DetailID,
                        V.VoucherNo AS VoucherID,

                        V.VoucherDate,
                        V.VoucherType,
                        VB.AccountID,
                        VB.Narration,
                        ISNULL(VB.DebitAmount, 0) DebitAmount,
                        ISNULL(VB.CreditAmount, 0) CreditAmount,
                        VB.ItemID,
                        VB.ItemQty,
                        VB.ItemRate,
                        VB.ItemDescription,
                        '' AS BillNo,
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
                        VB.ID AS DetailID,
                        V.VoucherNo AS VoucherID,

                        V.VoucherDate,
                        V.VoucherType,
                        VB.AccountID,
                        VB.Narration,
                        ISNULL(VB.DebitAmount, 0) DebitAmount,
                        ISNULL(VB.CreditAmount, 0) CreditAmount,
                        VB.ItemID,
                        VB.ItemQty,
                        VB.ItemRate,
                        VB.ItemDescription,
                        '' AS BillNo,
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
                        JV.ID AS DetailID,
                        V.VoucherID,
                        V.VoucherDate,
                        V.VoucherType,
                        JV.AccountID,
                        JV.Narration,
                        ISNULL(JV.DebitAmount, 0) DebitAmount,
                        ISNULL(JV.CreditAmount, 0) CreditAmount,
                        CAST(0 AS INT) AS ItemID,
                        CAST(0 AS DECIMAL(18, 2)) AS ItemQty,
                        CAST(0 AS DECIMAL(18, 2)) AS ItemRate,
                        CAST('' AS VARCHAR(200)) AS ItemDescription,
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
IF Object_ID('[dbo].[vw_BanamRokar]') is not NULL
BEGIN
DROP VIEW [dbo].[vw_BanamRokar];
End
Go
Create VIEW [dbo].[vw_BanamRokar]
AS

-- 1. VoucherType = 0 and Bank Account

--SELECT 
--    VoucherNo AS EntryID,
--    acc.AccountTitle + ' ' + city.CityName AS AccountTitle,
--    vd.Narration + ' '+ acc2.AccountTitle AS Narration,
--    vd.Amount AS Amount,
--    vm.VoucherDate AS EntryDate, VoucherNo as Vno, acc.MasterID,vd.EntryID as EntryNo
--FROM Vouchers vm
--LEFT JOIN VoucherDetails vd ON vm.VoucherID = vd.VoucherID
--LEFT JOIN DetailAccounts acc ON vd.PartyID = acc.ID
--LEFT JOIN tblCity city ON acc.CityID = city.ID
--LEFT JOIN DetailAccounts acc2 ON vd.CashAccountID = acc2.ID
--WHERE vm.VoucherType = 0
--  AND vd.CashAccountID IN (SELECT ID FROM vwBankAccounts)


--UNION ALL

-- 2. VoucherType = 0 and Not in Bank Account
SELECT
        VoucherNo                              AS EntryID,
        acc.AccountTitle + ' ' + city.CityName AS AccountTitle,
         vd.Narration+' ('+acc2.AccountTitle+')' AS Narration,
        vd.Amount                              AS Amount,
        vm.VoucherDate                         AS EntryDate,
        VoucherNo                              AS Vno,
        acc.MasterID,
        MA.AccountType,
        vd.EntryID                             AS EntryNo,
        vm.VoucherType
FROM
        Vouchers vm
    LEFT JOIN
        VoucherDetails vd
            ON vm.VoucherID = vd.VoucherID
    LEFT JOIN
        DetailAccounts acc
            ON vd.PartyID = acc.ID
    LEFT JOIN
        MasterAccounts AS MA
            ON acc.MasterID = MA.ID
    LEFT JOIN
        DetailAccounts acc2
            ON vd.CashAccountID = acc2.ID
    LEFT JOIN
        MasterAccounts AS MA1
            ON acc2.MasterID = MA1.ID
    LEFT JOIN
        tblCity city
            ON acc.CityID = city.ID
WHERE
        vm.VoucherType = 0
--AND vd.CashAccountID NOT IN (SELECT ID FROM vwBankAccounts)

UNION ALL

-- 3. VoucherType = 1 and Bank Account
SELECT
        VoucherNo                               AS EntryID,
        acc2.AccountTitle + ' ' + city.CityName AS AccountTitle,
        vd.Narration + ' ' + acc.AccountTitle   AS Narration,
        vd.Amount                               AS Amount,
        vm.VoucherDate                          AS EntryDate,
        VoucherNo                               AS Vno,
        acc2.MasterID,
        MA1.AccountType,
        vd.EntryID                              AS EntryNo,
        vm.VoucherType
FROM
        Vouchers vm
    LEFT JOIN
        VoucherDetails vd
            ON vm.VoucherID = vd.VoucherID
    LEFT JOIN
        DetailAccounts acc
            ON vd.PartyID = acc.ID
    LEFT JOIN
        MasterAccounts AS MA
            ON acc.MasterID = MA.ID
    LEFT JOIN
        DetailAccounts acc2
            ON vd.CashAccountID = acc2.ID
    LEFT JOIN
        MasterAccounts AS MA1
            ON acc2.MasterID = MA1.ID
    LEFT JOIN
        tblCity city
            ON acc2.CityID = city.ID
WHERE
        vm.VoucherType = 1
        AND vd.CashAccountID IN (SELECT
                    ID
            FROM
                    vwBankAccounts)

UNION ALL

-- 4. Sale Debit Entries from JVEntries (MasterID = 4)
--SELECT 
--    sale.ArrivalNo AS EntryID,
--    acc.AccountTitle + ' ' + city.CityName AS AccountTitle,
--    Narration,
--    DebitAmount AS Amount,
--    sale.ArrivalDate AS EntryDate
--FROM tblSale sale
--LEFT JOIN tblSaleDetail detail ON sale.ID = detail.SaleID
--LEFT JOIN JVEntries jv ON sale.VoucherID = jv.VoucherID
--LEFT JOIN DetailAccounts acc ON jv.AccountID = acc.ID
--LEFT JOIN tblCity city ON acc.CityID = city.ID
--WHERE jv.DebitAmount <> 0
--  AND acc.MasterID = 4


SELECT
        sale.ArrivalNo                         AS EntryID,
        acc.AccountTitle + ' ' + city.CityName AS AccountTitle,
        jv.Narration,
        jv.DebitAmount                         AS Amount,
        sale.ArrivalDate                       AS EntryDate,
        0                                      AS Vno,
        99                                     AS MasterID,
        MA.AccountType,
        0                                      AS EntryNo,
        vm.VoucherType
FROM
        tblSale sale
    LEFT JOIN
        Vouchers vm
            ON sale.VoucherID = vm.VoucherID
    LEFT JOIN
        JVEntries jv
            ON vm.VoucherID = jv.VoucherID
    LEFT JOIN
        DetailAccounts acc
            ON jv.AccountID = acc.ID
    LEFT JOIN
        MasterAccounts AS MA
            ON acc.MasterID = MA.ID
    LEFT JOIN
        tblCity city
            ON acc.CityID = city.ID
WHERE
        jv.DebitAmount <> 0
        AND acc.MasterID = 4


UNION ALL

-- 5. Sale Narration based on Items (excluding نقد سیل)
SELECT TOP 100 PERCENT
        *
FROM
        (   SELECT
                    main.ArrivalNo AS EntryID,
                    acc.AccountTitle + ' ' + city.CityName AS AccountTitle,
                    ItemTitle + ' ' +
                    CAST(
                    CASE
                            WHEN ItemUnit = 0
                                THEN
                                CAST(FLOOR(ItemQty) AS NVARCHAR)
                            ELSE
                            CAST(FLOOR(ItemWeight) AS NVARCHAR)
                    END AS NVARCHAR
                    ) + '*' + CAST(FLOOR(CustomerRate) AS NVARCHAR) AS Narration,
                    CustomerAmount + LagaAmount AS Amount,
                    main.ArrivalDate AS EntryDate,
                    0 AS Vno,
                    99 AS MasterID,
                    MA.AccountType,
                    0 AS EntryNo,
                    100 AS VoucherType
            FROM
                    tblSale main
                LEFT JOIN
                    tblSaleDetail sdetail
                        ON main.ID = sdetail.SaleID
                LEFT JOIN
                    tblItems
                        ON sdetail.ItemID = tblItems.ID
                LEFT JOIN
                    DetailAccounts acc
                        ON sdetail.PartyID = acc.ID
                LEFT JOIN
                    MasterAccounts AS MA
                        ON acc.MasterID = MA.ID
                LEFT JOIN
                    tblCity city
                        ON acc.CityID = city.ID
            WHERE
                    acc.AccountTitle NOT LIKE N'نقد سیل') AS X
ORDER BY
        X.EntryID
UNION ALL
SELECT
        Vno,
        acc.AccountTitle,
        ItemDescription,
        DebitAmount,
        VoucherDate,
        Vno,
        999 AS SortOrder,
        AccountType,
        0   AS EntryNo,
        vwTrx.Vouchertype

FROM
        vwTrx
    LEFT JOIN
        DetailAccounts acc
            ON vwTrx.AccountID = acc.ID
WHERE
        Vouchertype IN (3, 5)
        AND DebitAmount <> 0;
GO





