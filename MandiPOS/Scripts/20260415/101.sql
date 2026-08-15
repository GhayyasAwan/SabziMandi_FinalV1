if Object_Id('dbo.vwVendorBaqayaSale') is not NULL
	Begin
		 Drop View dbo.vwVendorBaqayaSale
	End
Go
	CREATE View vwVendorBaqayaSale as
SELECT ArrivalNo,ArrivalDate,Case WHEN ISNULL(sale.PartyTitle,'')<>'' THEN sale.PartyTitle Else DA.AccountTitle End AS 'PartyTitle',SaleAmount1,SaleAmount2 FROM tblSale	sale
	left JOIN dbo.DetailAccounts DA ON	sale.PartyID=DA.ID
	WHERE sale.SaleAmount1<>sale.SaleAmount2
	GO
	if Object_ID('dbo.vwCustomerBaqayaSale') is not null
	Begin
			 DROP VIEW vwCustomerBaqayaSale;
	END
	Go
	Create VIEW vwCustomerBaqayaSale
													as
select sale.ArrivalNo,sale.ArrivalDate,da.AccountTitle as 'PartyTitle',sd.CustomerAmount,sd.PartyAmount FROM dbo.tblSale Sale
	left join dbo.tblSaleDetail SD on sale.ID=sd.SaleID
	left JOIN dbo.DetailAccounts DA ON sd.PartyID=da.ID
	WHERE sd.CustomerAmount<>sd.PartyAmount