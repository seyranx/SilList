CREATE TABLE [data].[ListingCategories]
(
	[listingCategoryId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [listingCategoryTypeId] INT NULL, 
    [listingId] UNIQUEIDENTIFIER NULL
)
