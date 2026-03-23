
Create FUNCTION dbo.fn_GetPartyItemSummary2
(
    @date1 DATE
)
RETURNS NVARCHAR(MAX)
AS
BEGIN
    DECLARE @Result NVARCHAR(MAX);

    SELECT @Result = STRING_AGG(ItemTitle + N'=' + CAST(Cast(Amount as int) AS NVARCHAR), N', ')
    FROM (
        SELECT p.ItemTitle, SUM(detail.CustomerAmount+detail.LagaAmount) AS Amount
        FROM tblSale sale
        LEFT JOIN tblSaleDetail detail ON sale.ID = detail.SaleID
        LEFT JOIN tblItems p ON detail.ItemID = p.ID
        WHERE sale.ArrivalDate = @date1
AND detail.PartyID=(
        SELECT
          ID
        FROM DetailAccounts da
        WHERE da.AccountTitle LIKE N'%نقد سیل%')
        GROUP BY p.ItemTitle
    ) AS Summary;

    RETURN @Result;
END;
GO