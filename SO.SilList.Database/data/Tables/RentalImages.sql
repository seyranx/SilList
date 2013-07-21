CREATE TABLE [data].[RentalImages]
(
	[imageId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [rentalId] UNIQUEIDENTIFIER NOT NULL,
	    [created] DATETIME NOT NULL DEFAULT getdate(), 
    [modified] DATETIME NOT NULL DEFAULT getdate(), 
    [createdBy] INT NULL, 
    [modifiedBy] INT NULL, 
    [isActive] BIT NULL
)
