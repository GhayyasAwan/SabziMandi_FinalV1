Create or Alter View vwBaqayaSale
as

WITH BaseData AS (
    SELECT 
        sale.ArrivalDate,
		detail.PartyID,
        sale.ArrivalNo,
        acc.AccountTitle,
        acc.MasterID,
        detail.ItemQty,
        detail.ItemWeight,
        detail.ParyRate,
        detail.CustomerRate,
        (detail.CustomerRate - detail.ParyRate) AS RateDiff,
        CASE 
            WHEN detail.ItemWeight <> 0 
                THEN (detail.CustomerRate - detail.ParyRate) * detail.ItemWeight
            ELSE (detail.CustomerRate - detail.ParyRate) * detail.ItemQty 
        END AS DiffAmount
    FROM tblSale sale
    LEFT JOIN tblSaleDetail detail ON sale.ID = detail.SaleID
    LEFT JOIN DetailAccounts acc ON detail.PartyID = acc.ID

    UNION ALL

    SELECT 
        sale.ArrivalDate,
		sale.PartyID,
        sale.ArrivalNo,
        acc.AccountTitle,
        acc.MasterID,
        detail.ItemQty,
        detail.ItemWeight,
        detail.ParyRate,
        detail.CustomerRate,
        (detail.CustomerRate - detail.ParyRate) AS RateDiff,
        CASE 
            WHEN detail.ItemWeight <> 0 
                THEN (detail.CustomerRate - detail.ParyRate) * detail.ItemWeight
            ELSE (detail.CustomerRate - detail.ParyRate) * detail.ItemQty 
        END AS DiffAmount
    FROM tblSale sale
    LEFT JOIN tblSaleDetail detail ON sale.ID = detail.SaleID
    LEFT JOIN DetailAccounts acc ON sale.PartyID = acc.ID
)

SELECT
    ArrivalDate,
    ArrivalNo,
    AccountTitle,
    MasterID,
	PartyID,

    SUM(ItemQty)     AS ItemQty,
    SUM(ItemWeight)  AS ItemWeight,
    SUM(DiffAmount)  AS DiffAmount,

    STRING_AGG(
        CAST(RateDiff AS varchar(20)) + ' x ' +
        CAST(
            CASE 
                WHEN ItemWeight <> 0 THEN ItemWeight 
                ELSE ItemQty 
            END AS varchar(20)
        ),
        ', '
    ) AS Narration

FROM BaseData
GROUP BY
    ArrivalDate,
    ArrivalNo,
	PartyID,
    AccountTitle,
    MasterID
