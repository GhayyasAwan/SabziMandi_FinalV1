If Object_ID('dbo.sp_Ledger') is not null
Begin
DROP PROC dbo.sp_Ledger;
	End
	Go
Create PROC dbo.sp_Ledger
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
            N'سابقہ بیلنس' AS Narration,
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
            CASE WHEN VoucherType=4 THEN 1 ELSE 0 END AS TrxType,
            CASE WHEN ISNULL(BillNo,0) = 0 THEN Vno ELSE BillNo END AS 'BillNo',
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
GO
	If Object_ID('dbo.vwTrx') is not null
Begin
Drop VIEW dbo.vwTrx;		
		End
	Go
Create VIEW dbo.vwTrx AS  
  
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
        WHEN accCash.MasterId not in(10)   
            THEN VD.Narration +' ' + accParty.AccountTitle  
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
	left join DetailAccounts accParty ON vd.partyid=accParty.ID 
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