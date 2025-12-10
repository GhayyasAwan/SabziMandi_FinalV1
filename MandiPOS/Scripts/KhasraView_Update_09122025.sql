

ALTER   VIEW [dbo].[vw_KhasraDetails] AS
SELECT 
    main.ArrivalDate, 
    customer.AccountTitle+' '+CityName as 'AccountTitle',
    STRING_AGG(items.ItemTitle  +  CAST(FLOOR(CustomerRate) as NvarChar)+'/' + CAST(FLOOR(ItemQty) as nvarchar), ', ') AS ItemDetails,
    SUM(ItemQty) AS 'Qty',
    SUM(customerAmount) AS 'FirstAmount', 
    SUM(LagaAmount) AS 'Laga', 
    SUM(CustomerAmount + LagaAmount) AS 'TotalAmount' 
FROM 
    tblSale main 
    LEFT JOIN tblSaleDetail detail ON main.ID = detail.SaleID
    LEFT JOIN tblItems items ON detail.ItemID = items.ID
    LEFT JOIN DetailAccounts customer ON detail.PartyID = customer.ID
	LEFT JOIN tblCity city ON customer.CityID = city.ID
GROUP BY 
    ArrivalDate, 
    AccountTitle,CityName
GO


