IF OBJECT_ID('dbo.Settings') IS NOT NULL
    BEGIN DROP TABLE dbo.settings; END
    GO
    CREATE Table Settings
    (
    SettingKey nvarchar(50) not NULL UNIQUE,
    Value NVARCHAR(50) NOT null DEFAULT ''
    );
    GO
    DECLARE @TableName NVARCHAR(256);
    DECLARE @SQL NVARCHAR(MAX);

    DECLARE TableCursor CURSOR FOR
        SELECT
                TABLE_NAME
        FROM
                INFORMATION_SCHEMA.TABLES
        WHERE
                TABLE_TYPE = 'BASE TABLE'
                AND TABLE_NAME NOT In ('Settings','SchemaVersions');

    OPEN TableCursor;
    FETCH NEXT FROM TableCursor INTO @TableName;

    WHILE @@FETCH_STATUS = 0
        BEGIN
            -- Agar pehle se trigger exist karta ho toh use drop karein
            SET @SQL = 'IF OBJECT_ID(''trg_CheckLock_' + @TableName + ''', ''TR'') IS NOT NULL 
                DROP TRIGGER trg_CheckLock_' + @TableName + ';';
            EXEC sp_executesql
                @SQL;

            -- Dynamic Trigger create karein
            SET @SQL = '
    CREATE TRIGGER trg_CheckLock_' + @TableName + '
    ON [' + @TableName + ']
    AFTER INSERT, UPDATE, DELETE
    AS
    BEGIN
        SET NOCOUNT ON;

        -- Check if Database is locked in Settings table
        IF EXISTS (SELECT 1 FROM Settings WHERE SettingKey = ''IsLocked'' AND LOWER(Value) = ''true'')
        BEGIN
            -- Custom SQL Error Exception Throw karein aur transaction abort/rollback kar dein
            THROW 50001, ''Software is Locked. Please Contact Vendor.'', 1;
            ROLLBACK TRANSACTION;
        END
    END';

            EXEC sp_executesql
                @SQL;
            FETCH NEXT FROM TableCursor INTO @TableName;
        END

    CLOSE TableCursor;
    DEALLOCATE TableCursor;