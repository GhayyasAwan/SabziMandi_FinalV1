CREATE FUNCTION dbo.fn_GetNetSaleAccount()
RETURNS INT
AS
BEGIN
    DECLARE @AccountID INT;

    SELECT @AccountID = ISNULL(CAST(ConfigValue AS INT), 0)
    FROM tblConfigs
    WHERE ConfigName = 'netsale';

    RETURN @AccountID;
END;
GO

