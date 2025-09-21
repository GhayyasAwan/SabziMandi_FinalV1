CREATE OR ALTER PROCEDURE dbo.BackupDatabase
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @DatabaseName NVARCHAR(128) = 'MandiPOS';
    DECLARE @BackupPath NVARCHAR(200) = 'D:\AutoBackup\';
    DECLARE @FileName NVARCHAR(200);

    -- File name: DatabaseName_ddMMyyyy.bak
    SET @FileName = @BackupPath + @DatabaseName + '_' 
                    + CONVERT(CHAR(8), GETDATE(), 103) + '.bak';

    -- Replace slashes with nothing (103 gives dd/MM/yyyy format)
    SET @FileName = REPLACE(@FileName, '/', '');

    -- Backup with overwrite (INIT)
    BACKUP DATABASE MandiPOS
    TO DISK = @FileName
    WITH INIT,  -- overwrite if exists
         STATS = 10;
END
GO
