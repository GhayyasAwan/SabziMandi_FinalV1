CREATE TABLE tblAgreements (
	AgreementID INT NOT NULL PRIMARY KEY IDENTITY (1, 1)
   ,PartyID INT REFERENCES DetailAccounts (ID) ON DELETE NO ACTION
   ,AgreementStartDate DATE NOT NULL
   ,AgreementEndDate DATE NULL
   ,Remarks NVARCHAR(MAX)
);
GO 
CREATE TABLE tblAgreementDetails (
	AgreementDetailID INT NOT NULL PRIMARY KEY IDENTITY (1, 1)
   ,AgreementID INT NOT NULL REFERENCES tblAgreements (AgreementID) ON DELETE CASCADE
   ,ItemID INT NOT NULL REFERENCES tblItems (ID) ON DELETE NO ACTION
   ,Area NVARCHAR(50)
);
GO
CREATE VIEW vwAgreements
AS
SELECT
	a.AgreementID
   ,a.AgreementNo
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