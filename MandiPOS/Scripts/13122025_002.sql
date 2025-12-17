CREATE or Alter   proc [dbo].[GetDetailAccount]  
@masterID int=0 ,@IncludeInActive int=0 
as  
  
Select acc.ID,  
acc.AccountCode,  
acc.AccountTitle,  
acc.Contact,  
c.CityName as 'City',  
acc.OpCredit,  
acc.OpDebit,  
acc.Remarks, acc.CreditLimit, acc.Commission, acc.RefName, acc.OldAccountCode  ,Acc.IsActive
from   
detailAccounts acc  
left join tblCity c on acc.cityID=c.ID  
Where  (@masterID=0 or acc.MasterID=@masterID)
and (@IncludeInActive =0 or ISNULL(IsActive,1)=1)