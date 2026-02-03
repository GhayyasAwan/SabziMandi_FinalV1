if col_length('VoucherBardanaDetails','SourceID') is null
Begin
Alter Table VoucherBardanaDetails Add SourceID int not null default 0
End