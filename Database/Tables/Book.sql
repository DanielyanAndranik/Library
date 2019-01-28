CREATE TABLE [dbo].[Book]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Title] NVARCHAR(256) NOT NULL, 
    [Author] NVARCHAR(128) NOT NULL, 
    [Language] VARCHAR(2) NOT NULL, 
    [Published] DATE NULL, 
    [Publisher] NVARCHAR(128) NULL, 
	[Genre] NVARCHAR(128) NULL,
    [Type] NVARCHAR(128) NOT NULL, 
    [Image] IMAGE NULL,
	[TotalCount] TINYINT NOT NULL, 
    [AvailableCount] TINYINT NOT NULL, 
    [Rating] INT NULL
)
