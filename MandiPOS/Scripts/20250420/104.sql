
-- Standard Practice: Agar SP pehle se majood hai to usay drop kar dein
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetBaqayaReport]') AND type in (N'P', N'PC'))
BEGIN
    DROP PROCEDURE [dbo].[sp_GetBaqayaReport]
END
GO

CREATE PROCEDURE dbo.sp_GetBaqayaReport 
    @Type INT, -- 1 for Vendor, 2 for Customer
    @FromDate DATE,
    @ToDate DATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Yahan hum final result bana rahe hain, is mein Date column show nahi hoga
    SELECT 
        PartyTitle,
        
        -- Jama: Agar plus mein hai to Jama
        SUM(CASE 
            WHEN (CustomerAmount - PartyAmount) > 0 THEN (CustomerAmount - PartyAmount) 
            ELSE 0 
        END) AS Jama,
        
        -- Banam: Agar minus mein hai to Banam (ABS function minus sign hata dega)
        SUM(CASE 
            WHEN (CustomerAmount - PartyAmount) < 0 THEN ABS(CustomerAmount - PartyAmount) 
            ELSE 0 
        END) AS Banam,
        
        -- End Balance: Total net balance
        SUM(CustomerAmount - PartyAmount) AS EndBalance

    FROM (
        -- Data Views se uthaya ja raha hai
        SELECT 
            ArrivalDate, -- Yeh sirf WHERE clause mein date check karne ke liye laya hai
            PartyTitle, 
            CustomerAmount, 
            PartyAmount
        FROM dbo.vwVendorBaqayaSale
        WHERE @Type = 1 
        
        UNION ALL
        
        SELECT 
            ArrivalDate, -- Yeh sirf WHERE clause mein date check karne ke liye laya hai
            PartyTitle, 
            CustomerAmount, 
            PartyAmount
        FROM dbo.vwCustomerBaqayaSale
        WHERE @Type = 2 
    ) AS UnifiedData
    
    -- Date Filter: Yeh check karega ke data select ki gayi dates ke darmiyan ho
    WHERE CAST(ArrivalDate AS DATE) BETWEEN @FromDate AND @ToDate
    
    -- Grouping: Sirf PartyTitle ke hisaab se result dikhaye ga
    GROUP BY PartyTitle
    ORDER BY PartyTitle;

END
GO