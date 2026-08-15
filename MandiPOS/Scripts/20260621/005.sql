

/****** Object:  View [dbo].[vwAgreements]    Script Date: 6/22/2026 2:45:45 PM ******/
DROP VIEW [dbo].[vwAgreements]
GO

/****** Object:  View [dbo].[vwAgreements]    Script Date: 6/22/2026 2:45:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwAgreements]
AS
SELECT
	a.AgreementID
   ,a.PartyID
   ,da.AccountTitle
   ,a.AgreementStartDate
   ,a.AgreementEndDate
   ,a.Remarks
FROM tblAgreements a
LEFT JOIN DetailAccounts da
	ON a.PartyID = da.ID;
GO


