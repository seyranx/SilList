CREATE TABLE [data].[Listing]
(
	[listingId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [listingDetailId] UNIQUEIDENTIFIER NULL, 
    [title] NVARCHAR(50) NULL, 
    [description] NVARCHAR(50) NULL, 
    [siteId] INT NULL, 
    [listingTypeId] INT NULL
)
