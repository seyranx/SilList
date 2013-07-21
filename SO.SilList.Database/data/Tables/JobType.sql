CREATE TABLE [dbo].[JobType]
(
	[jobTypeId] INT NOT NULL PRIMARY KEY, 
    [name] NVARCHAR(50) NULL, 
    [description] NVARCHAR(MAX) NULL, 
    [created] DATETIME NULL DEFAULT getdate(), 
    [modified] DATETIME NULL DEFAULT getdate(), 
    [createdBy] INT NULL, 
    [modifiedBy] INT NULL, 
    [isActive] BIT NULL
)
