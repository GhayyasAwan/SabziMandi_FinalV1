
ALTER               VIEW [dbo].[vwTrx] AS  
  
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
    vd.EntryID AS DetailID,  
    V.VoucherID,  
   
    V.VoucherDate,  
    V.VoucherType,   
    CASE   
        WHEN V.VoucherType = 0 THEN VD.PartyID  
        WHEN V.VoucherType = 1 THEN VD.CashAccountID  
    END AS AccountID,  
  
   CASE   
        WHEN accCash.MasterId <> 10   
            THEN VD.Narration +' ' + accCash.AccountTitle  
        ELSE VD.Narration  
    END  AS Narration,  
  
    ISNULL(VD.Amount,0) AS DebitAmount,  
    CAST(0 AS DECIMAL(18,2)) AS CreditAmount,  
    CAST(0 AS INT) AS ItemID,  
    CAST(0 AS DECIMAL(18,2)) AS ItemQty,  
    CAST(0 AS DECIMAL(18,2)) AS ItemRate,  
    CAST('' AS VARCHAR(200)) AS ItemDescription,  
    '' AS BillNo,v.VoucherNo  
FROM Vouchers V  
JOIN VoucherDetails VD   
    ON V.VoucherID = VD.VoucherID  
LEFT JOIN DetailAccounts accCash   
    ON VD.CashAccountID = accCash.ID  
WHERE V.VoucherType IN (0, 1)  
UNION ALL  
  
Select Top (100) Percent tbl.* from (SELECT   
    vd.EntryID AS DetailID,  
    V.VoucherID,  
   
    V.VoucherDate,  
    V.VoucherType,  
    CASE   
        WHEN V.VoucherType = 0 THEN VD.CashAccountID  
        WHEN V.VoucherType = 1 THEN VD.PartyID  
    END AS AccountID,  
   
 Case When V.VoucherType = 1 Then  
    CASE   
        WHEN accCash.MasterId <> 10   
            THEN VD.Narration+' '  + accCash.AccountTitle  
        ELSE VD.Narration  
    END  
 Else   
 CASE   
        WHEN accParty.MasterId <> 10   
            THEN VD.Narration +' ' + accParty.AccountTitle  
        ELSE VD.Narration  
    END  
 End  
 AS Narration,  
  
    CAST(0 AS DECIMAL(18,2)) AS DebitAmount,  
    ISNULL(VD.Amount,0) AS CreditAmount,  
    CAST(0 AS INT) AS ItemID,  
    CAST(0 AS DECIMAL(18,2)) AS ItemQty,  
    CAST(0 AS DECIMAL(18,2)) AS ItemRate,  
    CAST('' AS VARCHAR(200)) AS ItemDescription,  
    '' AS BillNo,v.VoucherNo  
FROM Vouchers V  
JOIN VoucherDetails VD   
    ON V.VoucherID = VD.VoucherID  
LEFT JOIN DetailAccounts accCash   
    ON VD.CashAccountID = accCash.ID  
 Left join DetailAccounts accParty  
 on vd.PartyID=accParty.ID  
WHERE V.VoucherType IN (0, 1) ) tbl left join DetailAccounts acc on tbl.AccountID=acc.ID  
Order By acc.MasterID Desc  
  
  
  
UNION ALL  
  
-- 🔹 VoucherBardanaDetails (VoucherType 3)  
SELECT VB.ID as DetailID,  
    V.VoucherNo as VoucherID,  
   
    V.VoucherDate,  
    V.VoucherType,  
    VB.AccountID,  
    VB.Narration,  
    ISNULL(VB.DebitAmount,0)  DebitAmount,  
    ISNULL(VB.CreditAmount,0) CreditAmount,  
    VB.ItemID,  
    VB.ItemQty,  
    VB.ItemRate,  
    VB.ItemDescription,'' as BillNo,v.VoucherNo  
FROM Vouchers V  
JOIN VoucherBardanaDetails VB ON V.VoucherID = VB.VoucherID  
WHERE V.VoucherType = 3  
UNION ALL  
  
-- 🔹 VoucherBardanaDetails (VoucherType 5)  
SELECT VB.ID as DetailID,  
    V.VoucherNo as VoucherID,  
   
    V.VoucherDate,  
    V.VoucherType,  
    VB.AccountID,  
    VB.Narration,  
    ISNULL(VB.DebitAmount,0)  DebitAmount,  
    ISNULL(VB.CreditAmount,0) CreditAmount,  
    VB.ItemID,  
    VB.ItemQty,  
    VB.ItemRate,  
    VB.ItemDescription,'' as BillNo,v.VoucherNo  
FROM Vouchers V  
JOIN VoucherBardanaDetails VB ON V.VoucherID = VB.VoucherID  
WHERE V.VoucherType = 5  
  
UNION ALL  
  
-- 🔹 JVEntries (VoucherType 2, 4)  
SELECT JV.ID as DetailID,  
    V.VoucherID,  
   
    V.VoucherDate,  
    V.VoucherType,  
    JV.AccountID,  
    JV.Narration,  
   
    ISNULL(JV.DebitAmount,0)DebitAmount,  
    ISNULL(JV.CreditAmount,0)CreditAmount,  
    CAST(0 AS INT) AS ItemID,  
    CAST(0 AS DECIMAL(18,2)) AS ItemQty,  
    CAST(0 AS DECIMAL(18,2)) AS ItemRate,  
    CAST('' AS VARCHAR(200)) AS ItemDescription, ISNULL(CAST(tblsale.ArrivalNo AS NVARCHAR), '') as BillNo,v.VoucherNo  
FROM Vouchers V  
JOIN JVEntries JV ON V.VoucherID = JV.VoucherID  
left join tblSale on v.VoucherID=tblsale.VoucherID  
WHERE V.VoucherType IN (2, 4)  
) tbl left join DetailAccounts on tbl.AccountID=DetailAccounts.ID  
left join MasterAccounts on DetailAccounts.MasterID=MasterAccounts.ID  
left join tblCity on DetailAccounts.CityID=tblCity.id
GO


