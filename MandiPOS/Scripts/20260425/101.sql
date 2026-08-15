-- Purana View drop kar rahay hain taake naya create ho sakay
IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_KhasraSummary]'))
    DROP VIEW [dbo].[vw_KhasraSummary]
GO

CREATE VIEW dbo.vw_KhasraSummary 
AS 
SELECT 
    main.ArrivalDate AS Date,
    detail.PartyID,
    customer.AccountCode,
    customer.AccountTitle + ' ' + city.CityName AS 'AccountTitle',
    SUM(detail.ItemQty) AS TotalQty,
    SUM(detail.ItemWeight) AS TotalWeight,
    SUM(detail.CustomerAmount) AS TotalCustomerAmount,
    SUM(detail.LagaAmount) AS TotalLagaAmount,
    SUM(detail.LagaAmount) + SUM(detail.CustomerAmount) AS TotalAmount,
    -- SortOrder logic
    CASE 
        WHEN customer.AccountCode = '70190' THEN 0 
        ELSE 1 
    END AS SortOrder,
    -- 70190 ke liye Printed hamesha 1 rahay ga
    CASE 
        WHEN customer.AccountCode = '70190' THEN 1
        WHEN main.PrintTime IS NOT NULL THEN 1 
        ELSE 0 
    END AS Printed
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
    city.CityName,
    main.PrintTime -- Yahan humne 'printed' alias hata kar 'PrintTime' kar diya hai
GO

if Object_id('sp_GetKhasraSummary','P') is not null
BEGIN
DROP PROCEDURE sp_GetKhasraSummary;
	End
	 Go
Create PROCEDURE sp_GetKhasraSummary 
	@date date
	AS Begin

SELECT
	Date
 ,
	-- Agar 70190 hai to PartyID ko 0 kar diya taake single record show ho
	CASE
		WHEN AccountCode = '70190' THEN 0
		ELSE PartyID
	END AS PartyID
 ,AccountCode
 ,AccountTitle
 ,SUM(TotalQty) AS TotalQty
 ,SUM(TotalWeight) AS TotalWeight
 ,SUM(TotalCustomerAmount) AS TotalCustomerAmount
 ,SUM(TotalLagaAmount) AS TotalLagaAmount
 ,SUM(TotalAmount) AS TotalAmount
 ,MAX(SortOrder) AS SortOrder
 , -- 70190 ka 0 hi rahega
	MAX(Printed) AS Printed      -- View mein humne pehle hi 70190 ke liye 1 kar diya hai
FROM vw_KhasraSummary
WHERE Date = @date
GROUP BY Date
				,AccountCode
				,AccountTitle
				,
				 -- 70190 ke liye grouping merge kar di, baaqi ke liye PartyID detail rakhi
				 CASE
					 WHEN AccountCode = '70190' THEN 0
					 ELSE PartyID
				 END
ORDER BY SortOrder,
CASE
	WHEN AccountCode <> '70190' THEN SUM(TotalAmount)
END DESC
	END