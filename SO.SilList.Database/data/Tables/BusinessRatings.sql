CREATE TABLE [data].[BusinessRatings]
(
	[ratingId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [businessId] UNIQUEIDENTIFIER NULL, 
    [created] DATETIME NOT NULL DEFAULT getdate(), 
    [modified] DATETIME NOT NULL DEFAULT getdate(), 
    [createdBy] INT NULL, 
    [modifiedBy] INT NULL, 
    [isActive] BIT NULL DEFAULT 1
)
