/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Vouchers
	DROP CONSTRAINT DF__Vouchers__Create__0D7A0286
GO
CREATE TABLE dbo.Tmp_Vouchers
	(
	VoucherID int NOT NULL IDENTITY (1, 1),
	VoucherNo int NULL,
	VoucherDate date NULL,
	VoucherType int NULL,
	Description nvarchar(MAX) NULL,
	Amount numeric(18, 2) NULL,
	CreatedBy nvarchar(50) NULL,
	CreatedDate datetime NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Vouchers SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_Vouchers ADD CONSTRAINT
	DF__Vouchers__Create__0D7A0286 DEFAULT (getdate()) FOR CreatedDate
GO
SET IDENTITY_INSERT dbo.Tmp_Vouchers ON
GO
IF EXISTS(SELECT * FROM dbo.Vouchers)
	 EXEC('INSERT INTO dbo.Tmp_Vouchers (VoucherID, VoucherNo, VoucherDate, VoucherType, Description, Amount, CreatedBy, CreatedDate)
		SELECT VoucherID, VoucherNo, VoucherDate, CONVERT(int, VoucherType), Description, Amount, CreatedBy, CreatedDate FROM dbo.Vouchers WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Vouchers OFF
GO
ALTER TABLE dbo.JVEntries
	DROP CONSTRAINT FK_JVEntries_Vouchers
GO
ALTER TABLE dbo.VoucherDetails
	DROP CONSTRAINT FK_VoucherID
GO
DROP TABLE dbo.Vouchers
GO
EXECUTE sp_rename N'dbo.Tmp_Vouchers', N'Vouchers', 'OBJECT' 
GO
ALTER TABLE dbo.Vouchers ADD CONSTRAINT
	PK__Vouchers__3AEE79C19E26D4E7 PRIMARY KEY CLUSTERED 
	(
	VoucherID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.VoucherDetails ADD CONSTRAINT
	FK_VoucherID FOREIGN KEY
	(
	VoucherID
	) REFERENCES dbo.Vouchers
	(
	VoucherID
	) ON UPDATE  NO ACTION 
	 ON DELETE  CASCADE 
	
GO
ALTER TABLE dbo.VoucherDetails SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.JVEntries ADD CONSTRAINT
	FK_JVEntries_Vouchers FOREIGN KEY
	(
	VoucherID
	) REFERENCES dbo.Vouchers
	(
	VoucherID
	) ON UPDATE  NO ACTION 
	 ON DELETE  CASCADE 
	
GO
ALTER TABLE dbo.JVEntries SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
