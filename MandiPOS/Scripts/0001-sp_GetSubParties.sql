Create or Alter  proc [dbo].[GetSubParties]

as

Select acc.ID,
acc.AccountCode,
acc.AccountTitle,
acc.Contact,
c.CityName as 'City',
acc.OpCredit,
acc.OpDebit,
acc.Remarks, acc.CreditLimit, acc.Commission, acc.RefName
from 
detailAccounts acc
left join tblCity c on acc.cityID=c.ID
Where  Acc.ID in (Select Distinct PartyID From vwMarka)