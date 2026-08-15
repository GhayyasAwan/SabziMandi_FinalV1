ALTER View dbo.vwVendorBaqayaSale as
SELECT ArrivalNo,ArrivalDate,Case WHEN ISNULL(sale.PartyTitle,'')<>'' THEN sale.PartyTitle Else DA.AccountTitle End AS 'PartyTitle',SaleAmount1 as CustomerAmount,SaleAmount2 AS PartyAmount FROM tblSale	sale
	left JOIN dbo.DetailAccounts DA ON	sale.PartyID=DA.ID
	WHERE sale.SaleAmount1<>sale.SaleAmount2
GO