IF NOT EXISTS (
    SELECT 1 
    FROM sys.columns 
    WHERE Name = 'ItemWeight' 
      AND Object_ID = Object_ID('dbo.VoucherBardanaDetails')
)
BEGIN
    ALTER TABLE dbo.VoucherBardanaDetails
    ADD ItemWeight DECIMAL(18,2) NULL;
END;

GO
