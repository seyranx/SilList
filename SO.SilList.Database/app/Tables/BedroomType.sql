CREATE TABLE [app].[BedroomType]
(
	[bedroomTypeId] INT NOT NULL PRIMARY KEY, 
    [name] VARCHAR(15) NOT NULL,
	[created] DATETIME NOT NULL DEFAULT getdate(), 
    [modified] DATETIME NOT NULL DEFAULT getdate(), 
    [createdBy] INT NULL, 
    [modifiedBy] INT NULL, 
    [isActive] BIT NOT NULL DEFAULT (1)
	)
 
    
