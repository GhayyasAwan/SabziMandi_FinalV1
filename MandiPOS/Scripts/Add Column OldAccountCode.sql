
IF NOT EXISTS (
    SELECT 1
    FROM sys.columns
    WHERE Name = 'OldAccountCode'
      AND Object_ID = OBJECT_ID('dbo.DetailAccounts')
)
BEGIN
    ALTER TABLE dbo.DetailAccounts
    ADD OldAccountCode BIGINT NOT NULL 
        CONSTRAINT DF_DetailAccounts_OldAccountCode DEFAULT(0);
END;
