IF OBJECT_ID('usp_ItemRecordViaAgreementID') IS not NULL
BEGIN
Drop PROC usp_ItemRecordViaAgreementID
End
GO
Create proc usp_ItemRecordViaAgreementID
@AgreementID INT
AS
BEGIN
DECLARE @startDate DATE,
        @EndDate   DATE,@PartyID int;
        SELECT @PartyID=a.PartyID, @startDate=a.AgreementStartDate, @EndDate=ISNULL(a.AgreementEndDate,Cast(GetDate() AS Date)) FROM tblAgreements AS A Where a.AgreementID=@AgreementID
SELECT i.ItemTitle,SUM(sd.ItemQty) AS Qty FROM tblSale AS S
LEFT JOIN tblSaleDetail AS SD ON s.ID=sd.SaleID
left JOIN tblItems AS I on sd.ItemID=i.ID
WHERE s.PartyID=@partyID and Cast(s.ArrivalDate AS Date) BETWEEN @startDate AND @EndDate 
Group BY I.ItemTitle
END

