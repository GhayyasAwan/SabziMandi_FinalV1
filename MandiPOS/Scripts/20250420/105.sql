
ALTER VIEW dbo.vw_KhasraSummary
AS
SELECT 
    main.ArrivalDate AS Date,
    detail.PartyID,
    customer.AccountCode,
    customer.AccountTitle + ' ' + city.CityName as 'AccountTitle',
    SUM(detail.ItemQty) AS TotalQty,
    SUM(detail.ItemWeight) AS TotalWeight,
    SUM(detail.CustomerAmount) AS TotalCustomerAmount,
    SUM(detail.LagaAmount) AS TotalLagaAmount,
	SUM(detail.LagaAmount)+SUM(detail.CustomerAmount) as TotalAmount,
	Case When customer.AccountCode='70190' then 0 else 1 end as SortOrder,
	Case When main.PrintTime is null then 0 else 1 end as Printed
FROM 
    tblSale main
LEFT JOIN 
    tblSaleDetail detail ON main.id = detail.SaleID
LEFT JOIN 
    DetailAccounts customer ON detail.PartyID = customer.ID
LEFT JOIN 
    tblCity city ON customer.CityID = city.ID
GROUP BY 
    main.ArrivalDate,
    detail.PartyID,
    customer.AccountCode,
    customer.AccountTitle, 
    city.CityName, printTime

GO