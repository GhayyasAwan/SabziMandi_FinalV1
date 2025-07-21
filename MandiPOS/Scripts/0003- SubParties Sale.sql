Create view vw_SubpartiesSale
as
Select ArrivalDate,ArrivalNo,PartyID,AccountTitle,marka,Remaining from tblSale sale
left join DetailAccounts acc on sale.PartyID=acc.ID
Where NULLIF(marka,'') is not null