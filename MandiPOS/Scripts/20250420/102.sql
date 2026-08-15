ALTER view dbo.vwSale1
as
Select  s.ID,s.ArrivalNo,s.ArrivalDate,p.AccountTitle as 'PartyTitle',s.TotalQty,s.SoldQty,s.RemainingQty, Case When PrintTime is Null THEN 1 else 0 END as Printed
from tblSale s left join DetailAccounts p on s.PartyID=p.ID
GO