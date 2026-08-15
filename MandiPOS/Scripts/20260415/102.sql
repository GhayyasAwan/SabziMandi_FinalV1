if Object_id('sp_GetBaqayaReport') is not null
    Begin
         Drop PROCEDURE sp_GetBaqayaReport
    End
    GO

CREATE PROCEDURE sp_GetBaqayaReport 
    @Type INT, -- 1 for Vendor, 2 for Customer
    @FromDate DATE,
    @ToDate DATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Drop temporary table if it exists (Optional for clean execution)
    IF OBJECT_ID('tempdb..#FilteredData') IS NOT NULL 
        DROP TABLE #FilteredData;

    -- Data ko filter karke temporary jagah par rakhna asaan hota hai
    SELECT 
        CAST(ArrivalDate AS DATE) AS Adat,
        PartyTitle,
        CASE WHEN @Type = 1 THEN SaleAmount1 ELSE CustomerAmount END AS Amt1,
        CASE WHEN @Type = 1 THEN SaleAmount2 ELSE PartyAmount END AS Amt2
    INTO #FilteredData
    FROM (
        -- Sirf wahi view uthayein jo Type se match karta ho
        SELECT ArrivalDate, PartyTitle, SaleAmount1, SaleAmount2, 0 AS CustomerAmount, 0 AS PartyAmount
        FROM dbo.vwVendorBaqayaSale
        WHERE @Type = 1
        
        UNION ALL
        
        SELECT ArrivalDate, PartyTitle, 0, 0, CustomerAmount, PartyAmount
        FROM dbo.vwCustomerBaqayaSale
        WHERE @Type = 2
    ) AS Unified
    WHERE CAST(ArrivalDate AS DATE) BETWEEN @FromDate AND @ToDate;

    -- Final Result
    SELECT 
        Adat AS ArrivalDate,
        PartyTitle,
        SUM(Amt1) AS Amount1,
        SUM(Amt2) AS Amount2,
        (SUM(Amt1) - SUM(Amt2)) AS Difference
    FROM #FilteredData
    GROUP BY Adat, PartyTitle
    ORDER BY Adat DESC, PartyTitle;

    -- Cleanup
    DROP TABLE #FilteredData;
END