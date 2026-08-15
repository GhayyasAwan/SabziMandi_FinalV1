
ALTER VIEW [dbo].[vwTrx] AS  
  
Select tbl.*,MasterAccounts.AccountTitle as 'MasterAccount',MasterAccounts.ID as MasterID,DetailAccounts.AccountTitle+' '+tblCity.CityName as 'AccountTitle' from   
(  
--Opening Entries  
SELECT 0 as DetailID,  
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
    '' AS ItemDescription  ,'' as BillNo ,0 as Vno                            
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
                        VD.Narration + ' ' + accCash.AccountTitle
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
            V.VoucherType IN (2, 4)  
) tbl left join DetailAccounts on tbl.AccountID=DetailAccounts.ID  
left join MasterAccounts on DetailAccounts.MasterID=MasterAccounts.ID  
left join tblCity on DetailAccounts.CityID=tblCity.id
    GO


