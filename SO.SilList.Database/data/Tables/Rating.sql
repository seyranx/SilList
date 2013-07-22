CREATE TABLE [data].[Rating]
(
	[ratingId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [rating] INT NULL, 
    [review] NVARCHAR(50) NULL, 
    [memberId] INT NULL, 
    [created] DATETIME NOT NULL DEFAULT getdate(), 
    [modified] DATETIME NOT NULL DEFAULT getdate(), 
    [createdBy] INT NULL, 
    [modifiedBy] INT NULL, 
    [isActive] BIT NULL DEFAULT 1
)
