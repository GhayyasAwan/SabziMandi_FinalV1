ALTER   View  [dbo].[vendorWiseSale]
as

SELECT 
    s.ArrivalDate,
    s.ArrivalNo,

    -- Vendor Info
    vendor.AccountCode AS VendorAccountCode,
    vendor.AccountTitle +' '+ISNULL(vc.CityName, '')  AS VendorAccountFull,s.marka,

    -- Customer Info
    customer.AccountCode AS CustomerAccountCode,
    ISNULL(cc.CityName, '')+ ' ' +customer.AccountTitle   AS CustomerAccountFull,

    -- Item Info
    d.ItemQty,
    d.ItemWeight,
    d.ParyRate as CustomerRate,
    d.PartyAmount as CustomerAmount,
    d.LagaAmount,
    
    -- Total Amount = CustomerAmount + LagaAmount
    (ISNULL(d.CustomerAmount, 0) + ISNULL(d.LagaAmount, 0)) AS TotalAmount,

    -- Item Detail: ItemTitle CustomerRate/ItemQty = CustomerAmount (formatted)
    i.ItemTitle + ' ' +
        FORMAT(d.CustomerRate, '0.##') + '/' +
        FORMAT(d.ItemQty, '0.##') + ' = ' +
        FORMAT(d.CustomerAmount, '0.##') AS ItemDetail

FROM tblSale s

INNER JOIN tblSaleDetail d ON s.ID = d.SaleID

-- Vendor (linked to tblSale.PartyID)
LEFT JOIN DetailAccounts vendor ON s.PartyID = vendor.ID
LEFT JOIN tblCity vc ON vendor.CityID = vc.ID

-- Customer (linked to tblSaleDetail.PartyID)
LEFT JOIN DetailAccounts customer ON d.PartyID = customer.ID
LEFT JOIN tblCity cc ON customer.CityID = cc.ID

-- Item Info
LEFT JOIN tblItems i ON d.ItemID = i.ID
GO