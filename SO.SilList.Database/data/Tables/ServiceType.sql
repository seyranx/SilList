CREATE TABLE [data].[ServiceType]
(
	[serviceTypeId] INT NOT NULL PRIMARY KEY, 
    [description] NVARCHAR(MAX) NULL, 
    [name] NVARCHAR(50) NULL, 
    [siteId] INT NULL, 
    [created] DATETIME NULL DEFAULT getdate(), 
    [modified] DATETIME NULL DEFAULT getdate(), 
    [createdBy] INT NULL, 
    [modifiedBy] INT NULL, 
    [isActive] BIT NULL

)

