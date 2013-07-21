CREATE TABLE [data].[BusinessServices]
(
	[serviceTypeId] INT NOT NULL, 
    [businessId] UNIQUEIDENTIFIER NOT NULL, 
    [created] DATETIME NULL DEFAULT getdate(), 
    [modified] DATETIME NULL DEFAULT getdate(), 
    [createdBy] INT NULL, 
    [modifiedBy] INT NULL, 
    [isActive] BIT NULL
)
