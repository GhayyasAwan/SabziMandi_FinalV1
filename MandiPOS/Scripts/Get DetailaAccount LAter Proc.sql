ALTER   proc [dbo].[GetDetailAccount]
@masterID int=null
as

Select acc.ID,
acc.AccountCode,
acc.AccountTitle,
acc.Contact,
c.CityName as 'City',
acc.OpCredit,
acc.OpDebit,
acc.Remarks, acc.CreditLimit, acc.Commission, acc.RefName, acc.OldAccountCode
from 
detailAccounts acc
left join tblCity c on acc.cityID=c.ID
Where  @masterID is null or acc.MasterID=@masterID