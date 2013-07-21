CREATE TABLE [dbo].[BusinessServices]
(
	[serviceTypeId] INT NOT NULL PRIMARY KEY, 
    [businessId] UNIQUEIDENTIFIER NULL, 
    [created] DATETIME NULL DEFAULT getdate(), 
    [modified] DATETIME NULL DEFAULT getdate(), 
    [createdBy] INT NULL, 
    [modifiedBy] INT NULL, 
    [isActive] BIT NULL
)
