Create Table tblUsers
(
UserID int not null identity(1,1) primary key,
UserName nvarchar(250) not null unique,
UserPassword nvarchar(250) not null,
isAdmin bit not null default 0
)
