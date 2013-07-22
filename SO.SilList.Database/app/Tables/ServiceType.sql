CREATE TABLE [app].[ServiceType]
(
	[serviceTypeId] INT NOT NULL PRIMARY KEY, 
    [description] NVARCHAR(MAX) NULL, 
    [name] NVARCHAR(50) NULL, 
    [siteId] INT NULL, 
    [created] DATETIME NOT NULL DEFAULT getdate(), 
    [modified] DATETIME NOT NULL DEFAULT getdate(), 
    [createdBy] INT NULL, 
    [modifiedBy] INT NULL, 
    [isActive] BIT NULL

)

