CREATE OR ALTER   view [dbo].[vwStockFlo]
as
Select VoucherID,ItemID,
Case When DebitAmount<>0 then ItemQty Else 0 End as Dr,
Case When CreditAmount<>0 then ItemQty Else 0 End as Cr,
Case When DebitAmount<>0 then ItemWeight Else 0 End as wtDr,
Case When CreditAmount<>0 then ItemWeight Else 0 End as wtCr
from 
VoucherBardanaDetails bvi
GO