IF OBJECT_ID('GetReferral','P') is not null
	DROP PROCEDURE [dbo].[GetReferral]
GO

Create     proc [dbo].[GetReferral]

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
Where  acc.ID in (Select Distinct ISNULL(RefrenceID,0) From DetailAccounts Where ISNULL(RefrenceID,0)<>0)
GO

