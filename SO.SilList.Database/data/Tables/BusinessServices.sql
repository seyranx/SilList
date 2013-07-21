CREATE TABLE [data].[BusinessServices]
(
	[serviceTypeId] INT NOT NULL PRIMARY KEY, 
    [businessId] UNIQUEIDENTIFIER NOT NULL DEFAULT newid(), 
    [created] DATETIME NULL DEFAULT getdate(), 
    [modified] DATETIME NULL DEFAULT getdate(), 
    [createdBy] INT NULL, 
    [modifiedBy] INT NULL, 
    [isActive] BIT NULL
)
