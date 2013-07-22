CREATE TABLE [app].[RentType]
(
	[rentTypeId] INT NOT NULL PRIMARY KEY, 
    [name] NVARCHAR(50) NOT NULL, 
    [description] NVARCHAR(MAX) NOT NULL,
	[created] DATETIME NOT NULL DEFAULT getdate(), 
    [modified] DATETIME NOT NULL DEFAULT getdate(), 
    [createdBy] INT NULL, 
    [modifiedBy] INT NULL, 
    [isActive] BIT NULL DEFAULT 1
)
