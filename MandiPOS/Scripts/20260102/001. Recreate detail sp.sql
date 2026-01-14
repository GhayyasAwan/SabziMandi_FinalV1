if OBJECT_ID('GetDetailAccount','P') is not null
Begin	Drop proc GetDetailAccount End

Go
Create     proc [dbo].[GetDetailAccount]  
@masterID int=0 ,@IncludeInActive int=0 
as  
  
Select acc.ID,  
acc.AccountCode,  
acc.AccountTitle,  
acc.Contact,  
c.CityName as 'City',mas.AccountTitle as MasterAccount,  
acc.OpCredit,  
acc.OpDebit,  
acc.Remarks, acc.CreditLimit, acc.Commission, acc.RefName, acc.OldAccountCode  ,Acc.IsActive
from   
detailAccounts acc  
left join tblCity c on acc.cityID=c.ID  
left join MasterAccounts mas on acc.MasterID=mas.ID
Where  (@masterID=0 or acc.MasterID=@masterID)
and (@IncludeInActive =0 or ISNULL(IsActive,1)=1)

Go

ALTER     proc [dbo].[GetReferral]

as

Select acc.ID,
acc.AccountCode,
acc.AccountTitle,
acc.Contact,
c.CityName as 'City',mas.AccountTitle as MasterAccount,
acc.OpCredit,
acc.OpDebit,
acc.Remarks, acc.CreditLimit, acc.Commission, acc.RefName
from 
detailAccounts acc
left join tblCity c on acc.cityID=c.ID
left join MasterAccounts mas on acc.MasterID=mas.ID
Where  acc.ID in (Select Distinct ISNULL(RefrenceID,0) From DetailAccounts Where ISNULL(RefrenceID,0)<>0)

Go

ALTER    proc [dbo].[GetSubParties]

as

Select acc.ID,
acc.AccountCode,
acc.AccountTitle,
acc.Contact,
c.CityName as 'City',mas.AccountTitle as MasterAccount,
acc.OpCredit,
acc.OpDebit,
acc.Remarks, acc.CreditLimit, acc.Commission, acc.RefName
from 
detailAccounts acc
left join tblCity c on acc.cityID=c.ID
left join MasterAccounts mas on acc.MasterID=mas.ID
Where  Acc.ID in (Select Distinct PartyID From vwMarka)

