if Object_id('dbo.usp_GetBardanaReport') is not null
begin
Drop proc dbo.usp_GetBardanaReport;
end
GO
Create proc usp_GetBardanaReport
@dateFrom date, @dateTo date, @partyID int
as
Begin
	Select t.VoucherDate,Vno,
	t.ItemRate,
	Case When DebitAmount>0 and CreditAmount=0 THen t.ItemQty else 0 end BanamQty,
	Case When CreditAmount>0 and DebitAmount=0 then ItemQty ELse 0 end as JamaQty,
	DebitAmount as BanamRaqam,
	CreditAmount as JamaRaqam,
	p.ItemTitle from vwTrx t
	left join tblItems p on t.ItemID=p.ID
	Where VoucherType=5 and AccountID=@partyID
	AND VoucherDate Between Cast(@dateFrom as date) and Cast(@dateTo as date)
End

