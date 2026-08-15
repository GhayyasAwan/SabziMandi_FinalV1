Create view vwStockFlo
as
Select VoucherID,ItemID,Case When DebitAmount<>0 then ItemQty Else 0 End as Dr,Case When CreditAmount<>0 then ItemQty Else 0 End as Cr from 
VoucherBardanaDetails bvi
