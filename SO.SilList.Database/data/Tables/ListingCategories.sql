CREATE TABLE [data].[ListingCategories]
(
	[listingCategoryId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT (newid()), 
    [listingCategoryTypeId] INT NULL, 
    [listingId] UNIQUEIDENTIFIER NULL,
    [createdBy ] INT NULL, 
    [modifiedBy] INT NULL, 
    [created] DATETIME NOT NULL DEFAULT (getdate()), 
    [modified] DATETIME NOT NULL DEFAULT (getdate()), 
    [isActive] BIT NOT NULL DEFAULT ((1))
)
