Create Table tblPermissions
(
	PermissionID int identity(1,1) primary key,
	PermissionTitle nvarchar(250) not null,
	[IsReport] [bit] NOT NULL default 0
)