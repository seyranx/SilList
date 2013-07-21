CREATE TABLE [data].[BusinessImages]
(
	[imageId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [businessId] UNIQUEIDENTIFIER, 
    [created] DATETIME NULL DEFAULT getdate(), 
    [modified] DATETIME NULL DEFAULT getdate(), 
    [craetedBy] INT NULL, 
    [modifiedBy] INT NULL, 
    [isActive] BIT NULL 
	)