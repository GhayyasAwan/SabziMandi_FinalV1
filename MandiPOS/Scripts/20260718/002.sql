if object_id('[dbo].[fn_GetPartyItemSummary]') is not null
Begin
Drop function [dbo].[fn_GetPartyItemSummary];
End
Go
CREATE   FUNCTION [dbo].[fn_GetPartyItemSummary]
(
    @date1 DATE,
    @date2 DATE,
    @PartyID INT
)
RETURNS NVARCHAR(MAX)
AS
BEGIN
    DECLARE @Result NVARCHAR(MAX);

    SELECT @Result = STRING_AGG(ItemTitle + N'=' + CAST(Cast(Qty as int) AS NVARCHAR), N', ')
    FROM (
    SELECT
            p.ItemTitle,
            SUM(detail.ItemQty) AS Qty
    FROM
            tblSale sale
        LEFT JOIN
            tblSaleDetail detail
                ON sale.ID = detail.SaleID
        LEFT JOIN
            tblItems p
                ON detail.ItemID = p.ID
    WHERE
            sale.ArrivalDate BETWEEN @date1 AND @date2
            AND sale.PartyID = @PartyID
            OR detail.PartyID = @PartyID
    GROUP BY
            p.ItemTitle
    ) AS Summary;

    RETURN @Result;
END;
    GO