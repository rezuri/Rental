CREATE TABLE [dbo].[Tenant]
(
	[Id] INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, 
    [FirstName] VARCHAR(100) NOT NULL, 
    [Surname] VARCHAR(100) NOT NULL, 
    [IsActive] BIT NOT NULL
)
