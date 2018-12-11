CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(128) NOT NULL, 
    [Email] VARCHAR(320) NOT NULL, 
    [Phone] VARCHAR(8) NULL, 
    [BirthDate] DATE NOT NULL,
	[Username] VARCHAR(32) NOT NULL, 
    [Password] VARCHAR(32) NOT NULL, 
    [CreationDate] DATE NOT NULL, 
	[Role] varchar(16) NOT NULL,
    [Approved] BIT NOT NULL DEFAULT 0
)
