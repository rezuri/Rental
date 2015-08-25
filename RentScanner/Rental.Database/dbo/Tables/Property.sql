CREATE TABLE [dbo].[Property]
(
	[Id] INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, 
    [Number] VARCHAR(10) NOT NULL, 
    [Address] VARCHAR(100) NOT NULL, 
    [Suburb] VARCHAR(50) NOT NULL, 
    [PostCode] INT NOT NULL, 
    [IsActive] BIT NOT NULL
)
