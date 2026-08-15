Create proc usp_SaveAgreement
@AgreementID int,
@PartyID int,
@AgreementStartDate date,
@AgreementEndDate date,
@Remarks nvarchar(Max)
as
Begin

 UPDATE dbo.tblAgreements
    SET    PartyID = @PartyID, AgreementStartDate = @AgreementStartDate, AgreementEndDate = @AgreementEndDate, 
           Remarks = @Remarks
    WHERE  AgreementID = @AgreementID

    IF @@rowcount=0
    Begin
    INSERT INTO dbo.tblAgreements (PartyID, AgreementStartDate, AgreementEndDate, Remarks)
    SELECT @PartyID, @AgreementStartDate, @AgreementEndDate, @Remarks;
    set @agreementID=SCOPE_IDENTITY()
    End

    select @agreementID
End