CREATE TABLE [dbo].[Order]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [CustomerId] INT NOT NULL FOREIGN KEY REFERENCES [User](Id), 
	[BookId] INT NOT NULL FOREIGN KEY REFERENCES [Book](Id),
    [OrderDate] DATE NOT NULL, 
    [ExpectedReturnDate] DATE NOT NULL,
    [ReturnDate] DATE NULL
)
