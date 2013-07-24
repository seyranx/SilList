CREATE TABLE [app].[JobCategories]
(
	[jobCategoryTypeId] INT NOT NULL PRIMARY KEY, 
    [jobId] UNIQUEIDENTIFIER NULL,
	[created] DATETIME NOT NULL DEFAULT getdate(), 
    [modified] DATETIME NOT NULL DEFAULT getdate(), 
    [createdBy] INT NULL, 
    [modifiedBy] INT NULL, 
    [isActive] BIT NULL
)
