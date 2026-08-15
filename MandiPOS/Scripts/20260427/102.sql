

ALTER VIEW dbo.vw_SaleItemCostDistribution AS
SELECT 
    s.ID,s.marka,
    s.PartyID,
    s.ArrivalDate,
    s.ArrivalNo,
    d.ItemQty,
    d.partyamount,
	d.CustomerAmount,
    FORMAT(s.ArrivalDate, 'MMM-yyyy') AS MonthTag,
    d.ItemID,
    d.LagaAmount AS Laga,
    -- Calculate commission proportionally based on PartyAmount/SaleAmount2
    (d.PartyAmount / NULLIF(s.SaleAmount2, 0)) * s.CommissionAmount AS Commission,
    -- Calculate mazdoori proportionally based on PartyAmount/SaleAmount2
    (d.PartyAmount / NULLIF(s.SaleAmount2, 0)) * s.MazdooriAmount AS Mazdoori,
    -- Calculate munshiana proportionally based on PartyAmount/SaleAmount2
    (d.PartyAmount / NULLIF(s.SaleAmount2, 0)) * s.MunshianaAmount AS Munshiana,
    (d.PartyAmount / NULLIF(s.SaleAmount2, 0)) * s.KarayaAmount AS Karaya,
    (d.PartyAmount / NULLIF(s.SaleAmount2, 0)) * s.PaidAmount AS NetPaid
FROM 
    [tblSale] s
INNER JOIN 
    [tblSaleDetail] d ON s.ID = d.SaleID
WHERE 
    s.SaleAmount2 <> 0; -- To avoid division by zero
GO

ALTER view dbo.MasterSheet
as
Select ArrivalDate,ArrivalNo,ItemTitle,ItemQty,Commission,Mazdoori,Munshiana,PartyAmount,CustomerAmount,Karaya,NetPaid,PArtyID,Marka
from vw_SaleItemCostDistribution left join tblItems on vw_SaleItemCostDistribution.ItemID=tblitems.ID
GO