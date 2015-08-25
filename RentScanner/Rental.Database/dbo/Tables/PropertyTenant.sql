CREATE TABLE [dbo].[PropertyTenant]
(
	[Id] INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, 
    [TenantId] INT NOT NULL, 
    [PropertyId] INT NOT NULL, 
    [IsActive] BIT NOT NULL, 
    CONSTRAINT [FK_PropertyTenant_Property] FOREIGN KEY ([PropertyId]) REFERENCES [Property]([Id]), 
    CONSTRAINT [FK_PropertyTenant_Tenant] FOREIGN KEY ([TenantId]) REFERENCES [Tenant]([Id])
)