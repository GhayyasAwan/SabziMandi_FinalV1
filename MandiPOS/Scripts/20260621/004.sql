if Object_ID('vwAgreements') is not null
Begin
Drop View vwAgreements;
End
GO
CREATE VIEW vwAgreements
AS
SELECT
	a.AgreementID
   ,a.PartyID
   ,da.AccountTitle
   ,a.AgreementStartDate
   ,a.AgreementEndDate
   ,a.Remarks
FROM tblAgreements a
LEFT JOIN tblDetailAccounts da
	ON a.PartyID = da.ID;
	GO
	if Col_Length('tblAgreements','AgreementNo') is not null
	Begin
	Alter Table tblAgreements
	Drop Column AgreementNo;
	End