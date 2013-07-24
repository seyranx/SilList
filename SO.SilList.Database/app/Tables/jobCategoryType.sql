CREATE TABLE [app].[JobCategoryType]
(
	[jobCategoryTypeId] INT NOT NULL PRIMARY KEY, 
    [name] NVARCHAR(50) NULL, 
    [description] NVARCHAR(MAX) NULL,
	[created] DATETIME NOT NULL DEFAULT getdate(), 
    [modified] DATETIME NOT NULL DEFAULT getdate(), 
    [createdBy] INT NULL, 
    [modifiedBy] INT NULL, 
    [isActive] BIT NULL
)
