if Object_ID('fn_GetRecoveryReport') is not null
Begin
Drop function fn_GetRecoveryReport
End
Go
CREATE FUNCTION fn_GetRecoveryReport
    (
        @SelectedDate DATE
    )
RETURNS TABLE
AS
    RETURN
    SELECT
            t.AccountID,
            acc.AccountCode,
            acc.AccountTitle,
            acc.Contact,
            ISNULL(SUM(CASE
                    WHEN VoucherDate < @SelectedDate
                        THEN
                        DebitAmount - CreditAmount
            END), 0)         AS PreviousBalance,
            ISNULL(SUM(CASE
                    WHEN VoucherDate = @SelectedDate
                        THEN
                        DebitAmount
            END), 0)         AS TodayDebit,
            ISNULL(SUM(CASE
                    WHEN VoucherDate = @SelectedDate
                        THEN
                        CreditAmount
            END), 0)         AS TodayCredit,
            ISNULL(SUM(CASE
                    WHEN VoucherDate <= @SelectedDate
                        THEN
                        DebitAmount - CreditAmount
            END), 0)         AS CurrentBalance,
            MAX(VoucherDate) AS LastDate,
            -- Added for sorting
            CASE
                    WHEN ISNULL(SUM(CASE
                                WHEN VoucherDate = @SelectedDate
                                    THEN
                                    DebitAmount
                        END), 0) > 0
                        THEN
                        1
                    ELSE
                    0
            END              AS HasTodayDebit
    FROM
            vwTrx t
        LEFT JOIN
            DetailAccounts acc
                ON t.AccountID = acc.ID
    WHERE

            acc.MasterID = 7
            AND ISNULL(acc.IsActive, 1) = 1
            AND acc.ID <> (SELECT
                        ISNULL((SELECT
                                    ConfigValue
                            FROM
                                    tblConfigs
                            WHERE
                                    ConfigName = 'netsale')
                        , 0
                        ) AS NetSale)
    GROUP BY
            t.AccountID,
            acc.AccountCode,
            acc.AccountTitle,
            acc.Contact
    HAVING
            ISNULL(SUM(CASE
                    WHEN VoucherDate <= @SelectedDate
                        THEN
                        DebitAmount + CreditAmount
            END), 0) <> 0
GO


If Object_id('usp_GetRecoveryReport') is not null
Begin
Drop proc usp_GetRecoveryReport;
End
go

Create proc [dbo].[usp_GetRecoveryReport]
@SelectedDate date
as
Begin
Declare @FirstDate date;
Select @FirstDate=Min(VoucherDate) from Vwtrx;

select * from fn_GetRecoveryReport(@selectedDate)
Order by CASE WHEN LastDate > @FirstDate THEN 1 ELSE 2 END ASC,
CASE WHEN LastDate > @FirstDate THEN HasTodayDebit END DESC,
        CASE WHEN LastDate > @FirstDate THEN LastDate END DESC,
        CASE WHEN LastDate > @FirstDate THEN AccountCode END ASC,
CASE WHEN LastDate = @FirstDate THEN AccountCode END DESC,
        CASE WHEN LastDate = @FirstDate THEN HasTodayDebit END DESC,
        CASE WHEN LastDate = @FirstDate THEN LastDate END DESC;

End