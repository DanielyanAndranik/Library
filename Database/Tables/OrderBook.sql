﻿CREATE TABLE [dbo].[OrderBook]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[OrderId] INT NOT NULL FOREIGN KEY REFERENCES [Order](Id), 
    [BookId] INT NOT NULL FOREIGN KEY REFERENCES Book(Id)
)
